import serial
import time


class MyMotor(object):

    def __init__(self, serialport, baud=115200, logger = None):
        self.ser = serial.Serial(port=serialport, baudrate=baud)
        self._pwm = 1000
        self._baseSpeed = 80
        self._rightCurrSpeed = 0
        self._leftCurrSpeed = 0
        self._dirL = 1
        self._dirR = 1
        self._turnRatio = 1
        self._logger = logger
        self._led = 0
        self.getStatus()

    def _serial_write(self, msg):
        self.ser.write(str.encode(msg))
        self.ser.flush()
        self.ser.reset_input_buffer()
        if self._logger is not None:
            self._logger.log("Serial write: " + msg)
            while not self.ser.in_waiting > 0:
                continue

            while self.ser.in_waiting > 0:
                line = self.ser.readline().decode("utf-8")
                if self._logger is not None:
                    self._logger.log(line)
                if line[0:2] == "S:":
                    self._leftCurrSpeed = int(line[2:line.find(",")])
                    self._rightCurrSpeed = int(line[line.find(",")+1:])

                elif line[0:2] == "F:":
                    self._pwm = int(line[2:])
                elif line[0:2] == "L:":
                    self._led = int(line[2:])


    @property
    def pwm(self):
        return self._pwm

    @pwm.setter
    def pwm(self, pwm):
        self._pwm = pwm
        msg = "P:{}\n".format(self._pwm)
        self._serial_write(msg)

    @property
    def baseSpeed(self):
        return self._baseSpeed

    @baseSpeed.setter
    def baseSpeed(self, speed):
        self._baseSpeed = speed
        if self.isGoing():
            self._updateSpeed()

    def directSpeed(self, left, right):
        self._rightCurrSpeed = right
        self._leftCurrSpeed =left
        msg = "S:{0},{1}\n".format(self._leftCurrSpeed, self._rightCurrSpeed)
        self._serial_write(msg)

    def directMessage(self, msg):
        self._serial_write(msg)

    def _updateSpeed(self):
        self._rightCurrSpeed = self._dirR * self._baseSpeed * (2 - self._turnRatio)
        self._leftCurrSpeed = self._dirL * self._baseSpeed * self._turnRatio
        msg = "S:{0},{1}\n".format(self._leftCurrSpeed, self._rightCurrSpeed)
        self._serial_write(msg)

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
        self._dirL = 0
        self._dirR = 0
        self._updateSpeed()

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
        else:
            raise ValueError("Argument must be between 0 and 2")

    def incrementSpeed(self):
        if self._baseSpeed > 9:
            self._baseSpeed += 10
            if self._baseSpeed > 100:
                self._baseSpeed = 100
        else:
            self._baseSpeed += 1

        self._updateSpeed()

    def decrementSpeed(self):
        if self._baseSpeed > 10:
            self._baseSpeed -= 10
            if self._baseSpeed < 10:
                self._baseSpeed = 10
        else:
            self._baseSpeed -= 1
            if self._baseSpeed < 0:
                self._baseSpeed = 0

        self._updateSpeed()

    def getStatus(self):
        self._serial_write("?:")

        return {"PWM": self.pwm, "BaseSpeed": self._baseSpeed, "LeftSpeed": self._leftCurrSpeed, "RightSpeed": self._rightCurrSpeed, "TurnRatio": self._turnRatio}

    @property
    def led(self):
        return self._led

    @led.setter
    def led(self, led):
        self._led = led
        self._serial_write("L:"+led)
