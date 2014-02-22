using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BezierCurveEditor
{
    /// <summary>
    /// Klasa implementujaca operacje na liczbach zespolonych
    /// </summary>
    [Serializable]
    public class Complex
    {
        public double x, y;

        public Complex()
        {
            x = y = 0;
        }

        public Complex(Complex c)
        {
            x = c.x;
            y = c.y;
        }

        public Complex(double x_, double yi = 0)
        {
            x = x_;
            y = yi;
        }

        public double Abs()
        {
            return Math.Sqrt(x * x + y * y);
        }

        #region Dzialania
        public static Complex operator +(Complex y, Complex x)
        {
            return new Complex(x.x + y.x, x.y + y.y);
        }

        public static Complex operator -(Complex y, Complex x)
        {
            return new Complex(y.x - x.x, y.y - x.y);
        }

        public static Complex operator -(Complex x)
        {
            return new Complex(-x.x, -x.y);
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(x.x * y.x - x.y * y.y, x.x * y.y + x.y * y.x);
        }

        public static Complex operator *(Complex x, double alpha)
        {
            return new Complex(alpha * x.x, alpha * x.y);
        }

        public static Complex operator *(double alpha, Complex x)
        {
            return new Complex(alpha * x.x, alpha * x.y);
        }

        public static Complex operator /(Complex x, double alpha)
        {
            return new Complex(x.x / alpha, x.y / alpha);
        }

        public static Complex operator /(double alpha, Complex x)
        {
            double tmp = x.SquareSum();
            return new Complex((x.x * alpha) / tmp, -(x.y * alpha) / tmp);
        }

        public static Complex operator /(Complex x, Complex y)
        {
            double tmp = y.SquareSum();
            return new Complex((x.x * y.x + x.y * y.y) / tmp, (x.y * y.x - y.y * x.x) / tmp);
        }

        #endregion

        public double SquareSum() { return x * x + y * y; }

        public double Arg()
        {
            return (180.0 / Math.PI) * ArgRad();
        }

        public double ArgRad()
        {
            return x != 0 ? Math.Atan(y / x) : 0;
        }

        override public string ToString()
        {
            return String.Format("({0},{1}i)", x, y);
        }

        public string ToString2(int round = 1)
        {
            return Convert.ToString(Math.Round(x, round)) + ((Math.Sign(y) > 0) ? " + " : " - ")
                          + Convert.ToString(Math.Round(Math.Abs(y), round));
        }

    #region Conversions
        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }

        public PointF ToPointF()
        {
            return new PointF((float)x, (float)y);
        }
    #endregion

        public double Re
        {
            get { return x; }
            set { x = value; }
        }

        public double Im
        {
            get { return y; }
            set { y = value; }
        }

    }
}
