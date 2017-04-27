using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace eChobits {
    public partial class StickyNoteForm : Form {
        public StickyNoteForm() {
            InitializeComponent();
        }

        public StickyNoteForm(Point location, Size size, Color color, String content) {
            // child forms are not usuable before initialization
            InitializeComponent();            
            this.StartPosition = FormStartPosition.Manual; // this line is very important for setting initial location           
            this.Location = location;
            this.Size = size;
            this.tbContent.BackColor = color;
            this.tbContent.Text = content;
        }

        /*
        */
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x84) {
                base.WndProc(ref m);
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)0x2;
            }
            else base.WndProc(ref m);
        }
        
        public static string PATH = Application.StartupPath + "\\stickynotes\\allnotes.xml";
        public static Color[] color_list = { Color.Pink, Color.LightYellow, Color.Orange,
                                             Color.Violet, Color.Blue, Color.Bisque };
        public Color GetBackColor() { return tbContent.BackColor; }
        public String GetContent() { return tbContent.Text; }

        private void StickyNote_Load(object sender, EventArgs e) {
            Image image = Image.FromFile(Application.StartupPath + "\\res\\options.png");
            Size size = new Size(25, 25);
            /*
            setting transparent image on panel, then add lb on top of it with same size
            this is because we cannot set Stretch layout for Label or transparent background for Button
            */
            pnOptions.Size = size;  
            pnOptions.BackgroundImage = image;
            pnOptions.BackgroundImageLayout = ImageLayout.Stretch;
            lbOptions.Size = size;
            lbOptions.Parent = pnOptions;
            lbOptions.BackColor = Color.Transparent;
        }

        private void lbAdd_Click(object sender, EventArgs e) {
            StickyNoteForm note = new StickyNoteForm();
            StickyNote.list.Add(note);
            note.Show();
        }

        private void tbContent_TextChanged(object sender, EventArgs e) {
            //content = ((TextBox)sender).Text;
        }

        private void lbOptions_Click(object sender, EventArgs e) {
            foreach (StickyNoteForm note in StickyNote.list)
                if (note == this) {
                    StickyNote.list.Remove(note);
                    break;
                }
            Close();
        }


    }
}
