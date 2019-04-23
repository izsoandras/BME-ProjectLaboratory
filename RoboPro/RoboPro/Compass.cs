using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;

namespace RoboPro
{
    public partial class Compass : UserControl
    {
        private PointF _heading = new PointF((float)0.0,(float)-1.0);
        public PointF Heading
        {
            get { return _heading; }
            set
            {
                float len = (float)Math.Sqrt(value.X * value.X + value.Y * value.Y);
                
                _heading.X = value.X / len;
                _heading.Y = value.Y / len;
                Invalidate();
            }
        }

        public Compass()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Black, 5), 3,3,Width-10, Height-10);
            //e.Graphics.DrawString("N", new Font("Arial", 8), new SolidBrush(Color.Black), new RectangleF(Width/2-5, 10, 10,10) );
            e.Graphics.DrawLine(new Pen(Color.Red, 2), Width/2-1, Height/2-1, Width/2 + Width/2 * (float)(-Heading.Y *0.8), Height/2 - Height/2*(float)(Heading.X * 0.8));
        }
    }
}
