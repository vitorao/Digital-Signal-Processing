/*
    Desenvolvido por Vitor Araujo Oliveira
*/

#include <iostream>
#include <math.h>
#include <complex>
#include <fstream>
#include <string>
#include <stdlib.h>

using namespace std;


double sinc(double k, int m)
{
    if((k - m) == 0)
    {
        return 1;
    }
    return sin(M_PI*(k - m)) / (M_PI*(k - m));
}

void run_sinc(string nome_arquivo, double p_FS, double p_N, double p_k, double p_A)
{
    std::ofstream recFile;
    string archive_name = nome_arquivo;
    double XM = 0, FS = p_FS, N = p_N, k = p_k, A = p_A, fa = 0; // Inicialização das variáveis com os parametros

    recFile.open(archive_name.c_str());    
    //Execução da DFT
    for (int m = 0; m < N; m++)
    {           
        fa = ((m*FS)/N);
        XM = sinc(k,m)*(A*N/2);
        if(XM > -0.0001 && XM < 0.0001 ) XM = 0;
        recFile << fa <<  " " << XM <<  endl;
    }
    recFile.close();
    cout << "\nO arquivo foi gravado com sucesso" << endl;
}



int main()
{
    
    double FS, N, k, A, fa;
    string  archive_name, input;
    
    do
    {
        cout << "Informe o valor da Frequência (FS): ";
        cin >> FS;
        cout << "Informe o numero de repetições (N): ";
        cin >> N;
        cout << "Informe a quantidade de ciclos (K): ";
        cin >> k;
        cout << "Informe amplitude do sinal (A0): ";
        cin >> A;
        cout << "Informe o nome do arquivo (Ex: file.txt): ";
        cin >> archive_name;
        
        run_sinc(archive_name, FS, N, k, A);

        cout << "Deseja gerar outro arquivo? (use: [S/n])";
        cin >> input;

    }while(input == "S" || input == "s");
    
    return 0;
}
