using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


using System.Windows.Forms.DataVisualization.Charting;


namespace interfaceADC
{
    public partial class painelADC : Form
    {
        int k = 10;
        string RxString;
        int tempo = 0;
     
        public painelADC()
        {
            InitializeComponent();
            timerCOM.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void atualizaListaCOMs()
        {
            int i = 0;
            bool quantDiferente;
            quantDiferente = false;

            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBox1.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            if (quantDiferente == false)
            {
                return;
            }

            comboBox1.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.Open();

                }
                catch
                {
                    return;

                }
                if (serialPort1.IsOpen)
                {
                    btConectar.Enabled = false;
                    comboBox1.Enabled = false;
                    chart1.Series.Clear();
                    chart1.Series.Add("Tensão");
                    chart1.Series["Tensão"].ChartType = SeriesChartType.Line;
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    comboBox1.Enabled = true;
                    btConectar.Text = "Conectar";
                }
                catch
                {
                    System.Console.Write("Ocorreu um erro ao fechar a conexão");
                    return;
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
                serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(trataDadoRecebido));
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            string binario = "";
            try
            {
                RxString = RxString.TrimEnd('\r', '\n');
                if(RxString.Length == 8)
                {
                    binario = RxString.Substring(0, 8);
                    Double tensao = 0;
                    int ndecimal = Convert.ToInt32(binario, 2);
                    tensao = ndecimal * 0.019607843;
                    valorTensao.Text = string.Format("{0:0.00}", tensao);
                    System.Console.WriteLine(tensao);
                    RxString = "";
                    atualizaChart(tempo, tensao);
                    tempo++;
                }
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex);
            }

            
        }

        public void atualizaChart(double time, double tensao)
        {

            chart1.ChartAreas[0].AxisY.Maximum = 5;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.Series["Tensão"].BorderWidth = 5;

            chart1.Series["Tensão"].Points.AddXY(time, tensao);

            if (chart1.Series["Tensão"].Points.Count >  31 )
            {

                chart1.ChartAreas[0].AxisX.Maximum = time;
                chart1.ChartAreas[0].AxisX.Minimum = time - 20;

                chart1.Series["Tensão"].Points.RemoveAt(0);
                chart1.Update();
            }
        }
    }
}
