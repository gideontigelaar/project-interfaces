#include <Arduino.h>

int potPin = A0;
int potValue = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(potPin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  potValue = analogRead(potPin);
  Serial.println(potValue);
}