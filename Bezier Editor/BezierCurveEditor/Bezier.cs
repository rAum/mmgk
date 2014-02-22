using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BezierCurveEditor
{
    class Bezier
    {
        public int Id;
        private static int IdCounter = 0;
        public List<Complex> points;

        public Bezier left = null;
        public Bezier right = null;
        public int leftNode;
        public int rightNode;

        public Bezier()
        {
            Id = IdCounter++;
        }

        public Bezier(Bezier b)
        {
            Id = IdCounter++;
            points = new List<Complex>(b.points.ToArray());
        }

        public int Degree
        {
            get { return points.Count; }
        }

        public int ControlPoints
        {
            get { return Math.Max(Degree - 2, 0); }
        }

        public Complex Get(int i)
        {
            return points[i];
        }

        public Bezier[] Subdivide(Complex t)
        {
            Complex[] first = new Complex[Degree];
            Complex[] second = new Complex[Degree];
            Complex[] c = new Complex[Degree];

            int n = Degree - 1;
            for (int i = 0; i <= n; ++i)
            {
                c[i] = new Complex(points[i].Re, points[i].Im);
            }

            for (int i = 0; i < Degree; ++i)
            {
                first[i] = new Complex(c[0]);
                second[Degree - i - 1] = new Complex(c[n]);
                for (int j = 0; j < n; ++j)
                {
                    c[j] = c[j] + t * (c[j + 1] - c[j]);
                }                
                --n;
            }

            return new Bezier[] { new Bezier(first), new Bezier(second) };
        }


        public bool ConnectLeft(Bezier s, bool last = false, bool force = false)
        {
            if (s == null || (left != null && force == false))
                return false;

            int nr = last ? s.Degree - 1 : 0;

            if (last) // tutejszy lewy z tamtym ostatnim [prawym]
            {
                if (s.right != null && force == false)
                    return false;

                left = s;
                leftNode = nr;
                s.right = this;
                s.rightNode = 0;

                //Chaining(0);
                //Chaining(1);
                //Chaining(Degree - 1);
                //Chaining(Degree - 2);
            }
            else // lewy z lewym
            {
                if (s.left != null && force == false)
                    return false;

                left = s;
                leftNode = nr;
                s.left = this;
                s.leftNode = 0;

                //Chaining(0);
                //Chaining(1);
            }
            
            return true;
        }

        public bool ConnectRight(Bezier s, bool last = true, bool force = false)
        {
            if (s == null || (right != null && force == false))
                return false;

            int nr = last ? s.Degree - 1 : 0;

            if (last) // tutejszy prawy z tamtym ostatnim [prawym]
            {
                if (s.right != null && force == false)
                    return false;

                right = s;
                rightNode = nr;
                s.right = this;
                s.rightNode = Degree - 1;
            }
            else // prawy z lewym
            {
                if (s.right != null && force == false)
                    return false;

                right = s;
                rightNode = nr;
                s.left = this;
                s.leftNode = Degree - 1;
            }
            
            return true;
        }


        public void Chaining(int i, bool l = true, bool r = true)
        {
            Complex val = points[i];
            if (r && right != null && right != this)
            {
                int n = this.Degree - 1;
                if (i == n) // ruszono ostatni punkt
                {
                    right.points[rightNode].Re = val.Re;
                    right.points[rightNode].Im = val.Im;
                }
                else if (right.ControlPoints > 0 && ControlPoints > 0 && i == n - 1) // przedostatni punkt
                {
                    Complex vec = points[n] - val;
                    if (rightNode == 0)
                    {
                        right.Set(1, points[n] + vec, false, true);
                    }
                    else
                    {
                        right.Set(right.Degree - 2, points[n] + vec, true, false);
                    }
                }
            }

            if (l && left != null && left != this)
            {
                if (i == 0)
                {
                    left.points[leftNode].Re = val.Re;
                    left.points[leftNode].Im = val.Im;
                }
                else if (ControlPoints > 0 && left.ControlPoints > 0 && i == 1)
                {
                    Complex vec = points[0] - points[1];
                    if (leftNode == 0)
                    {
                        left.Set(1, points[0] + vec, false, true);
                    }
                    else
                    {
                        left.Set(left.Degree - 2, points[0] + vec, true, false);
                    }
                }
            }
        }

        public void Set(int i, Complex val, bool chainLeft = true, bool chainRight = true)
        {
            points[i].Re = val.Re;
            points[i].Im = val.Im;

            if (i > 1 && i < Degree - 2)
                return;

            Chaining(i, chainLeft, chainRight);
        }

        public Bezier(Complex[] init, int degreeRaising = 0)
        {
            points = init.ToList();

            for (int i = 0; i < degreeRaising; ++i)
            {
                DegreeElevate();
            }
        }

        public void Move(Complex vec)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                points[i] += vec;
            }
        }

        public void Scale(Complex center, double s)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                points[i] = (points[i] - center) * s;
            }
        }

        public Complex MassCenter()
        {
            Complex sum = new Complex();
            
            foreach (var c in points)
            {
                sum += c;
            }

            return sum / (double)points.Count;
        }

        /// <summary>
        /// Castelijou algorithm.
        /// </summary>
        /// <param name="p">List of points</param>
        /// <param name="t">real position at curve, must be from [0,1]</param>
        /// <returns>Value at t-position - s(t)</returns>
        public Complex castelijou(double t)
        {
            List<Complex> c = new List<Complex>(points);

            int n = c.Count - 1;
            for (int i = 0; i < c.Count; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    c[j] = c[j] + t * (c[j + 1] - c[j]);
                }
                --n;
            }

            return c[0];
        }

        public void DegreeElevate(int times = 1)
        {
            for (int i = 0; i < times; ++i)
                DegreeElevation(ref points);
        }

        public void DegreeReduction(int times = 1)
        {
            for (int i = 0; i < times; ++i)
                DegreeReduction(ref points);
        }


        private void DegreeElevation(ref List<Complex> pt)
        {
            int n = pt.Count;

            if (n < 1)
                return;

            List<Complex> elevated = new List<Complex>(pt.Count + 1);

            elevated.Add(pt[0]);

            for (int i = 1; i < n; ++i)
            {
                Complex c = ((float)(n - i) / n) * pt[i] + ((float)i / n) * pt[i - 1];
                elevated.Add(c);
            }

            elevated.Add(pt[n - 1]);

            pt = elevated;
        }

        private void DegreeReduction(ref List<Complex> pt)
        {
            int m = pt.Count - 1;
            if (m < 3)
                return;
            int n = m - 1;
            Complex[] p = new Complex[n+1];
            
            if (n % 2 == 1)
            {
                int h = (n - 1) / 2;
                p[0] = pt[0];
                for (int i = 1; i <= h; ++i)
                {
                    double mi = m - i;
                    p[i] = (m/mi)*pt[i] - (i/mi)*p[i-1];
                }

                p[n] = pt[m];
                
                for (int i = n; i >= h + 2; --i)
                {
                    double ii = i;
                    p[i-1] = (m/i)*pt[i] - ((m-i)/i) * p[i];
                }
            }
            else
            {
                int h = n / 2;
                p[0] = pt[0];
                for (int i = 1; i <= h; ++i)
                {
                    double mi = m - i;
                    p[i] = (m/mi)*pt[i] - (i/mi)*p[i-1];
                }

                Complex q = new Complex(p[h].x, p[h].y);
                p[n] = pt[m];
                for (int i = n; i >= h+1; --i)
                {
                    double ii = i;
                    p[i - 1] = (m/ii)*pt[i] - ((m-i)/ii) * p[i];
                }

                p[h] = (p[h] + q) * 0.5;
            }

            pt = p.ToList();
        }

    }
}
