using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace eChobits {
    class Networking {
        private TcpClient client;
        private Logging file;
        private NetworkStream stream;
        
        private String host;
        private int port;

        private bool isAvailable;        

        public Networking(String new_host = "localhost", int new_port = 9999) {
            this.host = new_host;
            this.port = new_port;
            file = new Logging(Logging.NETWORK_LOG);
            SetupSocketSender(host, port);
        }

        public bool IsAvailable() { return isAvailable; }

        public void SetupSocketSender(String host, int port) {
            try {
                client = new TcpClient(host, port);
                file.LOG("Connect Successfully to " + host + " - port " + port);
                stream = client.GetStream();
                file.LOG("Client is ready...");
                isAvailable = true;
            }
            catch (Exception e) {
                isAvailable = false;
                file.LOG(e.Message);
            }
        }

        public string ReceiveMsgFromServer() {
            // threading is import so that the program does not stop midway to receive msg
            try {
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesLength = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                string receivedMsg = Encoding.ASCII.GetString(bytesToRead, 0, bytesLength);
                file.LOG("Received [" + receivedMsg + "]");
                return receivedMsg;
            }
            catch (Exception e) {
                file.LOG(e.Message);
            }
            return null;
        }

        public string SendMsgToServer(String msg) {
            try {
                stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
                stream.Flush();
                file.LOG("Message [" + msg + "] sent...");
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesLength = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                string receivedMsg = Encoding.ASCII.GetString(bytesToRead, 0, bytesLength);
                file.LOG("Received [" + receivedMsg + "]");
                return receivedMsg;
            }
            catch (Exception e) {
                file.LOG(e.Message);
            }
            return null;
        }

        public void HaltConnection() {
            if (client != null) client.Close();
            file.LOG("Connection halted...");
            isAvailable = false;
            file.Close();
        }

    }
}
