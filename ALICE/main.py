import os
import threading
import vision as vs

from networking import *

P_SIZE = 4096
FACE_REG = 9695
NULL_RES = -1

def Server(connection):
	packet = ""
	while True:
		data = connection.recv(P_SIZE).decode()
		if data:
			print data
			if int(data) == FACE_REG:
				name = vs.getResult()
				if name != "Not recognized":
					connection.send(name.encode())
				else: connection.send(str(NULL_RES).encode())
		else:
			# wait a bit for the next message
			sleep(0.1)

def runServer(host = "", port = 0):
	serverSock, host, port = setupSocketListener("Server", host, port)
	connectionSock, addr = serverSock.accept()
	server = threading.Thread(target = Server, args = [connectionSock])
	server.start()

def monitorCommand():
	# don't set up any client in python or connection will be aborted in C#
	while True:
		command = raw_input()
		if command == "exit":
			os.kill(os.getpid(), 9)

# Face Recognizer
def recognizerThread():
	vs.realtimeFaceDetect("ALICE", ["Not recognized", "Master"])
recognizer = threading.Thread(target = recognizerThread, args=())
recognizer.start()

####### Everything starts here #######
# TCP/IP Communication
f = open("res/connect.txt", "r")
host, port = f.read().split()

monitor = threading.Thread(target = monitorCommand, args=())
monitor.start()
runServer(host, int(port))
