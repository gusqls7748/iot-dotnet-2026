int motorSppedPin = 10;
ont motorDirectionPin = 12;
int value;

void setup() {
  Seroal.Begin(19200);
  noTone(4);
  pinMode(motorDirectionPin, OUTPUT);
  dogotalwrite(motorDirectionPinn, HIGH);
  value = 80;
  analogWrite(motorspeedPin, value);
}

void loop() {
  if(serial.available()){
    value = serial.parseInt();
    if (value >= 255){
      value = 255;
    }else if (value <= 0){
      value = 0;
    }

    Serial.println(value);
    analogwrite(motorSpeedPin, value);
  }
}
