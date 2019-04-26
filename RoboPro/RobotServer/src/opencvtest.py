
# import the necessary packages
from picamera.array import PiRGBArray
from picamera import PiCamera
import time
import cv2
import numpy as np
import middleware as mw
from pivideostream import PiVideoStream
from fps import FPS

# initialize the camera and grab a reference to the raw camera capture
#camera = PiCamera()
#camera.resolution = (320, 240)
#camera.framerate = 32
#rawCapture = PiRGBArray(camera, size=(320, 240))
camera = PiVideoStream().start()
counter = FPS()

# allow the camera to warmup
time.sleep(0.2)

motor = mw.MyMotor("/dev/ttyACM0", 115200)
motor.pwm = 50
# capture frames from the camera
#for frame in camera.capture_continuous(rawCapture, format="bgr", use_video_port=True):
counter.start()
posX = None
posY = None
radius = None

lower_lower_red = np.array([0, 100, 85])
lower_upper_red = np.array([10, 255, 255])

upper_lower_red = np.array([160, 100, 85])
upper_upper_red = np.array([179, 255, 255])
while True:
    # grab the raw NumPy array representing the image, then initialize the timestamp
    # and occupied/unoccupied text
    #image = frame.array
    image = camera.read()
    if posX is not None:
        image = image[max(posY-2*radius, 0):min(posY+2*radius, 240), max(posX-2*radius, 0):min(posX+2*radius, 320)]

    #cv2.medianBlur(image, 3, image)
    hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)


     # hsv = cv2.GaussianBlur(hsv, (9, 9), 2)

    mask_lower = cv2.inRange(hsv, lower_lower_red, lower_upper_red)
    mask_upper = cv2.inRange(hsv, upper_lower_red, upper_upper_red)
    
    #mask_red = cv2.inRange(hsv, upper_lower_red, lower_upper_red)
    
    mask_red = cv2.addWeighted(mask_upper, 1, mask_lower, 1, 0)
    mask_red = cv2.medianBlur(mask_red, 3)
    #kernel = np.ones((9, 9), np.uint8)
    #mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernel)
    #mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_CLOSE, kernel)

    circles = cv2.HoughCircles(mask_red, cv2.HOUGH_GRADIENT, 1, 20, param1=100, param2=10, minRadius=17, maxRadius=160)
    if circles is not None:
        circles = np.uint16(np.around(circles))
        i = circles[0, 0]
        posX = i[0]
        posY = i[1]
        radius = i[2]
        print("X: {} Y: {} r: {}".format(posX, posY, radius))
        if i[0] < mask_red.shape[1]/2 - mask_red.shape[1]/10:
            motor.baseSpeed = 35 # + -60 * (i[0] - mask_red.shape[1]/2 + mask_red.shape[1]/10)/(mask_red.shape[1]/2 - mask_red.shape[1]/10)
            motor.rotateRight()
        elif i[0] > mask_red.shape[1]/2 + mask_red.shape[1]/10:
            motor.baseSpeed = 35 # + 60 * (i[0] - mask_red.shape[1]/2 - mask_red.shape[1]/10) / (mask_red.shape[1]/2 - mask_red.shape[1]/10)
            motor.rotateLeft()
        else:
            motor.stop()
        # draw the outer circle
        #cv2.circle(image, (i[0], i[1]), i[2], (0, 255, 0), 2)
        # draw the center of the circle
        #cv2.circle(image, (i[0], i[1]), 2, (0, 255, 0), 3)
    else:
        motor.stop()
        posX = None
        posY = None
        radius = None

    counter.increment()
    if counter.elapsed() > 5:
        counter.stop()
        print(counter.fps())
        counter.start()
    # show the frame
    #cv2.imshow("Frame", image)
    #cv2.imshow("Red", mask_red)
    key = cv2.waitKey(1) & 0xFF

    # clear the stream in preparation for the next frame
    #rawCapture.truncate(0)

    # if the `q` key was pressed, break from the loop
    if key == ord("q"):
        break
