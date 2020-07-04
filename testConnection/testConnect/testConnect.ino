//Arduino IDE C/C++
void setup() 
{
  Serial.begin(115200);
  pinMode(2, OUTPUT);
}

void loop() 
{
  if(Serial.available() > 0)
  {
    String incomming = Serial.readString();
    if(incomming == "Hello World")
    {
      digitalWrite(2, HIGH);
      delay(5000);
      digitalWrite(2, LOW);
      delay(5000);
      digitalWrite(2, HIGH);
    }
  }
}
