using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoonsPatch
{
    public partial class RenderSettings : Form
    {
        private MainForm mainForm;
        private RenderSettingsData data;

        public RenderSettings(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            data = mainForm.CoonsPatch.settings;

            checkBox1.Checked = data.wireframe;
            checkBox2.Checked = data.controlPoints;
            checkBox3.Checked = data.controlCurve;
            checkBox4.Checked = data.smoothColor;

            checkBox5.Checked = data.patch;
            checkBox6.Checked = data.contour;

            numericUpDown1.Value = (decimal)data.dv;
            numericUpDown2.Value = (decimal)data.du;

            numericUpDown3.Value = (decimal)data.A;
            numericUpDown4.Value = (decimal)data.B;
            numericUpDown5.Value = (decimal)data.C;

            if (data.lerp == new RenderSettingsData.InBetweenDelegate(RenderSettingsData.sincos))
                radioButton5.Checked = true;
            else if (data.lerp == new RenderSettingsData.InBetweenDelegate(RenderSettingsData.hermite))
                radioButton4.Checked = true;
            else
                radioButton3.Checked = true;

            trackBarV.Value = Convert.ToInt32(data.maxv * 100.0f);
            trackBarU.Value = Convert.ToInt32(data.maxu * 100.0f);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            data.wireframe = checkBox1.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            data.controlPoints = checkBox2.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            data.controlCurve = checkBox3.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            data.smoothColor = checkBox4.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            data.du = (float)numericUpDown2.Value;
            data.dv = (float)numericUpDown1.Value;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            data.A = (float)numericUpDown3.Value;
            data.B = (float)numericUpDown4.Value;
            data.C = (float)numericUpDown5.Value;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            data.patch = checkBox5.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.linear);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.sincos);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.hermite);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp2 = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.linear);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp2 = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.sincos);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false)
                return;

            data.lerp2 = new RenderSettingsData.InBetweenDelegate(RenderSettingsData.hermite);
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            data.contour = checkBox6.Checked;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void RenderSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.renderSettingsWindowClosed();
        }

        private void trackBarU_ValueChanged(object sender, EventArgs e)
        {
            data.maxv = trackBarV.Value * 0.01f;
            data.maxu = trackBarU.Value * 0.01f;
            mainForm.Controller.RaiseSettingsChange(this, new RenderChangeEventArgs(data));
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == false)
                mainForm.CoonsPatch.Evaluate = new CoonsPatch.Model.EvaluateDelegate(mainForm.CoonsPatch.Bezier);
            else
                mainForm.CoonsPatch.Evaluate = new CoonsPatch.Model.EvaluateDelegate(mainForm.CoonsPatch.CatmullRom);
            mainForm.Controller.RaiseModelChange(this, new ModelChangeEventArgs(0, 0));
        }
    }
}
