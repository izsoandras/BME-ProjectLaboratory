/*
 Name:		MotorControl.ino
 Created:	2019-02-06 10:37:42
 Author:	izsoandras
*/

#include "WEMOS_Motor.h"

#define MAXDUTY  100

Motor ML(0x30, _MOTOR_A, 1000);
Motor MR(0x30, _MOTOR_B, 1000);
String serialString;
char * serialdata;
int length;
int speedL = 0;
int speedR = 0;
int freq = 100;
bool ledOn = false;

void setup() {
	Serial.begin(115200);
	pinMode(LED_BUILTIN, OUTPUT);
	MR.setmotor(_STOP);
	ML.setmotor(_STOP);
	digitalWrite(LED_BUILTIN, HIGH);
	delay(100);
	digitalWrite(LED_BUILTIN, LOW);
	Serial.println("Setup ready");
}

 int min(int a, int b)
{
	 return a > b ? b : a;
}

// the loop function runs over and over again until power down or reset
void loop() {

	if(Serial.available() > 0)
	{
		if((serialString = Serial.readStringUntil(':')) == "S")
		{
			serialString = Serial.readStringUntil(',');
			speedL = min(serialString.toInt(), 100);
			serialString = Serial.readStringUntil('\n');
			speedR = min(serialString.toInt(), 100);
			ledOn = !ledOn;

			Serial.print("S:");
			Serial.print(speedL);
			Serial.print(",");
			Serial.println(speedR);

			if (speedL == 0)
			{
				ML.setmotor(_SHORT_BRAKE);
			}
			else if (speedL > 0) {
				ML.setmotor(_CCW, speedL);
			}
			else
			{
				ML.setmotor(_CW, -1 * speedL);
			}

			if (speedR == 0)
			{
				MR.setmotor(_SHORT_BRAKE);
			}
			else if (speedR > 0) {
				MR.setmotor(_CW, speedR);
			}
			else
			{
				MR.setmotor(_CCW, -1 * speedR);
			}
		} else if(serialString == "P"){
			serialString = Serial.readStringUntil('\n');
			freq = serialString.toInt();
			Serial.print("P:");
			Serial.println(freq);
			ML.setfreq(freq);
			MR.setfreq(freq);
		} else if(serialString == "?")
		{
			Serial.print("S:");
			Serial.print(speedL);
			Serial.print(",");
			Serial.println(speedR);
			Serial.print("P:");
			Serial.println(freq);
			Serial.print("L:");
			Serial.println(ledOn ? "1" : "0");
		} else if(serialString == "L")
		{
			serialString = Serial.readStringUntil('\n');
			ledOn = serialString.toInt() > 0;
			Serial.print("L:");
			Serial.println(ledOn ? "1" : "0");
			digitalWrite(LED_BUILTIN, ledOn ? LOW : HIGH);
		}
		

		
	}
}
