void setup() {
  pinMode(13,1);
}

void loop() {
  digitalWrite(13,1);
  delay(1500);
  digitalWrite(13, 0);
  delay(500);
}
