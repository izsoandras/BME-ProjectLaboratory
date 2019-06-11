# import the necessary packages
from picamera.array import PiRGBArray
from picamera import PiCamera
import time
import cv2
import numpy as np
import middleware as mw
import RPi.GPIO as GPIO
from pivideostream import PiVideoStream
from fps import FPS


def signum(a):
    return -1 if a < 0 else 1


SET_GUI = False
DEBUG_MOTORSPEED = False
DEBUG_TIMING = False
DEBUG_CIRCLEPOS = False

motor = mw.MyMotor("/dev/ttyACM0", 115200)
motor.pwm = 50

# initialize the camera
width = 320
height = 240
distRef = 20
camera = PiVideoStream((width, height), 30).start()
counter = FPS()
counter.start()
# allow the camera to warmup capture frames from the camera
time.sleep(0.5)

# controller variables
posX = None
posX_prev = 0
posY = None
radius = None
radius_prev = 0
speed = 0
angleCorr = 0
roi = None

angleErr = 0
distErr = 0
distIntegral = 0
angleIntegral = 0
distDeriv = 0
angleDeriv = 0
Kp_dist = 6
Ki_dist = 0
Kd_dist = 0
Kp_angle = 0.4
Ki_angle = 20
Kd_angle = 0
last_circle_time = 0
last_movement_time = time.time()

# red filter values
red_lower_max_h = 10  # hue -> color
red_upper_min_h = 160  # hue -> color
red_min_s = 100  # saturation -> white - colorful
red_min_v = 100  # value -> black - birght

GPIO.setmode(GPIO.BCM)
GPIO.setup(26, GPIO.OUT)
GPIO.output(26, GPIO.LOW)
GPIO.setup(19, GPIO.OUT)
GPIO.output(19, GPIO.LOW)
gpioFrame = False

if SET_GUI:
    main_window = "Camera image"
    cv2.namedWindow(main_window)


def on_trackbar_min_s(val):
    global red_min_s
    red_min_s = val


def on_trackbar_min_v(val):
    global red_min_v
    red_min_v = val


def on_trackbar_lower_max_h(val):
    global red_lower_max_h
    red_lower_max_h = val


def on_trackbar_upper_min_h(val):
    global red_upper_min_h
    red_upper_min_h = val


if SET_GUI:
    cv2.createTrackbar("Upper red min H:", main_window, 0, 179, on_trackbar_upper_min_h)
    cv2.createTrackbar("Lower red max H:", main_window, 0, 179, on_trackbar_lower_max_h)
    cv2.createTrackbar("Red min S:", main_window, 0, 255, on_trackbar_min_s)
    cv2.createTrackbar("Red min V:", main_window, 0, 255, on_trackbar_min_v)

# image process loop
while True:
    # remember the time for profiling
    if DEBUG_TIMING:
        timings = {"total_time": time.time()}
        now_time = time.time()

    # read the image from the camera
    image = camera.read()
    if image is None:
        print("No image received")
        continue

    gpioFrame = not gpioFrame
    GPIO.output(19, GPIO.HIGH if gpioFrame else GPIO.LOW)

    if DEBUG_TIMING:
        timings["camera.read"] = time.time() - now_time
        now_time = time.time()

    # TODO: ROI
    # if posX is not None:
    #     image = image[max(posY-2*radius, 0):min(posY+2*radius, height), max(posX-2*radius, 0):min(posX+2*radius, width)]

    # switch to HSV colorspace for easier color filter
    hsv = cv2.cvtColor(np.uint8(image), cv2.COLOR_BGR2HSV)

    if DEBUG_TIMING:
        timings["cv2.cvtColor"] = time.time() - now_time
        now_time = time.time()


    # filter the 2 red parts of colorspace
    mask_lower = cv2.inRange(hsv, np.array([0, red_min_s, red_min_v]), np.array([red_lower_max_h, 255, 255]))
    mask_upper = cv2.inRange(hsv, np.array([red_upper_min_h, red_min_s, red_min_v]), np.array([179, 255, 255]))

    if DEBUG_TIMING:
        timings["2x cv2.inRange"] = time.time() - now_time
        now_time = time.time()

    # unite the two red parts
    mask_red = cv2.addWeighted(mask_upper, 1, mask_lower, 1, 0)
    # mask_red = cv2.inRange(hsv, np.array([80, 100, 120]), np.array([100, 255, 255]))

    if DEBUG_TIMING:
        timings["cv2.addWeighted"] = time.time() - now_time
        now_time = time.time()

    # median blur for better recognition
    mask_red = cv2.medianBlur(mask_red, 3)

    if DEBUG_TIMING:
        timings["cv2.medianBlur"] = time.time() - now_time
        now_time = time.time()

    # erosion and dilation - removed for extra speed
    # kernel = np.ones((9, 9), np.uint8)
    # mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernel)
    # mask_red = cv2.morphologyEx(mask_red, cv2.MORPH_CLOSE, kernel)

    # find circles
    circles = cv2.HoughCircles(mask_red, cv2.HOUGH_GRADIENT, 1, 20, param1=100, param2=10, minRadius=7, maxRadius=320)

    if DEBUG_TIMING:
        timings["cv2.HoughCircles (red)"] = time.time() - now_time
        now_time = time.time()

    # control the robot according to the measures
    if circles is not None:  # or time.time() - last_circle_time < 3:
        if circles is not None:
            last_circle_time = time.time()
            circles = np.uint16(np.around(circles))
            i = circles[0, 0]
            posX = i[0]
            posY = i[1]
            radius = i[2]
            if DEBUG_CIRCLEPOS:
                print("X: {}\tY: {}\tr: {}\t".format(posX, posY, radius))

            xLower = max(posX - int(1.5 * radius), 0)
            xHigher = min(posX + int(1.5 * radius), width - 1)
            yLower = max(posY - int(1.5 * radius), 0)
            yHigher = min(posY + int(1.5 * radius), height - 1)
            roi = cv2.cvtColor(image[yLower: yHigher,
                               xLower: xHigher], cv2.COLOR_BGR2GRAY)

            if DEBUG_TIMING:
                timings["ROI"] = time.time() - now_time
                now_time = time.time()

            if SET_GUI:
                # draw the outer circle
                cv2.circle(image, (posX, posY), radius, (0, 0, 0), 2)
                # draw the center of the circle
                cv2.circle(image, (posX, posY), 2, (0, 0, 0), 3)

            if roi is not None:
                graycircles = cv2.HoughCircles(roi, cv2.HOUGH_GRADIENT, 1, 20, param1=100, param2=80,
                                               minRadius=int(0.7 * radius), maxRadius=2 * radius)

                if DEBUG_TIMING:
                    timings["cv2.HoughCircles (grayscale)"] = time.time() - now_time
                    now_time = time.time()

                if graycircles is not None:
                    j = graycircles[0, 0]
                    posX = xLower + j[0]
                    posY = yLower + j[1]
                    radius = j[2]
                    if DEBUG_CIRCLEPOS:
                        print("\tX: {}\tY: {}\tr: {}\t".format(posX, posY, radius))

            GPIO.output(26, GPIO.HIGH)

            # exp avg for noise reduction
            radius = 0.8 * radius_prev + 0.2 * radius
            posX = 0.8 * posX_prev + 0.2 * posX

            # calculate PID parameters
            distErr = distRef - radius
            distIntegral += distErr
            angleErr = width / 2 - posX
            angleIntegral += angleErr

            # calculate control values
            speed = min(Kp_dist * distErr, 100)
            angleCorr = Kp_angle * angleErr
        else:
            GPIO.output(26, GPIO.LOW)

        # control
        motor.directSpeed(speed + angleCorr, speed - angleCorr)
        last_movement_time = time.time()

        # save for next iteration
        radius_prev = radius
        posX_prev = posX

        if DEBUG_TIMING:
            timings["motor control"] = time.time() - now_time
            now_time = time.time()

        if SET_GUI:
            # draw the outer circle
            cv2.circle(image, (int(posX), int(posY)), int(radius), (0, 255, 0), 2)
            # draw the center of the circle
            cv2.circle(image, (int(posX), int(posY)), 2, (0, 255, 0), 3)

        # if graycircles is not None:
        #    cv2.circle(gray, (j[0], j[1]), j[2], (0, 255, 0), 2)
        #    cv2.circle(gray, (j[0], j[1]), 2, (0, 255, 0), 3)

        # if there is no circle on image
    else:
        GPIO.output(26, GPIO.LOW)
        if 5 < time.time() - last_movement_time < 12:
            motor.directSpeed(signum(angleErr) * 40, signum(angleErr) * -40)
            if DEBUG_MOTORSPEED:
                print("S:{},{}".format(signum(angleErr) * 40, signum(angleErr) * -40))
        else:
            motor.stop()
            posX = None
            posY = None
            radius = None
            if DEBUG_TIMING:
                timings["motor stop"] = time.time() - now_time
                now_time = time.time()

    if DEBUG_TIMING:
        timings["total_time"] = time.time() - timings["total_time"]
        print("Timings: " + '\t'.join(["%s= %fms"%(k,v*1000.0) for (k,v) in timings.items()]))

    #
    # counter.increment()
    # if counter.elapsed() > 5:
    #     counter.stop()
    #     print(counter.fps())
    #     counter.start()

    if SET_GUI:
        # show the frame
        cv2.imshow(main_window, image)
        cv2.imshow("HSV", hsv)
        cv2.imshow("Red", mask_red)
        if roi is not None:
            cv2.imshow("roi", roi)

    key = cv2.waitKey(1) & 0xFF

    # clear the stream in preparation for the next frame
    # rawCapture.truncate(0)

    # if the `q` key was pressed, break from the loop
    if key == ord("q"):
        GPIO.cleanup()
        break
