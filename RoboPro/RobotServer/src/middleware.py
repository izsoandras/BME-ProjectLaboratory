import serial


class MyMotor(object):

    def __init__(self, serialport, baud=115200):
        self.ser = serial.Serial(port=serialport, baudrate=baud)
        self._pwm = 1000
        self._baseSpeed = 40
        self._rightCurrSpeed = 0
        self._leftCurrSpeed = 0
        self._dirL = 1
        self._dirR = 1
        self._turnRatio = 1

    @property
    def pwm(self):
        return self.pwm

    @pwm.setter
    def pwm(self, pwm):
        self.pwm = pwm
        self.ser.write(str.encode("P:{}\n".format(pwm)))

    @property
    def speed(self):
        return self._baseSpeed

    @speed.setter
    def speed(self, speed):
        self._baseSpeed = speed
        if self.isGoing():
            self._updateSpeed()

    def _updateSpeed(self):
        self._rightCurrSpeed = self._dirR * self._baseSpeed * (2 - self._turnRatio)
        self._leftCurrSpeed = self._dirL * self._baseSpeed * self._turnRatio
        self.ser.write(str.encode("S:{0},{1}\n".format(self._leftCurrSpeed, self._rightCurrSpeed)))

    def isGoing(self):
        return self._leftCurrSpeed != 0 or self._rightCurrSpeed != 0

    def forward(self):
        self._dirL = 1
        self._dirR = 1
        self._turnRatio = 1
        self._updateSpeed()

    def reverse(self):
        self._dirL = -1
        self._dirR = -1
        self._turnRatio = 1
        self._updateSpeed()

    def stop(self):
        self._leftCurrSpeed = 0
        self._rightCurrSpeed = 0

    def rotateLeft(self):
        self._dirL = -1
        self._dirR = 1
        self._turnRatio = 1
        self._updateSpeed()

    def rotateRight(self):
        self._dirL = 1
        self._dirR = -1
        self._turnRatio = 1
        self._updateSpeed()

    def turnLeft(self):
        self._turnRatio = 0.8
        self._updateSpeed()

    def turnRight(self):
        self._turnRatio = 1.2
        self._updateSpeed()

    def turn(self, turnRatio):
        if 0 < turnRatio < 2:
            self._turnRatio = turnRatio
            self._updateSpeed()

    def incrementSpeed(self):
        if self._baseSpeed > 9:
            self._baseSpeed += 10
            if self._baseSpeed > 100:
                self._baseSpeed = 100
        else:
            self._baseSpeed += 1

    def decrementSpeed(self):
        if self._baseSpeed > 10:
            self._baseSpeed -= 10
            if self._baseSpeed < 10:
                self._baseSpeed = 10
        else:
            self._baseSpeed -= 1
            if self._baseSpeed < 0:
                self._baseSpeed = 0

    def getStatus(self):
        return {"PWM": self.pwm, "BaseSpeed": self._baseSpeed, "LeftSpeed": self._leftCurrSpeed, "RightSpeed": self._rightCurrSpeed, "TurnRatio": self._turnRatio}
