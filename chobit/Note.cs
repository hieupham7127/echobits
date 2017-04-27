using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eChobits {
    /* 
        _considering switching to sticky notes
        _autosave when inputing: done 
    */


    public partial class Note : Form {
        Logging file;
        string[] letters;
        private string PATH = Application.StartupPath + "\\notes";

        public Note() {
            InitializeComponent();
            file = new Logging(Logging.SYSTEM_LOG);
        }

        string getNameFromPath(string path) {
            string name = "";
            for (int j = path.Length - 1; j > 0; j--)
                if (path[j] != '\\') name = path[j] + name; else break;
            return name.Remove(name.Length - 4);
        }

        void InitializeInterface() {
            letters = System.IO.Directory.GetFiles(PATH);
            lvLetter.Clear();
            ilLetter.ImageSize = new Size(200, 150);
            ilLetter.ColorDepth = ColorDepth.Depth32Bit;
            // get letter image
            int i;
            for (i = 0; i < letters.Length; i++) {
                if (letters[i].Contains(".jpg")) {
                    var temp = Image.FromFile(letters[i]);
                    Bitmap pic = new Bitmap(200, 150);
                    using (Graphics g = Graphics.FromImage(pic)) {
                        g.DrawImage(temp, new Rectangle(0, 0, pic.Width, pic.Height));
                    }
                    // dispose img every time we use
                    temp.Dispose();
                    ilLetter.Images.Add(pic);
                }
            }
            // get list of txt files
            i = 0;
            foreach (string letter in letters) {
                if (letter.Contains(".txt")) {
                    ListViewItem list = new ListViewItem(getNameFromPath(letter));
                    list.ImageIndex = i;
                    list.ForeColor = Color.Purple;
                    lvLetter.Items.Add(list);
                    i++;
                }
            }
        }

        private void Note_Load(object sender, EventArgs e) {
            InitializeInterface();
        }

        private void lvLetter_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvLetter.SelectedItems.Count == 0) return;
            string name = lvLetter.SelectedItems[0].Text;
            foreach (string letter in letters)
                if (letter.Contains(name)) {
                    try {
                        string text = System.IO.File.ReadAllText(letter);
                        tbLetter.Text = text;
                    }
                    catch (Exception exception) {
                        file.LOG(exception.Message);
                    }
                }
        }

        private void btAdd_Click(object sender, EventArgs e) {
            try {
                System.IO.File.Create(PATH + "\\" + tbName.Text + ".txt");
                InitializeInterface();
            }
            catch(Exception exception) {
                file.LOG(exception.Message);
            }
        }

        private void btRemove_Click(object sender, EventArgs e) {
            if (lvLetter.SelectedItems.Count == 0) return;
            string name = lvLetter.SelectedItems[0].Text;
            foreach (string letter in letters)
                if (letter.Contains(".txt") && getNameFromPath(letter) == name) {
                    try { 
                        System.IO.File.Delete(letter);
                    }
                    catch (Exception exception) {
                        file.LOG(exception.Message);
                    }
            break;
                }
            InitializeInterface();
        }

        private void tbLetter_TextChanged(object sender, EventArgs e) {
            if (lvLetter.SelectedItems.Count == 0) return;
            string name = lvLetter.SelectedItems[0].Text;
            foreach (string letter in letters)
                if (letter.Contains(".txt") && getNameFromPath(letter) == name) {
                    try {
                        System.IO.File.WriteAllText(letter, tbLetter.Text);
                    }
                    catch (Exception exception) {
                        file.LOG(exception.Message);
                    }
                }

        }

        private void lbName_Click(object sender, EventArgs e) {
            tbLetter.Text = "";
        }
    }
}
