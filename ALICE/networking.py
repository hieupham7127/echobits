import sys
import threading

from time import sleep
from socket import *

# exit connection
def haltConnection(connection = None, msg = None, sys_val = 0):
	if connection: connection.close()
	if msg: print msg
	sys.exit(sys_val)

Q_MAX = 20
def setupSocketListener(name, host = "", port = 0):
	print "{0}:{1}".format(str(host), str(port))
	try:
		# create socket object, SOCK_STREAM for TCP	
		sock = socket(AF_INET, SOCK_STREAM)
		sock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
		print name + " is listening..."
	except:
		haltConnection(msg = "Socket not opened. " + name + " exit")

	try:
		# bind socket arg[0] to host, arg[1] to port
		sock.bind((host, port))
		host = sock.getsockname()[0];
		port = sock.getsockname()[1];
		# listener, Q_MAX = max # of connections
		sock.listen(Q_MAX)
	except error as msg:
		haltConnection(sock, msg)
	return sock, host, port

def setupSocketSender(name, host, port):
	try:
		sock = socket(AF_INET, SOCK_STREAM)
	except:
		haltConnection(msg = "Socket not opened. " + exit + " name", sys_val = 1)
		
	# set up connection
	try:
		sock.connect((host,port))
	except:
		haltConnection(sock, "Socket not connected. " + name + " exit")

	print name + " is running..."
	return sock