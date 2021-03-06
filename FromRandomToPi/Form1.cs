using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FromRandomToPi
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            panel3.Refresh();
            using (Graphics g = panel3.CreateGraphics())
            {
                List<Point> point = new List<Point>();
                List<Point> ZPoint = new List<Point>();
                Rectangle rect = new Rectangle(1, 1, panel3.Width-5, panel3.Height-5);
                g.DrawRectangle(new Pen(Color.Black), rect);
                RectangleF elipse = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
                g.DrawEllipse(new Pen(Color.Black), elipse);
                for (int i = 0; i < (int)numericUpDown1.Value; i++)
                {
                    point.Add(DrawPoint(g, rect));
                }
                for (int i = 0; i < point.Count(); i++)
                {
                    if (Math.Sqrt(Math.Pow(point[i].X, 2) + Math.Pow(point[i].Y, 2)) <= rect.Width)
                    {
                        ZPoint.Add(new Point(point[i].X, point[i].Y));
                    }
                }
                int zp = ZPoint.Count();
                int pt = point.Count();
                double piresult = ((double)zp / (double)pt) * 4;
                label2.Text = piresult.ToString();
            }
        }
        Point DrawPoint(Graphics g, Rectangle rectangle)
        {
            int x = r.Next(rectangle.X, rectangle.Width);
            int y = r.Next(rectangle.Y, rectangle.Height);
            g.DrawEllipse(new Pen(Color.Blue), x, y, 2, 2);
            g.FillEllipse(new SolidBrush(Color.Blue), x, y, 2, 2);
            return new Point(x, y);
        }
    }
}
