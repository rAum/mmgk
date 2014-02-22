using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using OpenTK;

namespace CoonsPatch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            model = new Model();
            control = new Controller();

            this.menuStrip1.MdiWindowListItem = this.oknaToolStripMenuItem;

            renderForm = new RenderForm(this);
            renderForm.MdiParent = this;
            renderForm.Show();
        }

        RenderForm renderForm;
        RenderSettings renderSettingsForm;
        CurvesEditor[] editorForm = new CurvesEditor[4];
        Model model; // CoonsPatch model
        Controller control;

        public Model CoonsPatch
        {
            get { return model; }
        }

        public Controller Controller
        {
            get { return control; }
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void renderWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (renderWindowToolStripMenuItem.Checked)
            {
                renderForm = new RenderForm(this);
                renderForm.MdiParent = this;
                renderForm.Show();
            }
            else
            {
                renderForm.Close();
            }
        }

        internal void renderWindowClosed()
        {
            renderWindowToolStripMenuItem.Checked = false;
        }

        private void EditorMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Model.Spline spline = Model.Spline.Q1;

            if (menuItem == EditorP0)      spline = Model.Spline.P0;
            else if (menuItem == EditorP1) spline = Model.Spline.P1;
            else if (menuItem == EditorQ0) spline = Model.Spline.Q0;

            menuItem.Checked = !menuItem.Checked;
            if (menuItem.Checked)
            {
                editorForm[(int)spline] = new CurvesEditor(this, spline);
                editorForm[(int)spline].MdiParent = this;
                editorForm[(int)spline].Show();
            }
            else
            {
                if (editorForm[(int)spline] != null)
                    editorForm[(int)spline].Close();
            }
        }

        private void wyrownajPionowoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void wyrownajPoziomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void aranzacjaIkonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void kaskadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void ustawieniaRenderowaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ustawieniaRenderowaniaToolStripMenuItem.Checked = !ustawieniaRenderowaniaToolStripMenuItem.Checked;
            if (ustawieniaRenderowaniaToolStripMenuItem.Checked)
            {
                renderSettingsForm = new RenderSettings(this);
                renderSettingsForm.MdiParent = this;
                renderSettingsForm.Show();
            }
            else if (renderSettingsForm != null)
            {
                renderSettingsForm.Close();
            }
        }

        internal void renderSettingsWindowClosed()
        {
            ustawieniaRenderowaniaToolStripMenuItem.Checked = false;
        }

        internal void curveWindowClosed(Model.Spline spline)
        {
            ToolStripMenuItem menuItem;

            switch (spline)
            {
                case Model.Spline.P0: menuItem = EditorP0; break;
                case Model.Spline.P1: menuItem = EditorP1; break;
                case Model.Spline.Q0: menuItem = EditorQ0; break;
                default:
                    menuItem = EditorQ1; break;
            }

            menuItem.Checked = false;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XDocument xml = XDocument.Load(openFileDialog.FileName);
                string[] names = { "P0", "P1", "Q0", "Q1" };
                for (int i = 0; i < 4; ++i)
                {

                    var array = (from point in xml.Descendants("point")
                              where point.Parent.Name == names[i]
                              select new Vector3
                              {
                                  X = (float)point.Attribute("x"),
                                  Y = (float)point.Attribute("y"),
                                  Z = (float)point.Attribute("z")
                              }).ToArray();

                    model.SetSpline(i, array);
                    Controller.RaiseModelChange(this, null);
                }
            }
        }
       

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(saveFileDialog.FileName, Encoding.UTF8);

                var xml_p0 = new XElement("P0", model.GetSpline(Model.Spline.P0).Select(
                    x => new XElement("point", new XAttribute("x",x.X), new XAttribute("y",x.Y), new XAttribute("z",x.Z) )));
                var xml_p1 = new XElement("P1", model.GetSpline(Model.Spline.P1).Select(
                    x => new XElement("point", new XAttribute("x", x.X), new XAttribute("y", x.Y), new XAttribute("z", x.Z))));
                var xml_q0 = new XElement("Q0", model.GetSpline(Model.Spline.Q0).Select(
                    x => new XElement("point", new XAttribute("x", x.X), new XAttribute("y", x.Y), new XAttribute("z", x.Z))));
                var xml_q1 = new XElement("Q1", model.GetSpline(Model.Spline.Q1).Select(
                    x => new XElement("point", new XAttribute("x", x.X), new XAttribute("y", x.Y), new XAttribute("z", x.Z))));
                var xml = new XElement("coons-one", new XElement[]{xml_p0, xml_p1, xml_q0, xml_q1} );

                xml.Save(xmlWriter);

                xmlWriter.Close();
            }
        }
    }
}
