#include "L298N_shield.h"
#include "PWMFrequency.h"

/* Motor()
address:
	Shield I2C address
freq:
	PWM's frequency		
*/
Motor::Motor(uint8_t address, uint8_t motor, uint32_t freq)
{

	
	_use_STBY_IO=false;

	if(motor==_MOTOR_A){
		_motor= 10;
   pinMode(10, OUTPUT);
   pinMode(8, OUTPUT);
   pinMode(9, OUTPUT);
	}
	else{
		_motor= 11;
   pinMode(11, OUTPUT);
   pinMode(12, OUTPUT);
   pinMode(13, OUTPUT);
	}

	setmotor(_SHORT_BRAKE);
	  
	_address=address;

	setfreq(freq);

}


/* setfreq() -- set PWM's frequency

freq:
	PWM's frequency	

*/
void Motor::setfreq(uint32_t freq)
{
	setPWMPrescaler(_motor, 31250/freq);
}

/* setmotor() -- set motor

motor:
	_MOTOR_A	0	Motor A
	_MOTOR_B	1	Motor B

dir:
	_SHORT_BRAKE	0
	_CCW			1
	_CCW			2
	_STOP			3
	_STANDBY		4

pwm_val:
	0.00 - 100.00  (%)

*/
void Motor::setmotor(uint8_t dir, float pwm_val)
{
	analogWrite(_motor, pwm_val/100.0 * 255.0);
	
	switch(dir){
		case _CCW:
			digitalWrite(_motor == 10 ? 9 : 13, HIGH);
			digitalWrite(_motor == 10 ? 8 : 12, LOW);
			break;
		case _CW:
			digitalWrite(_motor == 10 ? 9 : 13, LOW);
			digitalWrite(_motor == 10 ? 8 : 12, HIGH);
			break;
		case _STOP:
			analogWrite(_motor, 0);
			break;
		case _STANDBY:
			analogWrite(_motor, 0);
			digitalWrite(_motor == 10 ? 9 : 13, LOW);
			digitalWrite(_motor == 10 ? 8 : 12, LOW);
			break;
		case _SHORT_BRAKE:
			digitalWrite(_motor == 10 ? 9 : 13, HIGH);
			digitalWrite(_motor == 10 ? 8 : 12, HIGH);
			break;
	}
	
	
	
}

void Motor::setmotor(uint8_t dir)
{
	setmotor(dir,100);
}
