using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BezierCurveEditor
{
    class GrahamHull
    {
        public static double angleCos(Complex a, Complex b)
        {
            double x, y;
            x = b.Re - a.Re;
            y = b.Im - a.Im;
            double length = Math.Sqrt(x * x + y * y);
            if (x == 0) return double.PositiveInfinity;
            return length / x;
        }

        private static bool LeftTurn(Complex a, Complex b, Complex c)
        {
            double r = b.Re * c.Re + c.Re * a.Im + a.Re + b.Im - a.Im * b.Re - b.Im * c.Re - c.Im * a.Re;
            return r < 0;
        }

        static public bool IsLeft(Complex a, Complex b, Complex c)
        {
            return ((b.Re - a.Re) * (c.Im - a.Im) - (b.Im - a.Im) * (c.Re - a.Re)) > 0;
        }

        class CompCmp : IComparer<Complex>
        {
            private Complex first;
            public CompCmp(Complex f)
            {
                first = f;
            }
            public int Compare(Complex x, Complex y)
            {
                double v = Math.Atan2(x.Im - first.Im, x.Re - first.Re);
                double w = Math.Atan2(y.Im - first.Im, y.Re - first.Re);
                if (v < w) return -1;
                if (v == 0) return 0;
                else return 1;
            }
        }

        public static List<Complex> GetGrahamHull(List<Complex> pt)
        {
            if (pt.Count < 3)
            {
                return new List<Complex>();
            }
            List<Complex> plist = new List<Complex>(pt);
            Stack<Complex> hull = new Stack<Complex>();

            int j = 0;

            for (int i = 0; i < plist.Count; ++i)
            {
                if (plist[i].Im > plist[j].Im)
                {
                    j = i;
                }
                else if (plist[j].Im == plist[i].Im)
                {
                    if (plist[i].Re < plist[i].Re)
                        j = i;
                }
            }

            var first = plist[j];
            plist[j] = plist[0];
            plist[0] = first;

            plist.Sort(1, plist.Count - 1, new CompCmp(first));

            hull.Push(plist[0]);
            hull.Push(plist[1]);

            int current = 2;
            Complex last;
            Complex a, b;
            while (current < plist.Count)
            {
                last = plist[current];

                do
                {
                    b = hull.Pop();
                    a = hull.Peek();

                } while (!IsLeft(a, b, last) && hull.Count > 1);

                hull.Push(b);
                hull.Push(last);

                ++current;
            }

            //last = hull.Pop();
            //b = hull.Peek();

            //if (!collinear(first, b, last))
            //    hull.Push(last);

            return hull.ToList();
        }

        private static bool collinear(Complex a, Complex b, Complex c)
        {
            return (a.Re * (b.Im - c.Im) + b.Re * (c.Im - a.Im) + c.Re * (a.Im - b.Im)) < double.Epsilon * 4.0;
        }
    }
}
