import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)
GPIO.setup(23, GPIO.OUT)
GPIO.output(23, GPIO.HIGH)

time.sleep(3)

GPIO.output(23, GPIO.LOW)
GPIO.cleanup()
