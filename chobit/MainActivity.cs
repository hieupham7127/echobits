using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Algorithms;
using System.Threading;
using System.Globalization;

/*
    To-do list in priority order:
    _Re-ebtablishing server whenever client is disconnected or vice versa
    _System.Console.Writeln must be moved to LOG
    _Redo feature by implementing a Stack and Up button pressed event 
    _Improve chatbot accuracy
    _Conceal password in SMTP
    _Paint should be changed to a creative Doodle
    _Redesign UI
*/


namespace eChobits {
    public partial class mainform : Form {
        public mainform() {
            InitializeComponent();
            InitializeVariable();
            InitializeNetwork();
            InitializeKey();
            InitializeEvent();
        }

        #region [Initialization]

        Music music;
        StringImplementation stringSyntax;
        StickyNote stickynote;

        SpeechSynthesizer synth;
        private void echo(string text) { synth.Speak(text); }

        void InitializeVariable() {
            music = new Music();
            stringSyntax = new StringImplementation();
            synth = new SpeechSynthesizer();
            stickynote = new StickyNote();
            // to change VoiceGender and VoiceAge check out those links below
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = -1;
            synth.Volume = 100;
        }

        // ------------------------------------------------------------------------------------------------------

        /*
        Recognize face of user, show box Yes & No to confirm with password
        Wait until it is confirmed by user, features unlocked
        Running asynchronously with FaceDetection class using BlockingCollection
        */
        Networking network;
        FaceDetection detector;
        /*
        Auto or ManualResetEvent is very important to Pause and Resume action (asynchronous), saving CPU cycles
        Ideally, there must be a queue to handle all thread without sleeping or waiting to save CPU cycles
        CPU cycles are mentioned in Machine Architecture. Please look up Hierarchy Memory Storage.
        */
        ManualResetEvent signalEvent = new ManualResetEvent(true);

        String name;
        const int OWNER_BINDING = 1;
        private void ThreadSafeUIBiding(int CODE, string name) {
            /*
            InvokeRequired required compares the thread ID of the
            calling thread to the thread ID of the creating thread.
            if these threads are different, it returns true. 
            */
            if (CODE == OWNER_BINDING) {
                owner = name;
                lbName.Visible = true;
                lbName.Text = "Hello, " + name + "!";
                tbPassword.Visible = true;
                lbResponse.Text = "Password is your birthday with format d/m/yy\nFor example: 201195";
                echo("Please enter your password");
                btYes.Visible = true;
                btNo.Visible = true;
            }
        }

        private string owner;
        void FaceDetectionThread(BlockingCollection<string> bc) {
            /*
            Cannot change GUI in a thread without cross-validation, this must be done in main thread
            Alternatives:
            1. Using safethread function
            2. Data binding for UI by calling Control.Invoke
            3. BackgroundWorker http://stackoverflow.com/questions/5037470/cross-thread-operation-not-valid
            4. Control.CheckForIllegalCrossThreadCalls = false; (not recommended, not usable by binding data to forms)
            */
            while (true) {
                signalEvent.WaitOne();
                try {
                    if (bc.TryTake(out name, TimeSpan.FromMilliseconds(100))) {
                        if (this.InvokeRequired) { // require invoking to bind data
                            this.Invoke(
                                new MethodInvoker(
                                    delegate () { ThreadSafeUIBiding(OWNER_BINDING, name); }));
                        }
                        detector.Pause();
                        signalEvent.Reset();
                    }
                }
                catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
            }
        }

        void InitializeNetwork() {
            network = new Networking();
            BlockingCollection<string> bc = new BlockingCollection<string>(boundedCapacity: 1);
            detector = new FaceDetection(network, bc);
            // advantage of passing parameters
            Thread detectThread = new Thread(() => FaceDetectionThread(bc));
            detectThread.Start();
        }

        // ------------------------------------------------------------------------------------------------------
        void InitializeEvent() {
            tbCommand.KeyDown += tbCommand_EnterClicked; // press Enter event
        }
        
        #endregion

        #region [KEYS Variables]
        private string[] KEYS_PAINT;
        private string[] KEYS_WRITE;
        private string[] KEYS_START;
        private string[] KEYS_NEXT;
        private string[] KEYS_END;
        private string[] KEYS_SMTP;
        private string[] KEYS_MUSIC;
        private string[] KEYS_IMAGE;
        private string[] KEYS_CONVERSION;
        private string[] KEYS_NOTE;
        private string[] KEYS_HELP;
        private string[] KEYS_EXIT;
        private string[] KEYS_NETWORK;

        void InitializeKey() {
            KEYS_PAINT = new string[] { "paint", "draw", "sketch", "doodle", "doodling" };
            KEYS_WRITE = new string[] { "write", "writing" };
            KEYS_START = new string[] { "connect", "ebstablish", "start", "begin", "play", "open", "turn on", "initialize" };
            KEYS_NEXT = new string[] { "next", "move", "another", "other"};
            KEYS_END = new string[] { "stop", "pause", "turn off", "end", "finish" };
            KEYS_SMTP = new string[] { "smtp", "mess", "sms", "msg"};
            KEYS_MUSIC = new string[] { "music", "song", "playlist"};
            KEYS_IMAGE = new string[] { "gallery", "picture", "pic", "image", "img" };
            KEYS_CONVERSION = new string[] { "convert", "transform", "conversion" };
            KEYS_NOTE = new string[] { "note", "diary" };
            KEYS_HELP = new string[] { "-h", "help" };
            KEYS_EXIT = new string[] { "exit", "quit", "ecs", "turn off" };
            KEYS_NETWORK = new string[] { "network", "localhost", "server" };
        }

        const string instruction = "-h, help: instruction\n" +
                                    "paint/draw/sketch: paint panel\n" +
                                    "play/next/pause + music: music playlist\n" +
                                    "smtp: send sms from pc to phone\n" +
                                    "open/start + gallery: open gallery\n" +
                                    "write + note/diary/letter: write, read & save notes\n" +
                                    "convert + img/image/pic: convert all images from a folder into icons";
        #endregion

        #region [Analyzing Text]
        /*
        this is a temporary solution for text recognition problem
        future solution: training set contains sentence of operations and responses (bag of words, distributed, vector space?)
        */
        void AnalyzingText(String command) {
            //network.SendMsgToServer(command);
            if (stringSyntax.AppearAny(command, KEYS_EXIT)) {
                Close();
            }
            else if (stringSyntax.AppearAny(command, KEYS_PAINT)) {
                lbResponse.Text = ("Have fun doodling!");
                Doodle paint = new Doodle();
                paint.Show();
            }
            else if (stringSyntax.AppearAny(command, KEYS_SMTP)) {
                SMTP stmp = new SMTP();
                stmp.Show();
            }
            else if (stringSyntax.AppearAny(command, KEYS_CONVERSION) && stringSyntax.AppearAny(command, KEYS_IMAGE)) {
                lbResponse.Text = ("Opening PNG to ICO Converter");
                echo(lbResponse.Text);
                ImageConversion conversion = new ImageConversion();
                conversion.Show();
            }
            else if (stringSyntax.AppearAny(command, KEYS_START) && stringSyntax.AppearAny(command, KEYS_IMAGE)) {
                lbResponse.Text = ("Opening Gallery");
                echo(lbResponse.Text);
                Gallery gallery = new Gallery();
                gallery.Show();
            }
            else if (stringSyntax.AppearAny(command, KEYS_WRITE) && stringSyntax.AppearAny(command, KEYS_NOTE)) {
                if (stringSyntax.Appear(command, "sticky")) {
                    lbResponse.Text = ("Opening Sticky Notes");
                    echo(lbResponse.Text);
                    stickynote.ShowAll();
                }
                else {
                    lbResponse.Text = ("Opening Notes");
                    echo(lbResponse.Text);
                    Note note = new Note();
                    note.Show();
                }
            }
            // Music
            else if (stringSyntax.AppearAny(command, KEYS_MUSIC)) {
                if (stringSyntax.AppearAny(command, KEYS_START)) {
                    lbResponse.Text = "Playing music";
                    echo(lbResponse.Text);
                    music.play();
                }
                else if (stringSyntax.AppearAny(command, KEYS_END)) {
                    lbResponse.Text = "Pausing";
                    echo(lbResponse.Text);
                    music.pause();
                }
                else if (stringSyntax.AppearAny(command, KEYS_NEXT)) {
                    lbResponse.Text = "Playing next song";
                    music.next();
                }
                lbResponse.Text = instruction;
            }
            // Networking
            else if (stringSyntax.AppearAny(command, KEYS_NETWORK)) {
                if (!detector.GetNetWork().IsAvailable()) {
                    lbResponse.Text = "Reconnecting to server.";
                    echo(lbResponse.Text);
                    network.HaltConnection();
                    InitializeNetwork();
                    if (network.IsAvailable()) {
                        lbResponse.Text = lbResponse.Text + " Connect Successfully.";
                    }
                    else lbResponse.Text = lbResponse.Text + " Attempt failed.";
                }
                else {
                    lbResponse.Text = "Network communication is running correctly!";
                }
            }
            // 
            else if (stringSyntax.AppearAny(command, KEYS_HELP)) {
                lbResponse.Text = instruction;
            }
            else lbResponse.Text = "Sorry, I don't understand that.";
            tbCommand.Text = "";
        }

        private void tbCommand_EnterClicked(object sender, KeyEventArgs e) { // Enter pressed event
            if (e.KeyCode == Keys.Enter) {
                AnalyzingText(((TextBox)sender).Text);
            }
        }
        #endregion

        #region [Events]
        private void mainform_Load(object sender, EventArgs e) {
            echo(lbResponse.Text);
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e) {
            stickynote.Save();
            network.HaltConnection();
            Environment.Exit(0);
        }

        private void lbResponse_TextChanged(object sender, EventArgs e) {
        }

        // buttons Yes and No are for logging into service
        private void btYes_Click(object sender, EventArgs e) {
            if (tbPassword.Text == "9695") {
                tbPassword.Visible = false;
                btYes.Visible = false;
                btNo.Visible = false;
                lbName.Text = "Welcome " + owner + "!";
                lbResponse.Text = instruction;
                echo(lbName.Text);
            }
            else echo("Password incorrect!");
        }

        private void btNo_Click(object sender, EventArgs e) {
            lbName.Visible = false;
            tbPassword.Visible = false;
            btYes.Visible = false;
            btNo.Visible = false;
            detector.Resume();
            signalEvent.Set();
        }

        private void btSpeech_Click(object sender, EventArgs e) {
            CultureInfo ci = new CultureInfo("en-us");
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(ci);
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            echo("Please wait");
            Thread.Sleep(1000);
            echo("Speak now!");
            try { 
                // recognize speech from voice
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                if (result != null) {
                    AnalyzingText(tbCommand.Text);
                    tbCommand.Text = result.Text;
                }
                else {
                    tbCommand.Text = "";
                    echo("Sorry, I couldn't catch that!");
                }
            }
            catch (InvalidOperationException exception) {
                echo("Could not recognize input from default audio device. Is your microphone available?");
                lbResponse.Text = String.Format("Could not recognize input from default audio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message);
            }
            finally {
                recognizer.UnloadAllGrammars();
            }
        }
        #endregion

        #region [Minimize View]
        private void mainform_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipText = "Chobit is minimzed!";
                notifyIcon.ShowBalloonTip(1000);
                ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            string text = e.ClickedItem.Text;
            string command = "";
            Form obj = null;
            switch (text) {
                case "Doodle":
                    obj = new Doodle();
                    break;
                case "SMTP":
                    obj = new SMTP();
                    break;
                case "Note":
                    obj = new Note();
                    break;
                case "Gallery":
                    obj = new Gallery();
                    break;
                case "Image Conversion":
                    obj = new ImageConversion();
                    break;
                case "Music":
                    command = "playing music";
                    break;
                case "Close":
                    this.Close();
                    break;
            }
            if (obj != null) obj.Show();
            else {
                tbCommand.Text = command;
                tbCommand.KeyDown += tbCommand_EnterClicked;
            }
        }
        #endregion
    }
}