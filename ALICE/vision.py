# OpenCV2 with Movement Capture and Face Detection technology libs
# credits go to the following contributors:
# my friend Khoa Ho and his team for Movement Detection
# https://github.com/shantnu/ for Face Detection
# http://hanzratech.in/2015/02/03/face-recognition-using-opencv.html for Face Recognition
# me for SOLVING MATH PROBLEMS, ADDING MORE AWESOME FEATURES and FIXING THEIR FREAKING CODES, so praise me more!
import cv2
import numpy as np
import os

from skimage import exposure, transform, img_as_float, img_as_ubyte
from gadget import strGenerator
from PIL import Image, ImageGrab
from time import sleep

KEY_ENTER = 13
KEY_ECS = 27
KEY_0 = 48

CASCADE_PATH = "ml_data/haarcascade_frontalface_default.xml";
IMGS_PATH = "ml_data/train_imgs";
FRAMES = 40

# Flip image in mirror effect
def flippedImage(image):
    if image is not None:
        flip_image = image.copy()
        flip_image = cv2.flip(image, 1)
    else:
        flip_image = img
    return flip_image

# Background subtraction and turn image to black & white
def blackWhiteImage(crop_img):
    gray = cv2.cvtColor(crop_img, cv2.COLOR_BGR2GRAY)
    value = (35, 35)
    blurred = cv2.GaussianBlur(gray, value, 0)
    _, thresh = cv2.threshold(blurred, 128, 255, cv2.THRESH_BINARY_INV | cv2.THRESH_OTSU)
    return thresh

# --------------------------------------------------------------------------------------
# two strings as args, naming the video capture
def movementCapture(firstScreen, secondScreen):
    #creating camera object
    cap = cv2.VideoCapture(0)
    timeOut = 1 / FRAMES
    while(cap.isOpened()) :    
        #reading frames
        ret, img = cap.read()
        # flip and animations
        img = flippedImage(img)
        cv2.rectangle(img, (100,100), (400,400), (0, 255, 0), 0)
        crop_img = img[100:400, 100:400]
        thresh = blackWhiteImage(crop_img)
        # press a key and check its condition
        key_pressed = cv2.waitKey(10)
        if key_pressed == KEY_ENTER:
            cv2.imwrite("ml_data/screenshot_{0}.png".format(strGenerator()), crop_img)
            #screenshot, color to black then back
            img[:, :, :] = 0
        elif key_pressed == KEY_ECS:
            break
        #displaying frames, below putText
        cv2.imshow(secondScreen, thresh)
        cv2.imshow(firstScreen, img) 
        sleep(timeOut)

# --------------------------------------------------------------------------------------
def faceDetect(img, faceCascade): 
    # the image is from cv2 with cvtColor set to COLOR_BGR2GRAY
    try:
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    except:
        gray = img

    # Detect faces in the image, k-nn
    faces = faceCascade.detectMultiScale(
        gray,
        scaleFactor=1.1,
        minNeighbors=5,
        minSize=(50, 50),
        flags = cv2.cv.CV_HAAR_SCALE_IMAGE
    )
    #print("Found {0} faces!".format(len(faces)))

    # Draw a rectangle around the faces
    for (x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x + w, y + h), (0, 255, 0), 2)

    return faces

def get_train_images(path, faceCascade):
    #append all the absolute image paths in a list image_paths
    paths = [os.path.join(path, f) for f in os.listdir(path)]
    imgs = []
    labels = []
    for path in paths:
        #get label of img
        label = int(os.path.split(path)[1].split(".")[0].replace("subject", "")) #format "subject01.sad" -> [01]        
        #read images and convert them to grayscale with PIL lib
        img = cv2.imread(path)
        img_pil = Image.fromarray(img).convert('L')
        img_gray = np.array(img_pil, "uint8")
        faces = faceDetect(img, faceCascade)
        # find max size image
        maxW = 0
        maxH = 0
        for (x, y, w, h) in faces:
            if (w * h > maxW * maxH):
                maxW = w
                maxH = h
        # add img to tuples, additional smaller frames are labelled as noise   
        for (x, y, w, h) in faces:
            if (w * h != maxW * maxH): continue
            imgs.append(img_gray[y: y + h, x: x + w])
            labels.append(label)
            #cv2.imshow("Adding faces to traning set...", img_gray[y: y + h, x: x + w]) 
            #cv2.waitKey(50)

    cv2.destroyAllWindows()
    #adding noise to dataset to detect noise
    
    return imgs, labels

def getRecognizer(images, labels):
    recognizer = cv2.createLBPHFaceRecognizer() #Local Binary Patterns Histograms Face Recognizer
    recognizer.train(images, np.array(labels))
    return recognizer

def faceRecognize(recognizer, img, faceCascade, arr):
    alpha = 0.90
    # face detection and recognition
    img_pil = Image.fromarray(img).convert('L')
    img_predict = np.array(img_pil, 'uint8')

    faces = faceDetect(img, faceCascade)
    if len(faces) > 0:             
        for (x, y, w, h) in faces:
            if (w * h < 8100): continue # filtering small images
            # displaying face img
            #cv2.imshow("Predict Image", img_predict[y: y + h, x: x + w])
            predicted, confidence = recognizer.predict(img_predict[y: y + h, x: x + w])
            #print "{0} is recognized with confidence {1}".format(predicted, confidence)
            # empirical experience says it requires a heuristic function, the higher the confidence, the less likely                
            arr[predicted] = arr[predicted] + (1 / confidence)
            # previous results decrease over time                
            predictedIter = 0
            for i in range(len(arr)):
                arr[i] = arr[i] * alpha
                if (arr[predictedIter] < arr[i]): predictedIter = i
            arr[0] = arr[0] * alpha
            if (predicted == 0 or (predictedIter != predicted)):
                return 0
            else: 
                return predictedIter
    return 0

result = ""
def getResult():
    return result

# one string as arg, naming the video capture
def realtimeFaceDetect(screen, names = None):
    # create the haar cascade, path is cascade xml file provided
    faceCascade = cv2.CascadeClassifier(CASCADE_PATH)
    train_imgs, labels = get_train_images(IMGS_PATH, faceCascade)
    #print(labels)
    arr = np.zeros(len(set(labels)) + 1)
    recognizer = getRecognizer(train_imgs, labels)

    # create camera object
    cap = cv2.VideoCapture(0)
    timeOut = 1 / FRAMES
    while(cap.isOpened()):    
        # read frames
        ret, img = cap.read()
        # flip and animations
        img = flippedImage(img)

        # press a key and check its condition
        key_pressed = cv2.waitKey(10)
        if key_pressed == KEY_ECS:
            break
        if key_pressed == KEY_ENTER:
            cv2.imwrite("ml_data/screenshot_{0}.png".format(strGenerator()), img)
            #screenshot, color to black then back
            img[:, :, :] = 0

        pos = faceRecognize(recognizer, img, faceCascade, arr)
        
        if names != None:
            global result
            result = names[pos]

        # displaying frames
        cv2.imshow(screen, img) 
        sleep(timeOut)

def screenCapture(screen):
    # create the haar cascade, path is cascade xml file provided
    faceCascade = cv2.CascadeClassifier(CASCADE_PATH)
    train_imgs, labels = get_train_images(IMGS_PATH, faceCascade)
    print(labels)
    arr = np.zeros(len(set(labels)) + 1)
    recognizer = getRecognizer(train_imgs, labels)
    timeOut = 1 / FRAMES
    while(True):    
        height = 450
        printscreen = ImageGrab.grab()
        printscreen = printscreen.resize((printscreen.size[0] / (printscreen.size[1] / height), height ), Image.ANTIALIAS)
        img = np.array(printscreen, dtype='uint8')

        # press a key and check its condition
        key_pressed = cv2.waitKey(10)
        if key_pressed == KEY_ECS:
            break
        if key_pressed == KEY_ENTER:
            cv2.imwrite("ml_data/screenshot_{0}.png".format(strGenerator()), img)
            #screenshot, color to black then back
            img[:, :, :] = 0

        faceRecognize(recognizer, img, faceCascade, arr)

        # displaying frames
        cv2.imshow(screen, img) 
        sleep(timeOut)