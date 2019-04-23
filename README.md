# BME-ProjectLaboratory
A Raspberry Pi based measurement taking robot, being made for the Project Laboratory subject on the university. At first you will be able to control the robot from the desktop app on the basis of te Raspberry Pi Camera's video stream. During further developement an OpenCV based autonomous operation will be implemented.

We will also equip the robot with various sensors, eg.: giro, accelerometer, magnetometer and a BME280 integrated air humidity-pressure-temperature sensor.

The communication between the desktop client and the robot will be implemented using the Web Sockets protocol.

## Motor controller
To control the two DC motors the project is using Wemos D1 mini developement board. This is not because of the built in WiFi capability, but because of the small size and (relatively) low current consumption. The board's V1.0.0 motor shield is connected, to produce the PWM signal for the motors. At the current state of developement an adaptive motor control algorithm is under developement. 

*Due to an error, the motor controller is replaced with an Arduino UNO and al L298N H-bridge*

## Client application
A desktop application, running on Windows Forms technology, to observe and control the robot remotely. The user can define the URL on which the video stream is available, and the one belonging to the Web Socket server. Sending Web Socket messages is also possible from the Windows Forms application. For easier developement & debug the user is available to send commands to the motor controller directly, if it's connected through one of the COM ports.
