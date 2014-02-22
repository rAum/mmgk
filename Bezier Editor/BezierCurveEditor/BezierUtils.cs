using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BezierCurveEditor
{
    class BezierUtils
    {
        static public void DrawBezier(PaintEventArgs e, Bezier b, float stepSize = 0.005f)
        {
            PointF prev = b.castelijou(0.0).ToPointF();
            PointF curr;
            Pen p = new Pen(Brushes.Black, 5);
            for (double t = stepSize; t <= 1.0f; t += stepSize)
            {
                curr = b.castelijou(t).ToPointF();
                e.Graphics.DrawLine(p, prev, curr);
                
                prev = curr;
            }
            e.Graphics.DrawLine(p, prev, b.castelijou(1.0).ToPointF());
        }

        static public void DrawAllConvexHull(PaintEventArgs e, BezierSet beziers, Pen p)
        {
            List<Complex> points = new List<Complex>();
            foreach (var b in beziers.set)
            {
                points.AddRange(b.points);
            }
            List<Complex> hull = GrahamHull.GetGrahamHull(points);

            PointF prev = hull[0].ToPointF();
            PointF curr;
            foreach (var ch in hull)
            {
                curr = ch.ToPointF();
                e.Graphics.DrawLine(p, prev, curr);
                prev = curr;
            }
            e.Graphics.DrawLine(p, prev, hull[0].ToPointF());
        }

        static public void DrawConvexHull(PaintEventArgs e, Bezier b, Pen p)
        {
            List<Complex> hull = GrahamHull.GetGrahamHull(b.points);

            if (hull.Count < 2)
                return; // no need to draw..

            PointF prev = hull[0].ToPointF();
            PointF curr;
            foreach (var ch in hull)
            {
                curr = ch.ToPointF();
                e.Graphics.DrawLine(p, prev, curr);
                prev = curr;
            }
            e.Graphics.DrawLine(p, prev, hull[0].ToPointF());
        }

        static public void DrawConnections(PaintEventArgs e, Bezier b, Pen p)
        {
            var pt = b.points.Select(x => {return x.ToPointF(); } ).ToArray();
            e.Graphics.DrawLines(p, pt);
        }

        static public Rectangle ComplexToRect(Complex c, int size = 4)
        {
            Point p = c.ToPoint();
            return new Rectangle(p.X - size, p.Y - size, size + size, size + size);
        }

        static public void DrawPoints(PaintEventArgs e, Bezier b, Brush p, Brush c, int size = 4)
        {
            int n = b.points.Count - 1;

            for (int i = 1; i < n; ++i)
                e.Graphics.FillEllipse(p, ComplexToRect(b.points[i], size));

            e.Graphics.FillEllipse(c, ComplexToRect(b.points[0], size + 1));
            e.Graphics.FillEllipse(c, ComplexToRect(b.points[n], size + 1));
        }
    }
}
