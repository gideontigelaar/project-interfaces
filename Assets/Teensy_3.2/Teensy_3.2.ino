int potPin = A0;
int buttonPin = 11;

void setup() {
  pinMode(potPin, INPUT);
  pinMode(buttonPin, INPUT_PULLUP);
  Serial.begin(115200);
  Keyboard.begin();
}

void loop() {
//  if (Serial.available()) {
//    char inByte = Serial.read();

//    if (inByte == 'a') {
      int potValue = analogRead(potPin);
//      Serial.println(potValue);

      if (digitalRead(buttonPin)) {
        return;
      }

      else {
//        Serial.println("pressed");
        
        if (potValue > 765 && potValue < 792) {
          Keyboard.press(KEY_LEFT_ARROW);
          delay(200);
          Keyboard.release(KEY_LEFT_ARROW);
        }

        else if (potValue > 728 && potValue < 764) {
          Keyboard.press(KEY_DOWN_ARROW);
          delay(200);
          Keyboard.release(KEY_DOWN_ARROW);
        }

        if (potValue > 700 && potValue < 727) {
          Keyboard.press(KEY_RIGHT_ARROW);
          delay(200);
          Keyboard.release(KEY_RIGHT_ARROW);          
        }
      }
//    }
//  }
}
