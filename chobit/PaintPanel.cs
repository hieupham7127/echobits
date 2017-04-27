using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyApplication {
    public partial class PaintPanel : Form {
        public PaintPanel(Bitmap bitmap) {
            InitializeComponent();
            this.bitmap = bitmap;
            pnPaint.Paint += Panel_Paint;
        }

        Bitmap bitmap;

        private void Panel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(bitmap, new Rectangle(Point.Empty, pnPaint.Size));
        }
    }
}
