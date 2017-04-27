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
    public partial class Doodle : Form {
        public Doodle() {
            InitializeComponent();
            InitializeEvent();
            pallete = new Pallete();
        }

        Pallete pallete;
        private bool EVENT_STATE = true;

        private void InitializeEvent() { // no Panel_MouseMove added
            pnPaint.Paint += Panel_Paint;
            pnPaint.MouseDown += Panel_MouseDown;
            pnPaint.MouseUp += Panel_MouseUp;
            pnPaint.Invalidate();
        }

        private void RemoveEvent() {
            pnPaint.Paint -= Panel_Paint;
            pnPaint.MouseDown -= Panel_MouseDown;
            pnPaint.MouseUp -= Panel_MouseUp;
            pnPaint.Invalidate();
        }
        
        private void Panel_Paint(object sender, PaintEventArgs e) {
            pallete.setGraphics(e.Graphics);
            pallete.fillRectangle(this);
            if (!pallete.isEmpty()) pallete.Paint();
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e) {
            pallete.addPoint(e.X, e.Y);
            pnPaint.MouseMove += Panel_MouseMove;
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e) {
            pallete.addPoint(e.X, e.Y);
            pnPaint.Invalidate();
        }
        private void Panel_MouseUp(object sender, MouseEventArgs e) {
            pallete.Stop();
            pnPaint.MouseMove -= Panel_MouseMove;
            
        }
        private void btPen_Click(object sender, EventArgs e) {
            EVENT_STATE = !EVENT_STATE;
            if (EVENT_STATE) InitializeEvent();
                else RemoveEvent(); 
        }

        private void btEraser_Click(object sender, EventArgs e) {
            pallete.Clear();
            pnPaint.Invalidate();
        }

        #region [Pallete Class]
        class Pallete {
            Point DEFAULT_STOP = new Point(-1, -1);
            private Brush brush;
            private List<Point> point_list;
            private Pen pen;
            private Graphics panel;

            public Pallete() {
                brush = Brushes.LightGreen;
                point_list = new List<Point>();
                pen = new Pen(Color.Black);
            }
            
            public void Paint() { // cannot call paint from the inside, needs Invalidate()
                for (int i = 1; i < point_list.Count; i++) { 
                    Point p1 = point_list[i - 1];
                    Point p2 = point_list[i];
                    if (p1 != DEFAULT_STOP && p2 != DEFAULT_STOP) panel.DrawLine(pen, p1, p2);
                }
            }

            public void fillRectangle(Control control) {
                panel.FillRectangle(brush, control.ClientRectangle);
            }

            public bool isEmpty() { return (point_list.Count < 2); }

            public void setGraphics(Graphics graphics) { this.panel = graphics; }
            public void setPenColor(Color new_color) { pen.Color = new_color; }
            public void setRectangleColor(Brush new_brush) { brush = new_brush; }

            public void addPoint(Point p) { point_list.Add(p); }
            public void addPoint(int x, int y) { addPoint(new Point(x, y)); }

            public void Stop() { point_list.Add(DEFAULT_STOP); }
            public void Clear() { point_list.Clear(); }
        }
        #endregion

    }
}
