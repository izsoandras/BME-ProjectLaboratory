# BME-ProjectLaboratory
A Raspberry Pi based measurement taking robot, being made for the Project Laboratory subject on the university. At first you will be able to control the robot from the desktop app on the basis of te Raspberry Pi Camera's video stream. During further developement an OpenCV based autonomous operation will be implemented.

We will also equip the robot with various sensors, eg.: giro, accelerometer, magnetometer and a BME280 integrated air humidity-pressure-temperature sensor.

The communication between the desktop client and the robot will be implemented using the Web Sockets protocol.

## Desktop application
A desktop application, running on Windows Forms technology, to observe and control the robot remotely. The user can define the URL on which the video stream is accessed, and the one belonging to the Web Socket server. Sending Web Socket messages is also possible from the Windows Forms application.
