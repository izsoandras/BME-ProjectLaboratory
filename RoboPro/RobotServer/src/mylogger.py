class MyLogger(object):

    def __init__(self, serialport, baud=115200):
        self.WSconnections = set()

    def log(self, msg):
        print(msg)
        for connection in self.WSconnections:
            connection.write_message(msg)
