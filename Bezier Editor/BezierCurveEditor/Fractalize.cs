using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BezierCurveEditor
{
    class Fractalize : Bezier
    {
        public Complex U { get; set; }
        public int Subdivision { get; set; }

        public Fractalize(Complex[] init, Complex u, int subdivision) : base(init)
        {
            U = u;
            Subdivision = subdivision;
        }

        //public override Complex castelijou(double t)
        //{

        //    return U;
        //}

        //public List<BPoint> process(BezierCurve curve)
        //{
        //    BezierCurve result = curve;

        //    List<List<Complex>> fractal = new List<List<Complex>>();
        //    fractal.Add(curve.Points);
        //    List<List<Complex>> t;

        //    for (int i = 1; i <= Subdivision; ++i)
        //    {
        //        t = new List<List<Complex>>();
        //        foreach (var segment in fractal)
        //        {
        //            var subsegments = castelijou(segment);
        //            t.AddRange(subsegments);
        //        }
        //        fractal = t;
        //    }

        //    List<BPoint> points = new List<BPoint>(curve.Count * (Subdivision - 1) * 2);
        //    foreach (var segment in fractal)
        //    {
        //        points.AddRange(segment.Select(x => new BPoint(x)));
        //    }
        //    return points;
        //}

        //List<Complex>[] castelijou(List<Complex> input)
        //{
        //    List<Complex> left = new List<Complex>(input.Count);
        //    List<Complex> right = new List<Complex>(input.Count);
        //    int n = input.Count;
        //    for (int i = 0; i < input.Count; ++i)
        //    {
        //        left.Add(input[0]);
        //        --n;
        //        for (int j = 0; j < n; ++j)
        //        {
        //            input[j] = input[j] + U * (input[j + 1] - input[j]);
        //        }
        //    }

        //    for (int i = 0; i < input.Count; ++i)
        //    {
        //        right.Add(input[i]);
        //    }

        //    return new List<Complex>[2] { left, right };
        //}
    }
}
