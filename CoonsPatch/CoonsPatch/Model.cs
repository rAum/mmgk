using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace CoonsPatch
{
    public class myVector3
    {
        Vector3 v;

        public myVector3()
        {
            v = new Vector3();
        }

        public static implicit operator Vector3(myVector3 mv)
        {
            return mv.v;
        }

        public myVector3(Vector3 v_)
        {
            v = v_;
        }

        public float X
        {
            get { return v.X; }
            set { v.X = value; }
        }

        public float Y
        {
            get { return v.Y; }
            set { v.Y = value; }
        }

        public float Z
        {
            get { return v.Z; }
            set { v.Z = value; }
        }
    }

    public class RenderSettingsData
    {
        public bool wireframe = false;
        public bool controlPoints = true;
        public bool controlCurve = true;
        public bool contour = true;
        public bool patch = true;
        public bool smoothColor = false;

        public float dv = 4.0f;
        public float du = 4.0f;

        public float maxv = 1.0f;
        public float maxu = 1.0f;

        public float A = 1.0f, 
                     B = 1.0f, 
                     C = 1.0f;

        public static Vector3 linear(float t, Vector3 a, Vector3 b)
        {
            return (1.0f - t) * a + t * b;
        }

        public static Vector3 sincos(float t, Vector3 a, Vector3 b)
        {
            t *= 0.5f * (float)Math.PI;
            float t1 = (float)Math.Cos(t);
            float t2 = (float)Math.Sin(t);
            return (t1 * t1) * a + (t2 * t2) * b;
        }

        public static Vector3 hermite(float t, Vector3 a, Vector3 b)
        {
            return linear(t * t * (3.0f - 2.0f * t), a, b);
        }

        public delegate Vector3 InBetweenDelegate(float t, Vector3 a, Vector3 b);

        public InBetweenDelegate lerp = new InBetweenDelegate(linear);
        public InBetweenDelegate lerp2 = new InBetweenDelegate(linear);
    }


    public class ModelChangeEventArgs
    {
        public Model.Spline spline;
        public int point;

        public ModelChangeEventArgs(Model.Spline spline_, int point_)
        {
            spline = spline_;
            point = point_;
        }
    }

    public class RenderChangeEventArgs
    {
        public RenderSettingsData data;

        public RenderChangeEventArgs(RenderSettingsData d)
        {
            data = d;
        }
    }

    public interface IView
    {
        void ModelChange(object sender, ModelChangeEventArgs e);
    }

    public interface IRenderSettings
    {
        void RenderChange(object sender, RenderChangeEventArgs e);
    }

    public class Model
    {
        List<Vector3>[] splines = new List<Vector3>[4];
        public RenderSettingsData settings = new RenderSettingsData();

        public Model()
        {
            splines[(int)Model.Spline.P1] = new List<Vector3> // g1 - y
            {
                new Vector3(0,0,0),
                new Vector3(1,0,1),
                new Vector3(2,0,1),
                new Vector3(3,0,0)
            };

            splines[(int)Model.Spline.P0] = new List<Vector3> // g2 - y
            {
                new Vector3(0,3,0),
                new Vector3(1,3,1),
                new Vector3(2,3,1),
                new Vector3(3,3,0)
            };

            splines[(int)Model.Spline.Q1] = new List<Vector3> // h1 - x
            {
                new Vector3(0,0,0),
                new Vector3(0, 1, 1),
                new Vector3(0, 2, -3),
                new Vector3(0, 3, 0)
            };


            splines[(int)Model.Spline.Q0] = new List<Vector3> // h2 - x
            {
                new Vector3(3, 0, 0),
                new Vector3(3,1,1),
                new Vector3(3,2,1),
                new Vector3(3,3,0)
            };

            Evaluate = new EvaluateDelegate(Bezier);
        }

        public enum Spline
        {
            P0, P1, Q0, Q1
        };

        public List<myVector3> GetSpline(Spline i)
        {
            return splines[(int)i].Select(x => { return new myVector3(x); }).ToList();
        }

        public void SetSpline(Spline i, Vector3[] spline_)
        {
            splines[(int)i] = new List<Vector3>(spline_);
        }


        internal void SetSpline(int i, Vector3[] spline_)
        {
            splines[i] = new List<Vector3>(spline_);
        }

        public void AddPoint(Spline i, Vector3 point)
        {
            splines[(int)i].Add(new Vector3(point));
        }

        public delegate Vector3 EvaluateDelegate(Spline spline_, float t);
        public EvaluateDelegate Evaluate;

        public Vector3 Bezier(Spline spline_, float t)
        {
            List<Vector3> p = splines[(int)spline_];
            List<Vector3> c = new List<Vector3>(p.Count);

            for (int i = 0; i < p.Count; ++i)
                c.Add(p[i]);

            int n = p.Count - 1;
            float tm = 1.0f - t;
            for (int i = 0; i < p.Count; ++i, --n)
            {
                for (int j = 0; j < n; ++j)
                {
                    c[j] = t * c[j] + tm * c[j + 1];
                }
            }

            return c[0];
        }

        #region Catmull-Rom

        private int tr(int i, int max)
        {
            if (i < 0) return 0;
            if (i > max) return max;
            return i;
        }
        public Vector3 CatmullRom(Spline spline_, float t)
        {
            float fract, seg;
            List<Vector3> p = splines[(int)spline_];
            int n = p.Count;
            t = t * n;
            seg = (float)Math.Floor(t);
            fract = t - seg;
            int point = n - (int)seg;
            --n;
            return CRSegment(fract, p[tr(point+1, n)], p[tr(point, n)], p[tr(point-1, n)], p[tr(point-2, n)]);
        }

        public Vector3 CRSegment(float t, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            float tt = t * t;
            Vector3 res =  2*b
                          + (-a + c) * t
                          + (2*a - 5*b + 4 * c - d) * tt
                          + (-a + 3*b - 3*c + d) * (tt * t);
            return res * 0.5f;
        }

        #endregion

        // g - p
        // h - q
        public Vector3 CoonsPatchAt(float u, float v)
        {
            Vector3 a = settings.lerp(u, Evaluate(Spline.Q0, v), Evaluate(Spline.Q1, v));
            Vector3 b = settings.lerp(v, Evaluate(Spline.P0, u), Evaluate(Spline.P1, u));
            Vector3 c = settings.lerp(  u 
                              ,settings.lerp(v, Evaluate(Spline.Q0, 0), Evaluate(Spline.Q0, 1))
                              ,settings.lerp(v, Evaluate(Spline.Q1, 0), Evaluate(Spline.Q1, 1))
                             );
            return settings.A * a + settings.B * b - settings.C * c;
        }
    }
}
