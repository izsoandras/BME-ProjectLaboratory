void speedCommand() {
  serialString = Serial.readStringUntil(',');
  speedL = min(serialString.toInt(), 100);
  serialString = Serial.readStringUntil('\n');
  speedR = min(serialString.toInt(), 100);

  Serial.print("S:");
  Serial.print(speedL);
  Serial.print(",");
  Serial.println(speedR);

  setMotorSpeed(speedL, speedR);
}

void pwmCommand(){
  serialString = Serial.readStringUntil('\n');
      freq = serialString.toInt();
      Serial.print("P:");
      Serial.println(freq);
      setMotorFreq(freq);
 }

 void ledCommand(){
  serialString = Serial.readStringUntil('\n');
      ledOn = serialString.toInt() > 0;
      Serial.print("L:");
      Serial.println(ledOn ? "1" : "0");
      digitalWrite(LED_BUILTIN, ledOn ? LOW : HIGH);
 }
void statusCommand(){
  Serial.print("S:");
      Serial.print(speedL);
      Serial.print(",");
      Serial.println(speedR);
      Serial.print("P:");
      Serial.println(freq);
      Serial.print("L:");
      Serial.println(ledOn ? "1" : "0");
}
void magCommand(){
      //char sbuf[30];
      //sprintf(sbuf, "Mag: X=%.2f\tY=%.2f\tZ=%.2f", lsm303c.readMagX(), lsm303c.readMagY(), lsm303c.readMagZ());
      //Serial.println(sbuf);
      float x = lsm303c.readMagX();
      float y = lsm303c.readMagY();
      float z = lsm303c.readMagZ();

      //normalize
      x = -1 + (x + 0.71)/(0.28 + 0.71)*2;
      y = -1 + (y + 0.38)/(0.45+0.38)*2;
      z = -1 + (z + 0.29)/(0.52+0.29)*2;

      //Change to robot coordinates (sensor is upside-down, turned 90deg
      float tmp = x;
      x = -y;
      y = tmp;
      
      Serial.print("M:");
      Serial.print(x);
      Serial.print(',');
      Serial.print(y);
      Serial.print(',');
      Serial.println(z);
}
void accCommand(){
      //char sbuf[30];
      //sprintf(sbuf, "Acc: X=%.2f\tY=%.2f\tZ=%.2f", lsm303c.readAccelX(), lsm303c.readAccelY(), lsm303c.readAccelZ());
      //Serial.println(sbuf);
      float x = lsm303c.readAccelX();
      float y = lsm303c.readAccelY();
      float z = lsm303c.readAccelZ();
      Serial.print("A:");
      Serial.print(x);
      Serial.print(',');
      Serial.print(y);
      Serial.print(',');
      Serial.println(z);
}

void tempCommand(){
  bme280.takeForcedMeasurement();
  Serial.print("T:");
      Serial.println(bme280.readTemperature());
}
void pressureCommand(){
  bme280.takeForcedMeasurement();
  Serial.print("P:");
      Serial.println(bme280.readPressure());
}
void humidCommand(){
  bme280.takeForcedMeasurement();
  Serial.print("H:");
      Serial.println(bme280.readHumidity());
}
