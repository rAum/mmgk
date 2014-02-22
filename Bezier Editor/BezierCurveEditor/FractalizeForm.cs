using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BezierCurveEditor
{
    public partial class FractalizeForm : Form
    {
        Complex t;
        int segments;

        public Complex DivPoint
        {
            get { return t; }
        }

        public int Segments
        {
            get { return segments; }
        }

        public FractalizeForm(bool divide = true)
        {
            InitializeComponent();

            t = new Complex(0.5, 0.5);
            segments = 2;

            nudReal.Value = (decimal)t.Re;
            nudComplex.Value = (decimal)t.Im;
            nudSegments.Value = segments;

            if (divide)
            {
                nudSegments.Enabled = false;
                Text = "Podziel krzywa";
            }
        }

        public FractalizeForm(Complex oldt, int oldseg)
        {
            InitializeComponent();
            t = oldt;
            segments = oldseg;
            nudReal.Value = (decimal)t.Re;
            nudComplex.Value = (decimal)t.Im;
            nudSegments.Value = segments;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            t.Re = (double)nudReal.Value;
            t.Im = (double)nudComplex.Value;
            segments = (int)nudSegments.Value;
        }
    }
}
