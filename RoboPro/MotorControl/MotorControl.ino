/*
  Name:		MotorControl.ino
  Created:	2019-02-06 10:37:42
  Author:	izsoandras
*/

#include "L298N_shield.h"
#include "Wire.h"
#include "SparkFunIMU.h"
#include "SparkFunLSM303C.h"
#include "LSM303CTypes.h"
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#include <math.h>

#define MAXDUTY  100
#define SCL 5 //D1
#define SDA 4 //D2

//Global variables for motor control
Motor ML(0x30, _MOTOR_A, 1000);
Motor MR(0x30, _MOTOR_B, 1000);
int length;
int speedL = 0;
int speedR = 0;
int freq = 100;

//Global variables for sensors
LSM303C lsm303c;          //Magneto- and accelerometer
Adafruit_BME280 bme280;   //Temperature, pressure and humidity meter

//Global variables for communication
bool ledOn = false;
String serialString;
char * serialdata;
unsigned long last_message_time = 0;

typedef struct vec2 {
  float x;
  float y ;
} vec2;

void setup() {

  //  setMotorSpeed(0,60);
  //  delay(5000);
  //
  //  setMotorSpeed(0,0);
  //  delay(100);
  //
  //  setMotorSpeed(60,0);
  //  delay(5000);
  //
  //  setMotorSpeed(0,0);
  //
  //  while(true)
  //  ;
  Serial.begin(115200);
  pinMode(LED_BUILTIN, OUTPUT);

  motorInit();
  sensorInit();

  Serial.println("Setup ready");
}

// the loop function runs over and over again until power down or reset
void loop() {
  //If message arrived
  if (Serial.available() > 0)
  {
    last_message_time = millis();
    serialString = Serial.readStringUntil(':');
    serialString.trim();
    //Check message type
    //If speed (S)
    if (serialString == "S")
    {
      speedCommand();
      //If freq (F)
    } else if (serialString == "F") {
      pwmCommand();
      //If status requ (?)
    } else if (serialString == "?") {
      statusCommand();
      //If LED (L)
    } else if (serialString == "L") {
      ledCommand();
    } else if (serialString == "M") {
      magCommand();
    } else if (serialString == "A") {
      accCommand();
    } else if (serialString == "T") {
      tempCommand();
    } else if (serialString == "P") {
      pressureCommand();
    } else if (serialString == "H") {
      humidCommand();
    } else if (serialString == "C") {
      /*
        Serial.println("Doing circle");
        float epsilon = 0.03;
        char sbuf[30];
        float x = lsm303c.readMagX();
        float y = lsm303c.readMagY();
        sprintf(sbuf, "Mag: X=%.2f\tY=%.2f\tZ=%.2f", x, y);
        Serial.println(sbuf);
        freq = 50;
        ML.setfreq(50);
        MR.setfreq(50);
        speedL = 40;
        speedR = 40;
        ML.setmotor(_CW, speedL);
        MR.setmotor(_CW, speedR);
        delay(1000);
        while(!(fabsf(x - lsm303c.readMagX()) < epsilon && fabsf(y - lsm303c.readMagY()) < epsilon)){
          sprintf(sbuf, "Mag: X=%.2f\tY=%.2f\tZ=%.2f", lsm303c.readMagX(), lsm303c.readMagY());
          Serial.println(sbuf);
          delay(20);
        }*/

      //save current orientation
      vec2 orig = { lsm303c.readMagX(), lsm303c.readMagY()};
      char sbuf[30];
      sprintf(sbuf, "Mag: X=%.2f\tY=%.2f\tZ=%.2f", orig.x, orig.y);

      //start turning
      freq = 50;
      setMotorFreq(freq);
      speedL = -40;
      speedR = 40;
      setMotorSpeed(speedL, speedR);

      //perform 4 90degree turn
      float angle = 0;
      vec2 current;
      for (int i = 0; i < 4; i++) {
        while (angle < PI / 2) {
          delay(20);
          current = {lsm303c.readMagX(), lsm303c.readMagY()};
          angle = getAngle(orig, current);
          sprintf(sbuf, "Mag: X=%.2f\tY=%.2f\tZ=%.2f", current.x, current.y);
        }
        orig = current;
      }

      setMotorSpeed(0, 0);
    }



  } else if(millis() - last_message_time > 5000){
    setMotorSpeed(0,0);
  }
}
