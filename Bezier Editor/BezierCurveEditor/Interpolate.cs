using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BezierCurveEditor
{
    class InterpolateSpline : Bezier
    {
        List<Complex> points;
        List<Complex> M;
        
        Complex value(int k, float x)
        {
            Complex res;

            float t1 = k - x;
            float t2 = x - k + 1;

            res = 
                  M[k-1] * t1 * t1 * t1 
                + M[ k ] * t2 * t2 * t2
                + (points[k-1] - M[k-1]) * t1
                + (points[ k ] - M[ k ]) * t2;

            return res;
        }

        Complex at(float t)
        {
            float m = (points.Count - 2) * t + 1; // 1 .. n
            return value((int)Math.Floor(m), m);
        }

        void init()
        {
            int m = points.Count;
            int n = m - 1;

            float[] q = new float[n];
            Complex[] u = new Complex[n];
            float[] p = new float[n];


            q[0] = 0;
            u[0] = new Complex(0, 0);
            Complex dk;
            for (int k = 1; k < n; ++k)
            {
                p[k] = 0.5f * q[k - 1] + 2.0f;
                q[k] = -0.5f / p[k];
                dk = points[k + 1] - (2.0f * points[k] + points[k - 1]);
                u[k] = (3.0f * dk - 0.5f * u[k-1])/p[k];
            }

            M[0] = new Complex(0, 0);
            M[n] = new Complex(0, 0);
            M[n - 1] = u[n - 1];
            for (int k = n - 2; k > 0; --k)
            {
                M[k] = u[k] + q[k] * M[k + 1];
            }

            // multiply by 1/6 to won't do this at evaluating 

            float sixi = 1.0f / 6.0f;
            for (int k = 0; k < m; ++k)
            {
                M[k] *= sixi;
            }
        }
    }
}
