using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;

namespace CoonsPatch
{
    public partial class CurvesEditor : Form, IView
    {
        private MainForm parent;
        private Model.Spline curve;
        private bool ready = false;

        public CurvesEditor(MainForm mainForm, Model.Spline curve_)
        {
            InitializeComponent();
            this.parent = mainForm;
            this.curve = curve_;
            switch (curve)
            {
            case Model.Spline.P0: this.Text = "Krzywa P_0"; break;
            case Model.Spline.P1: this.Text = "Krzywa P_1"; break;
            case Model.Spline.Q0: this.Text = "Krzywa Q_0"; break;
            case Model.Spline.Q1: this.Text = "Krzywa Q_1"; break;
                default:
                Close();
                break;
            }

            bindingSource.DataSource = parent.CoonsPatch.GetSpline(curve);
            ready = true;
        }

        private void CurvesEditor_Load(object sender, EventArgs e)
        {
            parent.Controller.RegisterView(this);
        }

        private void CurvesEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Controller.UnregisterView(this);
            parent.curveWindowClosed(curve);
        }

        public void ModelChange(object sender, ModelChangeEventArgs e)
        {
            if (sender == this)
                return;
            bindingSource.DataSource = parent.CoonsPatch.GetSpline(curve);
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ready)
            {
                parent.CoonsPatch.SetSpline(curve, (bindingSource.DataSource as List<myVector3>).Select(x => {return (Vector3) x;}).ToArray());
                parent.Controller.RaiseModelChange(this, new ModelChangeEventArgs(curve, e.RowIndex));
            }
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
