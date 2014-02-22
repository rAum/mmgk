using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using System.Drawing.Imaging;

namespace CoonsPatch
{
    public partial class RenderForm : Form, IView, IRenderSettings
    {
        private MainForm parent;
        private bool loaded = false;
        private RenderSettingsData settings;

        private RenderForm() {}

        public RenderForm(MainForm parent_)
        {
            InitializeComponent();
            this.parent = parent_;
            settings = new RenderSettingsData();
        }

        #region Interface MVC Members
        public void ModelChange(object sender, ModelChangeEventArgs e)
        {
            UpdateGeometry();
            Refresh();
        }

        public void RenderChange(object sender, RenderChangeEventArgs e)
        {
            settings = e.data;
            UpdateGeometry();
            Refresh();
        }
        #endregion

        int listName = 0;
        int[] listCurve = new int[4];
        Vector3 translate = new Vector3(-1.5f,-1.5f,-6);
        Matrix4 perspectiveMatrix;
        Matrix4 camMatrix;
        float angleOne = 1, angleTwo = 0;

        private void UpdateGeometry()
        {
            Model m = parent.CoonsPatch;

            GL.DeleteLists(listName, 1);
            listName = GL.GenLists(1);
            GL.NewList(listName, ListMode.Compile);

            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);
            if (settings.smoothColor)
                GL.ShadeModel(ShadingModel.Smooth);
            else
                GL.ShadeModel(ShadingModel.Flat);

            //////////////////////////////////////////

            float u, v;
            float du = (float)Math.Pow(2.0f, -settings.du),
                  dv = (float)Math.Pow(2.0f, -settings.dv);
            Vector3 point = new Vector3();
            if (settings.patch)
            {
                GL.Enable(EnableCap.PolygonOffsetFill);
                GL.PolygonOffset(2.0f, 2.0f);
                if (settings.wireframe)
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                else
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

                GL.Begin(BeginMode.TriangleStrip);
                // fajne zjawisko - obinanie v > 0.65f;
                bool toggle = true;
                for (u = 0.0f; u < settings.maxu; u += du, toggle = !toggle)
                {
                    if (toggle)
                    {
                        for (v = 0.0f; v <= settings.maxv; v += dv)
                        {
                            point = m.CoonsPatchAt(u, v);
                            GL.Color3(u, v, 0);
                            GL.Vertex3(point);
                            point = m.CoonsPatchAt(u + du, v);
                            GL.Color3(u + du, v, 0);
                            GL.Vertex3(point);
                        }
                    }
                    else
                    {
                        for (v = settings.maxv; v >= 0.0f; v -= dv)
                        {
                            point = m.CoonsPatchAt(u + du, v);
                            GL.Color3(u + du, v, 0);
                            GL.Vertex3(point);
                            point = m.CoonsPatchAt(u, v);
                            GL.Color3(u, v, 0);
                            GL.Vertex3(point);
                        }
                    }
                }
                GL.End();
            }

            //////////////////////////////////////////

            if (settings.contour)
            {
                GL.LineWidth(3.0f);
                GL.Color3(1.0f, 0, 0);
                GL.Begin(BeginMode.LineStrip);
                for (float t = 0; t <= 1.0f; t += du * 0.5f)
                    GL.Vertex3(m.Evaluate(Model.Spline.P0, t));
                GL.End();

                GL.Color3(0.0f, 0, 1.0f);
                GL.Begin(BeginMode.LineStrip);
                for (float t = 0; t <= 1.0f; t += du * 0.5f)
                    GL.Vertex3(m.Evaluate(Model.Spline.Q0, t));
                GL.End();

                GL.Color3(1.0f, 0, 0);
                GL.Begin(BeginMode.LineStrip);
                for (float t = 0; t <= 1.0f; t += du * 0.5f)
                    GL.Vertex3(m.Evaluate(Model.Spline.P1, t));
                GL.End();

                GL.Color3(0.0f, 0, 1.0f);
                GL.Begin(BeginMode.LineStrip);
                for (float t = 0; t <= 1.0f; t += du * 0.5f)
                    GL.Vertex3(m.Evaluate(Model.Spline.Q1, t));
                GL.End();
            }

            //////////////////////////////////////////

            if (settings.controlCurve)
            {
                GL.LineWidth(2.0f);
                GL.Color3(0.5f, 0.5f, 0.5f);
                GL.Begin(BeginMode.LineStrip);
                foreach (var p in m.GetSpline(Model.Spline.P0))
                    GL.Vertex3(p);
                GL.End();
                GL.Begin(BeginMode.LineStrip);
                foreach (var p in m.GetSpline(Model.Spline.P1))
                    GL.Vertex3(p);
                GL.End();
                GL.Begin(BeginMode.LineStrip);
                foreach (var p in m.GetSpline(Model.Spline.Q1))
                    GL.Vertex3(p);
                GL.End();
                GL.Begin(BeginMode.LineStrip);
                foreach (var p in m.GetSpline(Model.Spline.Q0))
                    GL.Vertex3(p);
                GL.End();
            }

            //////////////////////////////////////////
            if (settings.controlPoints)
            {
                GL.Color3(1.0f, 1.0f, 1.0f);
                GL.Begin(BeginMode.Points);
                GL.PointSize(8.0f);
                foreach (var p in m.GetSpline(Model.Spline.P0))
                    GL.Vertex3(p);
                foreach (var p in m.GetSpline(Model.Spline.P1))
                    GL.Vertex3(p);
                foreach (var p in m.GetSpline(Model.Spline.Q1))
                    GL.Vertex3(p);
                foreach (var p in m.GetSpline(Model.Spline.Q0))
                    GL.Vertex3(p);
                GL.End();
            }

            ////////////////////////////////////////////

            GL.EndList();
        }

        private void RenderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Controller.UnregisterView(this);
            parent.Controller.UnregisterSettings(this);
            parent.renderWindowClosed();
        }

        private void zapiszRenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphicsContext.CurrentContext == null || loaded == false)
                return;

            if (loaded && saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
                BitmapData data = bmp.LockBits(this.ClientRectangle, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                GL.ReadPixels(0, 0, ClientSize.Width, ClientSize.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
                bmp.UnlockBits(data);

                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                bmp.Save(saveFileDialog.FileName);
            }
        }

        private float toRad(float a)
        {
            return a * (float)Math.PI / 180.0f;
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Vector3 cam = new Vector3(
                translate.Z * (float)(Math.Sin(toRad(angleTwo)) * Math.Cos(toRad(angleOne))),
                translate.Z * (float)(Math.Sin(toRad(angleTwo)) * Math.Sin(toRad(angleOne))),
                translate.Z * (float)(Math.Cos(toRad(angleTwo)))
                );
            camMatrix = Matrix4.LookAt(cam, new Vector3(0, 0, 0), new Vector3((float)Math.Cos(toRad(angleOne)), (float)Math.Sin(toRad(angleOne)), 1));
            
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camMatrix);

            GL.Translate(translate.X, translate.Y, 0);

            GL.CallList(listName);

            glControl.SwapBuffers();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(0.3f, 0.31f, 0.31f, 0.1f);
            SetupViewport();

            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);
            GL.ShadeModel(ShadingModel.Flat);
            
            parent.Controller.RegisterView(this);
            parent.Controller.RegisterSettings(this);

            UpdateGeometry();
        }

        private void SetupViewport()
        {
            int w = glControl.Width;
            int h = glControl.Height;

            if (h == 0)
                h = 1;
            float aspect = (float)w / (float)h;

            GL.Viewport(0, 0, w, h);
            perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4.0f, aspect, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiveMatrix);
        }

        private void RenderForm_KeyDown(object sender, KeyEventArgs e)
        {
            const float changeRate = 0.1f;
            switch (e.KeyCode)
            {
                case Keys.W:
                    translate.Y += changeRate;
                    break;
                case Keys.S:
                    translate.Y -= changeRate; break;
                case Keys.A:
                    translate.X -= changeRate; break;
                case Keys.D:
                    translate.X += changeRate; break;
                case Keys.Z:
                    translate.Z += changeRate; break;
                case Keys.X:
                    translate.Z -= changeRate; break;
                case Keys.I:
                    angleTwo += 1f; break;
                case Keys.K:
                    angleTwo -= 1f; break;
                case Keys.J:
                    angleOne += 1f; break;
                case Keys.L:
                    angleOne -= 1f; break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void RenderForm_Resize(object sender, EventArgs e)
        {
            SetupViewport();
        }
    }
}
