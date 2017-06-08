
void setup() {
  Serial.begin(9600);
  pinMode(2, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(7, INPUT);
  pinMode(8, INPUT);
  pinMode(9, INPUT);
}

void loop() {
  String bin = "";
  for( int i = 2; i <= 9 ; i++ )
  {
    bin = String(bin + digitalRead(i));
  }

  Serial.println(bin);  
  delay(100);
}
