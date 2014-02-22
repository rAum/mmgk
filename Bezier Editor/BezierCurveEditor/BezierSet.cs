using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BezierCurveEditor
{
    class CurrentPtr
    {
        public Bezier    bez;
        public BezierSet bset;
        public int i;

        public CurrentPtr(Bezier b, BezierSet s, int index)
        {
            bez = b;
            bset = s;
            i = index;
        }
    }

    class BezierSet
    {
        public List<Bezier> set;

        public BezierSet()
        {
            set = new List<Bezier>();
        }

        public BezierSet(Bezier b)
        {
            set = new List<Bezier>();
            set.Add(b);
        }

        public void Add(BezierSet bset)
        {
            set.AddRange(bset.set);
        }

        public void Add(Bezier b)
        {
            set.Add(b);
        }

        public void Draw(PaintEventArgs e, bool curve = true, bool points = true, bool hull = false, bool lines = false)
        {
            foreach (var b in set)
            {
                if (curve)  BezierUtils.DrawBezier(e, b);
                if (hull) BezierUtils.DrawAllConvexHull(e, this, new Pen(Brushes.BlueViolet, 2.0f));
                if (lines)  BezierUtils.DrawConnections(e, b, Pens.White);
                if (points) BezierUtils.DrawPoints(e, b, Brushes.Yellow, Brushes.Red);
            }
        }

        public CurrentPtr Find(Point location, int threshold)
        {
            Complex loc = new Complex(location.X, location.Y);
            double t = threshold * threshold;

            foreach (var b in set)
            {
                for (int i = 0; i < b.points.Count; ++i)
                {
                    if ((loc - b.points[i]).SquareSum() < t)
                    {
                        return new CurrentPtr(b, this, i);
                    }
                }
            }

            return null;
        }

    }
}
