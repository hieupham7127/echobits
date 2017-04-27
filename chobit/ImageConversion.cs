using Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eChobits {
    public partial class ImageConversion : Form {
        public ImageConversion() {
            InitializeComponent();
        }

        private void btConvert_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                BitmapImplementation handler = new BitmapImplementation();
                foreach (string path in files)
                    if (path.Contains(".png")) handler.PngToIco(path);
                System.Windows.Forms.MessageBox.Show("Files found and converted: " + files.Length.ToString(), "Message");
            }
        }
    }
}
