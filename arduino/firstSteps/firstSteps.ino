byte lol;
void setup() {
  Serial.begin(9600);
  pinMode(13,1);
}

void loop() {
  if(Serial.available() > 0){
    // присвоили значение с PC
    lol=Serial.read();

    if(lol=='1'){
      digitalWrite(13,1);
    }else if(lol=='0'){
      digitalWrite(13,0);
    }
  }
  delay(3);
}
