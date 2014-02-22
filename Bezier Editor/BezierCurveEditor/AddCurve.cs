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
    public partial class FormAddCurve : Form
    {
        int degree;

        public int Degree
        {
            get
            {
                return degree;
            }
        }

        public FormAddCurve(int deg = 2)
        {
            InitializeComponent();
            degree = deg;
            numericUpDown1.Value = degree;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            degree = (int)numericUpDown1.Value;
        }
    }
}
