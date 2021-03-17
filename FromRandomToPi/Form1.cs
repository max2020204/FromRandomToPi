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
        int incircle = 0;
        int outcircle = 0;
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
                Rectangle rect = new Rectangle(1, 1, panel3.Width - 5, panel3.Height - 5);
                g.DrawRectangle(new Pen(Color.Blue, 2), rect);
                RectangleF elipse = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
                g.DrawEllipse(new Pen(Color.Red, 2), elipse);
                for (int i = 0; i < (int)numericUpDown1.Value; i++)
                {
                    point.Add(DrawPoint(g, rect, elipse));
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
                label4.Text = incircle.ToString();
                label6.Text = outcircle.ToString();
                label8.Text = Math.Round((((piresult / Math.PI) * 100) - 100), 3).ToString() + " %";
            }
        }
        Point DrawPoint(Graphics g, Rectangle rectangle, RectangleF elipse)
        {
            int x = r.Next(rectangle.X, rectangle.Width);
            int y = r.Next(rectangle.Y, rectangle.Height);
            SizeF size = elipse.Size;
            if (Math.Pow(x - (size.Width / 2), 2) + Math.Pow(y - (size.Height / 2), 2) < Math.Pow(size.Width / 2, 2))
            {
                g.DrawEllipse(new Pen(Color.Red, 2), x, y, 2, 2);
                g.FillEllipse(new SolidBrush(Color.Red), x, y, 2, 2);
                incircle++;
            }
            else
            {
                g.DrawEllipse(new Pen(Color.Blue, 2), x, y, 2, 2);
                g.FillEllipse(new SolidBrush(Color.Blue), x, y, 2, 2);
                outcircle++;
            }
            return new Point(x, y);
        }
    }
}
