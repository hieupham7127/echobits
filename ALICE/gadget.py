from hashlib import sha256
import string
import random

def hashObject(obj, length = 7):
	int(sha256(obj).hexdigest(), 16) % (10 ** length) #10**length=10^length

def strGenerator(length = 7, chars = string.ascii_lowercase + string.ascii_uppercase + string.digits):
	return ''.join(random.SystemRandom().choice(chars) for _ in range(length))