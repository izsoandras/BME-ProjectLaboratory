import tornado.httpserver
import tornado.websocket
import tornado.ioloop
import tornado.web
import socket
import time
import serial

ser = serial.Serial(
    port ="/dev/ttyUSB0",
    baudrate = 115200
    )
buttons = [False, False, False, False]
accel = 0
steer = 0
 
class WSHandler(tornado.websocket.WebSocketHandler):
    def open(self):
        print ("Client connected")


    def on_message(self, message):
        print ('message received:  %s' % message)
        message = message.strip()
        cmdtype = message[:message.find(":")]
        params = message[message.find(":")+1:]
        params = params.split(",")
        
        #Determining the type of the message
        if cmdtype == "KB":
            #Determining the direction
            if params[0] == "W":
                index = 0
            elif params[0] == "A":
                index = 1
            elif params[0] == "S":
                index = 2
            elif params[0] == "D":
                index = 3
            else:
                self.write_message("Unknown 1st parameter")
                return

            #Determining the value
            if params[1] == "D":
                buttons[index] = True
            elif params[1] == "U":
                buttons[index] = False
            else:
                self.write_message("Unknown 2nd parameter")
                return
            print (buttons)

            #Perform the command
            if buttons[0] == buttons[2]:
                accel = 0
            elif buttons[0]:
                accel = 1
            else:
                accel = -1

            if buttons[1] == buttons[3]:
                steer = 0
            elif buttons[1]:
                steer = 1
            else:
                steer = -1

            if accel == 0:
                msg = "{leftEngine},{rightEngine}\n".format(leftEngine = -30*steer, rightEngine = 30*steer)
                ser.write(str.encode(msg))
                self.write_message("Serial write: " + msg)
            else:
                msg = "{leftEngine},{rightEngine}\n".format(leftEngine = accel*(30-5*steer), rightEngine = accel*(30+5*steer))
                ser.write(str.encode(msg))
                self.write_message("Serial write: " + msg)

            print(ser.readline())
            
        else:
            self.write_message("Unknown command type")


    def on_close(self):
        print ("Client left")
        ser.write(str.encode("0,0"))


    def check_origin(self, origin):
        return True


application = tornado.web.Application([
    (r'/', WSHandler),
])

 
if __name__ == "__main__":
    ser.write(str.encode('30,30'))
    time.sleep(1)
    ser.write(str.encode('0,0'))
    
    http_server = tornado.httpserver.HTTPServer(application)
    http_server.listen(8888)
    myIP = socket.gethostbyname(socket.gethostname())
    print ('*** Websocket Server Started at %s***' % myIP)
    tornado.ioloop.IOLoop.instance().start()
 
