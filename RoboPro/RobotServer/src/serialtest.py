import serial


ser = serial.Serial(
    port ="/dev/ttyACM0",
    baudrate = 115200
    )
while True:
    ser.write(str.encode("S:30,30\n"))
    ser.write(str.encode("S:60,60\n"))
    print(ser.readline())
