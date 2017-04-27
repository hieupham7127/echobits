using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyApplication {
    class PaintSpiral : Panel {

        private Panel panel;
        private Pen pen;
        private Point start_point, end_point;
        private int lines;
        private double angle;
        private double length;
        private double increment;

        public PaintSpiral(Size panel_size, Pen pen, int lines, double angle, double length, double increment) {
            this.panel = new Panel();
            panel.Size = panel_size;
            this.pen = pen;
            this.lines = lines;
            this.angle = angle;
            this.length = length;
            this.increment = increment;
            panel.Paint += new PaintEventHandler(this.PaintSpiral_Paint);
        }

        private void PaintSpiral_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Honeydew, ((Panel)sender).ClientRectangle);
            double angle = 0;
            double length = this.length;
            this.start_point = new Point(panel.Width / 2, panel.Width / 2);
            for (int i = 0; i < lines; i++) {
                angle += this.angle;
                length += increment;
                end_point = new Point((int)(start_point.X + Math.Cos(ToRadians(angle)) * length), (int)(start_point.Y + Math.Sin(ToRadians(angle)) * length));
                e.Graphics.DrawLine(pen, start_point, end_point);
                start_point = end_point;
            }
        }

        public static double ToRadians(double angle) { return (Math.PI / 180) * angle; }

        public void Draw() { panel.Invalidate(); }

        public Bitmap getBitmap() {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            using (Graphics g = Graphics.FromImage(bitmap)) {
                Bitmap panel_bitmap = new Bitmap(panel.Width, panel.Height);
                panel.DrawToBitmap(panel_bitmap, new Rectangle(Point.Empty, panel.Size));
                g.DrawImage(panel_bitmap, Point.Empty);
            }
            return bitmap;
        }
    }
}
