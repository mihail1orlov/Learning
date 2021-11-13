#include "ESP8266WiFi.h"
void setup() {
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  WiFi.disconnect();
  delay(100);
  Serial.println("Настройка выполнена");
}
void loop() {
  Serial.println("начало сканирования");
  int n = WiFi.scanNetworks();
  Serial.println("Настройка выполнена");
  if (n == 0) {
    Serial.println("сети не найдены");
  } else {
    Serial.print(n);
    Serial.println(" сети найдены");
    for (int i = 0; i < n; ++i) {
      Serial.print(i + 1);
      Serial.print(": ");
      Serial.print(WiFi.SSID(i));
      Serial.print(" (");
      Serial.print(WiFi.RSSI(i));
      Serial.print(")");
      Serial.println((WiFi.encryptionType(i) == ENC_TYPE_NONE) ? " " : "*");
      delay(10);
    }
  }
  Serial.println();
  delay(5000);   // Ждём, прежде чем снова сканировать
}
