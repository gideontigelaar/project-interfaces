#include <Arduino.h>

int potPin = A0;
int potValue = 0;

void setup() { // put your setup code here, to run once:
  pinMode(potPin, INPUT);
  Serial.begin(115200);
}

void loop() { // put your main code here, to run repeatedly:
  if(Serial.available()) {
    char inByte = Serial.read();

    if(inByte == 'a') {
      int potValue = analogRead(potPin);
      Serial.println(potValue);
    }
  }
}
