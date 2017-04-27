using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace eChobits {
    class FaceDetection {
        /*
        Description
        Call to Python script for face detection then transfer data through:
        1. Server - Client traditional way <- need to think of a model for different machine learning methods
        2. Running thread checking for data file (remember try catch)
        Remember to check for similarity between new detected image and owner's dataset
        */
        private String name;
        private Networking network;
        private BlockingCollection<string> bc;
        private ManualResetEvent signalEvent = new ManualResetEvent(true);
        private Thread recognizer;

        private bool isPause;

        private const int FACE_REG = 9695;
        private const int NULL_RES = -1;

        public FaceDetection(Networking network, BlockingCollection<string> bc) {
            this.network = network;
            this.bc = bc;
            this.name = null;
            this.isPause = true;

            recognizer = new Thread(RecognizerThread);
            recognizer.Start();
        }

        private void RecognizerThread() {
            String receivedMsg;
            while (network.IsAvailable()) {
                try {
                    signalEvent.WaitOne();
                    receivedMsg = network.SendMsgToServer("" + FACE_REG);
                    if (receivedMsg != null && receivedMsg != NULL_RES.ToString()) {
                        if (bc.TryAdd(receivedMsg, TimeSpan.FromMilliseconds(100))) {
                            System.Console.WriteLine("{0} added successfully. Current amount: {1}", receivedMsg, bc.Count);
                        }
                        else {
                            System.Console.WriteLine("Failed to add {0}", receivedMsg);
                        }
                    }
                }
                catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
                /*
                Using Thread.Sleep is an example of wasting CPU cycles
                DRAM will waste about ~1bil in 1sec of waiting thread, which costs a substantial amount 
                A suggestion is to let the thread execute something else instead, which should look like:
                Thread-Running [ 3, 1, 5 ]
                Thread-Waiting [ 2, 6 ] -> assign new tasks
                Thread-Killed ~ 0, 4
                */
                Thread.Sleep(1000);
            }
        }


        public Networking GetNetWork() { return this.network; }
        public void SetNetWork(Networking network) { this.network = network; }

        public String GetName() { return this.name; }
        public void SetName(String name) { this.name = name; }
        
        public void Pause() { signalEvent.Reset(); }
        public void Resume() { signalEvent.Set(); }

    }
}
