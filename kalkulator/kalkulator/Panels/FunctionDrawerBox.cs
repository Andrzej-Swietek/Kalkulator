using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator.Panels
{
    public partial class FunctionDrawerBox : UserControl
    {
        public Func<double, double> f;
        double preccision = 4;
        double scaleX = 1;
        double scaleY = 1;

        public FunctionDrawerBox()
        { 
            InitializeComponent();
            f = JakasFunkcja;
        }

        double JakasFunkcja(double x)
        {
            return x;
        }

        private void FunctionDrawerBox_Paint(object sender, PaintEventArgs e)
        {
            if (Site != null && Site.DesignMode) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen curvePen = new Pen(Color.Green, 3);
            Pen scalePen = new Pen(Color.Black, 2);
            Point center = new Point(e.ClipRectangle.Width / 2, e.ClipRectangle.Height / 2);

            //Rysowanie podziałki
            g.DrawLine(scalePen, new Point(0, center.Y), new Point(e.ClipRectangle.Width, center.Y));
            g.DrawLine(scalePen, new Point(center.X, 0), new Point(center.X, e.ClipRectangle.Height));

            if (f != null)
            {
                int pointsCount = (int)Math.Ceiling(e.ClipRectangle.Width / preccision);
                //Point[] points = new Point[pointsCount];
                List<List<Point>> pointsPaths = new List<List<Point>>();
                List<Point> currPath = new List<Point>();
                pointsPaths.Add(currPath);

                for (int i = 0; i < pointsCount; i++)
                {
                    double x = ((i - (pointsCount / 2.0)) * scaleX) * preccision;
                    try
                    {
                        double y = f(x);
                        int drawX = (int)(i * preccision);
                        int drawY = (int)((e.ClipRectangle.Height - (f(x) * scaleY)) - (e.ClipRectangle.Height / 2.0));
                        currPath.Add(new Point(drawX, drawY));
                    }
                    catch (Calcualtion.CalculationException)
                    {
                        if (currPath.Count > 0)
                        {
                            currPath = new List<Point>();
                            pointsPaths.Add(currPath);
                        }
                    }
                }
                foreach (var p in pointsPaths)
                {
                    g.DrawCurve(curvePen, p.ToArray());
                }
            }
        }
    }
}
