using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eChobits {
    class Logging {
        private StreamWriter stream;
        public const int SYSTEM_LOG = 1;
        public const int NETWORK_LOG = 2;
        public const int NOTE_LOG = 3;

        private int CODE;
        /// <summary>
        /// parameter's public values for CODE are embeded in Logging class
        /// </summary>
        /// <param name="CODE"></param>
        public Logging(int CODE) {
            switch (CODE) {
                case SYSTEM_LOG:
                    stream = new StreamWriter("system_log.txt", true);
                    break;
                case NETWORK_LOG:
                    stream = new StreamWriter("connection_log.txt", true);
                    break;
                case NOTE_LOG:
                    stream = new StreamWriter("note_log.txt", true);
                    break;
            }
            this.CODE = CODE;
        }

        public void LOG(String msg) {
            try {
                stream.WriteLine(DateTime.Now.ToString("r") + ": " + msg);
            }
            catch (Exception e) { }
        }

        public void Close() {
            stream.Close();
        }

    }
}
