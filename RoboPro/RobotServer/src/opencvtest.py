
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
# camera = PiCamera()
# camera.resolution = (320, 240)
# camera.framerate = 32
# rawCapture = PiRGBArray(camera, size=(320, 240))
width = 320
height = 240
distRef = 20

camera = PiVideoStream().start()
counter = FPS()

# allow the camera to warmup
time.sleep(0.2)

motor = mw.MyMotor("/dev/ttyACM0", 115200)
motor.pwm = 50
# capture frames from the camera
# for frame in camera.capture_continuous(rawCapture, format="bgr", use_video_port=True):
counter.start()
posX = None
posY = None
radius = None

distIntegral = 0
angleIntegral = 0

lower_lower_red = np.array([0, 100, 85])
lower_upper_red = np.array([10, 255, 255])

upper_lower_red = np.array([160, 100, 85])
upper_upper_red = np.array([179, 255, 255])
while True:
    # grab the raw NumPy array representing the image, then initialize the timestamp
    # and occupied/unoccupied text
    # image = frame.array
    #image = frame.array
    timings = {"total_time":time.time()}
    now_time = time.time()

    image = camera.read()
    if image is None:
        print("No image received")
        continue
    # if posX is not None:
    #    image = image[max(posY-2*radius, 0):min(posY+2*radius, 240), max(posX-2*radius, 0):min(posX+2*radius, 320)]

    timings["camera.read"] = time.time()-now_time
    now_time = time.time()

    # if posX is not None:
    #    image = image[max(posY-2*radius, 0):min(posY+2*radius, 240), max(posX-2*radius, 0):min(posX+2*radius, 320)]

    # cv2.medianBlur(image, 3, image)
    hsv = cv2.cvtColor(np.uint8(image), cv2.COLOR_BGR2HSV)

    timings["cv2.cvtColor"] = time.time()-now_time
    now_time = time.time()

     # hsv = cv2.GaussianBlur(hsv, (9, 9), 2)

    mask_lower = cv2.inRange(hsv, lower_lower_red, lower_upper_red)
    mask_upper = cv2.inRange(hsv, upper_lower_red, upper_upper_red)
    
    timings["2x cv2.inRange"] = time.time()-now_time
    now_time = time.time()

    #mask_red = cv2.inRange(hsv, upper_lower_red, lower_upper_red)
    
    mask_red = cv2.addWeighted(mask_upper, 1, mask_lower, 1, 0)

    timings["cv2.addWeighted"] = time.time()-now_time
    now_time = time.time()

    mask_red = cv2.medianBlur(mask_red, 3)

    timings["cv2.medianBlur"] = time.time()-now_time
    now_time = time.time()

    #kernel = np.ones((9, 9), np.uint8)
    #mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernel)
    #mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_CLOSE, kernel)

    circles = cv2.HoughCircles(mask_red, cv2.HOUGH_GRADIENT, 1, 20, param1=100, param2=10, minRadius=7, maxRadius=320)
    timings["cv2.HoughCircles"] = time.time()-now_time
    now_time = time.time()

    if circles is not None:
        circles = np.uint16(np.around(circles))
        i = circles[0, 0]
        posX = i[0]
        posY = i[1]
        radius = i[2]
        print("X: {} Y: {} r: {}".format(posX, posY, radius))

        distErr = distRef - radius
        angleErr = posX - width/2

        distIntegral += distErr
        angleErr += angleErr



        angleErr = width / 2 - posX
        speed = min(10 * distErr + 0 * distIntegral, 100)
        angleCorr = 1 * angleErr + 0 * angleIntegral
        motor.directSpeed(speed + angleCorr, speed - angleCorr)

        timings["motor control"] = time.time() - now_time
        now_time = time.time()
        # if i[0] < mask_red.shape[1]/2 - mask_red.shape[1]/10:
        #     motor.baseSpeed = 40 # + -60 * (i[0] - mask_red.shape[1]/2 + mask_red.shape[1]/10)/(mask_red.shape[1]/2 - mask_red.shape[1]/10)
        #     motor.rotateRight()
        # elif i[0] > mask_red.shape[1]/2 + mask_red.shape[1]/10:
        #     motor.baseSpeed = 40 # + 60 * (i[0] - mask_red.shape[1]/2 - mask_red.shape[1]/10) / (mask_red.shape[1]/2 - mask_red.shape[1]/10)
        #     motor.rotateLeft()
        # else:
        #     motor.stop()
        # draw the outer circle
        # cv2.circle(image, (i[0], i[1]), i[2], (0, 255, 0), 2)
        # draw the center of the circle
        # cv2.circle(image, (i[0], i[1]), 2, (0, 255, 0), 3)
    else:
        motor.stop()
        posX = None
        posY = None
        radius = None
        timings["motor stop"] = time.time() - now_time
        now_time = time.time()


    timings["total_time"] = time.time()- timings["total_time"]
   # print("Timings: " + '\t'.join(["%s= %fms"%(k,v*1000.0) for (k,v) in timings.items()]))
    counter.increment()
    if counter.elapsed() > 5:
        counter.stop()
        print(counter.fps())
        counter.start()
    # show the frame
    # cv2.imshow("Frame", image)
    # cv2.imshow("Red", mask_red)
    key = cv2.waitKey(1) & 0xFF

    # clear the stream in preparation for the next frame
    # rawCapture.truncate(0)

    # if the `q` key was pressed, break from the loop
    if key == ord("q"):
        break
