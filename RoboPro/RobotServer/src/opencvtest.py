
# import the necessary packages
from picamera.array import PiRGBArray
from picamera import PiCamera
import time
import cv2
import numpy as np

# initialize the camera and grab a reference to the raw camera capture
camera = PiCamera()
camera.resolution = (640, 480)
camera.framerate = 32
rawCapture = PiRGBArray(camera, size=(640, 480))

# allow the camera to warmup
time.sleep(0.1)

# capture frames from the camera
for frame in camera.capture_continuous(rawCapture, format="bgr", use_video_port=True):
    # grab the raw NumPy array representing the image, then initialize the timestamp
    # and occupied/unoccupied text
    image = frame.array

    hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)

    lower_lower_red = np.array([0, 100, 100])
    lower_upper_red = np.array([10, 255, 255])

    upper_lower_red = np.array([160, 100, 100])
    upper_upper_red = np.array([179, 255, 255])

    mask_lower = cv2.inRange(hsv, lower_lower_red, lower_upper_red)
    mask_upper = cv2.inRange(hsv, upper_lower_red, upper_upper_red)



    # show the frame
    cv2.imshow("Frame", image)
    cv2.imshow("Lower red", mask_lower)
    cv2.imshow("Upper red", mask_upper)
    key = cv2.waitKey(1) & 0xFF

    # clear the stream in preparation for the next frame
    rawCapture.truncate(0)

    # if the `q` key was pressed, break from the loop
    if key == ord("q"):
        break
