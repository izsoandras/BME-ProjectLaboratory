import tornado.httpserver
import tornado.websocket
import tornado.ioloop
import tornado.web
import socket
import time
import serial
import middleware
import mylogger

ser = serial.Serial(
    port ="/dev/ttyACM0",
    baudrate = 115200
    )

logger = mylogger.MyLogger( "/dev/ttyACM0", 115200)
motor = middleware.MyMotor("/dev/ttyACM0", 115200, logger)

buttons = [False, False, False, False]
index = 0
accel = 0
steer = 0

pwm = 1000
leftMotor = 80
rightMotor = 80


class WSHandler(tornado.websocket.WebSocketHandler):
    def open(self):
        print ("Client connected")
        logger.WSconnections.add(self)
        self.write_message("Welcome")

    def on_message(self, message):
        print ('message received:  %s' % message)
        message = message.strip()
        cmdtype = message[:message.find(":")]
        params = message[message.find(":")+1:]
        params = params.split(",")
        print("Command: " + cmdtype)
        # Determining the type of the message
        if cmdtype == "KB":
            global index
            global pwm
            global leftMotor
            global rightMotor
            # Determining the direction
            if params[0] == "+" and params[1] == "U":
                motor.incrementSpeed()
            elif params[0] == "-" and params[1] == "U":
                motor.decrementSpeed()
            else:
                if params[0] == "W":
                    index = 0
                elif params[0] == "A":
                    index = 1
                elif params[0] == "S":
                    index = 2
                elif params[0] == "D":
                    index = 3
                else:
                    logger.log("Unknown 1st parameter")
                    return


                # Determining the value
                if params[1] == "D":
                    buttons[index] = True
                elif params[1] == "U":
                    buttons[index] = False
                else:
                    logger.log("Unknown 2nd parameter")
                    return
                print(buttons)

                # Perform the command
                # If both or neither of W, S is pressed
                if buttons[0] == buttons[2]:
                    # If both or neither of A, D is pressed
                    if buttons[1] == buttons[3]:
                        motor.stop()
                    # If A is pressed
                    elif buttons[1]:
                        motor.rotateLeft()
                    # If B is pressed
                    else:
                        motor.rotateRight()
                elif buttons[0]:
                    if buttons[1] == buttons[3]:
                        motor.forward()
                    elif buttons[1]:
                        motor.forward()
                        motor.turnLeft()
                    else:
                        motor.forward()
                        motor.turnRight()
                else:
                    if buttons[1] == buttons[3]:
                        motor.reverse()
                    elif buttons[1]:
                        motor.reverse()
                        motor.turnLeft()
                    else:
                        motor.reverse()
                        motor.turnRight()


                
            self.write_message("Handled keyboard event")

        # command sent right to the motor controller
        elif cmdtype == "SR":
            msg = message[message.find(":")+1:] + "\n"
            motor.directMessage(msg)
        elif cmdtype == "?":
            motor.getStatus()
        # command that we can not recognize
        else:
            logger.log("Unknown command type")
            
        while ser.in_waiting > 0:
            msg = ser.readline()
            print(msg)
            logger.log("Serial read: " + ser.readline().decode('UTF-8'))

    def on_close(self):
        print ("Client left")
        motor.stop()
        logger.WSconnections.remove(self)

    def check_origin(self, origin):
        return True


application = tornado.web.Application([
    (r'/', WSHandler),
])

 
if __name__ == "__main__":
    # ser.write(str.encode('S:40,40'))
    # time.sleep()
    # ser.write(str.encode('S:0,0'))
    while ser.in_waiting > 0:
        msg = ser.readline()
        print(msg)
        logger.log("Serial read: " + ser.readline().decode("utf-8"))
    
    http_server = tornado.httpserver.HTTPServer(application)
    http_server.listen(8888)
    myIP = socket.gethostbyname(socket.gethostname())
    print ('*** Websocket Server Started at %s***' % myIP)
    tornado.ioloop.IOLoop.instance().start()



