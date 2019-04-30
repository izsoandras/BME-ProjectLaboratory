void motorInit(){
  MR.setmotor(_STOP);
  ML.setfreq(freq);
  ML.setmotor(_STOP);
  ML.setfreq(freq);
  Serial.println("Motor is set up");
}

void sensorInit(){
  Wire.begin();
  if(lsm303c.begin() != IMU_SUCCESS){
    Serial.println("LSM303C setup error");
  } else{
    Serial.println("LSM303C setup success");
  }
  if(!bme280.begin(0x76)){
    Serial.println("BME280 setup error");
  } else{
    bme280.setSampling(Adafruit_BME280::MODE_FORCED,
                     Adafruit_BME280::SAMPLING_X2, // temperature
                     Adafruit_BME280::SAMPLING_X16, // pressure
                     Adafruit_BME280::SAMPLING_X1, // humidity
                     Adafruit_BME280::FILTER_OFF   );
    Serial.println("BME280 setup success");
  }
}

void setMotorSpeed(int speedL, int speedR){
  int realSpeedL = 40 + speedL*0.6;
  int realSpeedR = 40 + speedR*0.6;
  
  if (speedL == 0)
  {
    ML.setmotor(_SHORT_BRAKE);
  }
  else if (speedL > 0) {
    ML.setmotor(_CCW, realSpeedL);
  }
  else
  {
    ML.setmotor(_CW, -1 * realSpeedL);
  }

  if (speedR == 0)
  {
    MR.setmotor(_SHORT_BRAKE);
  }
  else if (speedR > 0) {
    MR.setmotor(_CW, realSpeedR);
  }
  else
  {
    MR.setmotor(_CCW, -1 * realSpeedR);
  }
}

void setMotorFreq(int freq){
  MR.setfreq(freq);
  ML.setfreq(freq);
}
