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
    public partial class Gallery : Form {
        public Gallery() {
            InitializeComponent();
        }

        string[] gallery;
        Timer timer;
        private void Gallery_Load(object sender, EventArgs e) {
            //lvGallery.View = View.LargeIcon;
            //lvGallery.Columns.Add("" + ilPics.Images.Count);
            //lvGallery.LargeImageList = ilPics;
            gallery = System.IO.Directory.GetFiles(Application.StartupPath + "\\pics");
            ilPics.ImageSize = new Size(200, 200);
            ilPics.ColorDepth = ColorDepth.Depth32Bit;
            /* when are too many pics, adding a timer solve the problem of loading
            for (int i = 0; i < gallery.Length; i++) {
                if (gallery[i].Contains(".jpg") || gallery[i].Contains(".JPG") || gallery[i].Contains(".png")) {
                    var temp = Image.FromFile(gallery[i]);
                    float ratio = (float)temp.Width / temp.Height;
                    int w, h;
                    if (250 / ratio <= 250) {
                        w = 250;
                        h = (int)(w / ratio);
                    }
                    else {
                        h = 250;
                        w = (int)(h * ratio);
                    }
                    Bitmap pic = new Bitmap(w + (250 - w) / 2, h + (250 - h) / 2);
                    using (Graphics g = Graphics.FromImage(pic)) {
                        g.DrawImage(temp, new Rectangle((250 - w) / 2, (250 - h) / 2, w, h));
                    }

                    ilPics.Images.Add(pic);
                    temp.Dispose();
                    ListViewItem list = new ListViewItem();
                    list.ImageIndex = i;
                    lvGallery.Items.Add(list);
                }
            }*/
            
            // timer
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Start();
        }

        int i = 0;
        private void TimerEventProcessor(object sender, EventArgs e) {
            i++;
            if (gallery[i].Contains(".jpg") || gallery[i].Contains(".JPG") || gallery[i].Contains(".png")) {
                var temp = Image.FromFile(gallery[i]);
                float ratio = (float)temp.Width / temp.Height;
                int w, h;
                if (250 / ratio <= 250) {
                    w = 250;
                    h = (int)(w / ratio);
                }
                else {
                    h = 250;
                    w = (int)(h * ratio);
                }
                Bitmap pic = new Bitmap(w + (250 - w) / 2, h + (250 - h) / 2);
                using (Graphics g = Graphics.FromImage(pic)) {
                    g.DrawImage(temp, new Rectangle((250 - w) / 2, (250 - h) / 2, w, h));
                }

                ilPics.Images.Add(pic);
                temp.Dispose();
                // remember to add img list in Properties of listview
                ListViewItem list = new ListViewItem();
                list.ImageIndex = i;
                lvGallery.Items.Add(list);
            }
            if (i == gallery.Length - 1) timer.Stop();
        }
        
    }
}
