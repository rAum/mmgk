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
    public partial class MainWindow : Form
    {
        List<BezierSet> beziers;

        enum Mode
        {
            Normal, // przesuwanie punktów kontrolnych
            AddingNewCurve, // dodawanie nowej krzywej
            ConstructCurve, // konstrukcja krzywej
            Deleting, // usuwanie punktów kontrolnych
            Scaling, // skaluje
            Merging, // scalanie krzywych
            PathCreate // tworzenie sklejanej sciezki
        };

        Mode mode;
        #region data for modes
        class ModeAddNew
        {
            public int have = 0;
            public bool canAdd = false;
            public Complex[] pt = new Complex[must];
            const int must = 2;
            public void Add(Point p)
            {
                if (!Ready())
                    pt[have++] = new Complex(p.X, p.Y);
            }
            public bool Ready()
            {
                return have == must;
            }
        }

        class ModeConstruct
        {
            public List<Complex> pt = new List<Complex>();
            public Bezier bezier;
            public bool CanBeDrawed() { return pt.Count > 1; }
            public void Add(Point p)
            {
                pt.Add(new Complex(p.X, p.Y));
                if (pt.Count > 1)
                    bezier = new Bezier(pt.ToArray());
            }
            public BezierSet currentSet = null;
            public bool exit = false;
        }

        class ModeNormal
        {
            public CurrentPtr ptr = null;
            public bool tracking = false;
        }
        #endregion

        ModeAddNew addnew;
        ModeConstruct construct;
        ModeNormal normalMode;

        Mode WorkingMode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
                workingMode.Text = String.Format("Tryb: {0}. ", mode.ToString());
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            NewEmpty();
        }

        private void NewEmpty()
        {
            beziers = new List<BezierSet>();
            normalMode = new ModeNormal();
            WorkingMode = Mode.Normal;
            drawingPanel.Invalidate();
        }

        private void AddNewCurve()
        {
            addnew = new ModeAddNew();
            WorkingMode = Mode.AddingNewCurve;
        }

        private void Construct()
        {
            construct = new ModeConstruct();
            WorkingMode = Mode.ConstructCurve;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            NewEmpty();
        }

        private void drawingPanel_Click(object sender, EventArgs e)
        {
            MouseEventArgs mos = e as MouseEventArgs;
            switch (mode)
            {
                case Mode.ConstructCurve:
                case Mode.PathCreate:
                    if (mos.Button == MouseButtons.Left)
                    {
                        construct.Add(mos.Location);
                        (sender as Panel).Invalidate();
                        construct.exit = false;
                    }
                    else if (mos.Button == MouseButtons.Right)
                    {
                        if (mode == Mode.PathCreate)
                        {
                            if (construct.exit)
                            {
                                WorkingMode = Mode.Normal;
                                Cursor = Cursors.Default;
                            }
                            else if (construct.CanBeDrawed() && construct.currentSet == null) // first curve
                            {
                                Complex last = new Complex(construct.bezier.points[construct.bezier.points.Count - 1]);
                                construct.currentSet = new BezierSet(construct.bezier);
                                beziers.Add(construct.currentSet);
                                construct.bezier = new Bezier();

                                construct.pt = new List<Complex>();
                                construct.Add(new Point((int)last.Re, (int)last.Im));
                            }
                            else if (construct != null && construct.currentSet != null && construct.bezier != null)
                            {
                                var last = construct.currentSet.set.Last();
                                construct.currentSet.set.Add(construct.bezier);
                                last.ConnectRight(construct.bezier, false); // polacz z pierwszym
                                Complex l = construct.bezier.points[construct.bezier.Degree - 1];

                                construct.pt = new List<Complex>();
                                construct.Add(new Point((int)l.Re, (int)l.Im));
                            }
                            construct.exit = true;
                        }
                        else
                        {
                            if (construct != null && construct.bezier != null && construct.bezier.points.Count > 1)
                            {
                                beziers.Add(new BezierSet(construct.bezier));
                            }
                            WorkingMode = Mode.Normal;
                            Cursor = Cursors.Default;
                        }
                        (sender as Panel).Invalidate();
                    }
                    break;

                case Mode.AddingNewCurve:
                    if (mos.Button == MouseButtons.Left)
                    {
                        addnew.Add(mos.Location);
                        (sender as Panel).Invalidate();
                        if (addnew.Ready())
                        {
                            Cursor = Cursors.Arrow;
                            FormAddCurve ask = new FormAddCurve();

                            ask.ShowDialog(this);
                            
                            // construct curve with enough control points
                            Bezier b = new Bezier(addnew.pt, ask.Degree - 2);

                            beziers.Add(new BezierSet(b));

                            // exit adding curve
                            WorkingMode = Mode.Normal;
                            drawingPanel.Invalidate();
                        }
                    }
                    break;
                case Mode.Merging:
                    if (mos.Button == MouseButtons.Right)
                        WorkingMode = Mode.Normal;
                    else if (mos.Button == MouseButtons.Left)
                    {
                        var p = FindNearestPoint(mos);
                        if (p != null)
                        {
                            if (normalMode.ptr.i == 0) // jesli zaznaczony byl po lewej
                            {
                                if (normalMode.ptr.bez.ConnectLeft(p.bez, p.i != 0)) // to dopnij z prawej strony z odpowiednim koncem
                                {
                                    if (p.bset != normalMode.ptr.bset)
                                    {
                                        normalMode.ptr.bset.Add(p.bset);
                                        beziers.Remove(p.bset);
                                    }
                                    drawingPanel.Invalidate();
                                    WorkingMode = Mode.Normal;
                                }

                            }
                            else if (normalMode.ptr.i == normalMode.ptr.bez.Degree - 1)
                            {
                                if (normalMode.ptr.bez.ConnectRight(p.bez, p.i != 0))
                                {
                                    if (p.bset != normalMode.ptr.bset)
                                    {
                                        normalMode.ptr.bset.Add(p.bset);
                                        beziers.Remove(p.bset);
                                    }
                                    drawingPanel.Invalidate();
                                    WorkingMode = Mode.Normal;
                                }

                            }
                        }
                    }
                    break;
            }
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.ConstructCurve:
                case Mode.PathCreate:
                    //if ((Control.ModifierKeys & Keys.Shift) != 0)
                    //    goto case Mode.Normal;
                    break;
                case Mode.Normal:
                    if (normalMode.ptr != null && normalMode.tracking)
                    {
                        Complex pos = new Complex(Math.Min(e.X, drawingPanel.Width-4), Math.Min(e.Y, drawingPanel.Height-4-statusStrip.Height));
                        pos.x = Math.Max(4, pos.x);
                        pos.y = Math.Max(4, pos.y);
                        if ((Control.ModifierKeys & Keys.Shift) > 0)
                            normalMode.ptr.bez.Set(normalMode.ptr.i, pos, false, false);
                        else
                            normalMode.ptr.bez.Set(normalMode.ptr.i, pos);
                        drawingPanel.Invalidate();
                    }
                    break;
            }
        }

        private void drawingPanel_MouseEnter(object sender, EventArgs e)
        {
            switch (mode)
            {
                case Mode.ConstructCurve:
                case Mode.PathCreate:
                    Cursor = Cursors.Cross;
                    break;
                case Mode.AddingNewCurve:
                    if (!addnew.Ready())
                        Cursor = Cursors.Cross;
                    break;
            }
        }

        private void drawingPanel_MouseLeave(object sender, EventArgs e)
        {
            switch (mode)
            {
                case Mode.AddingNewCurve:
                case Mode.ConstructCurve:
                case Mode.PathCreate:
                    Cursor = Cursors.Default;
                    break;
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (mode == Mode.ConstructCurve || mode == Mode.PathCreate)
            {
                if (construct.CanBeDrawed())
                {
                    BezierUtils.DrawBezier(e, construct.bezier);
                    BezierUtils.DrawPoints(e, construct.bezier, Brushes.Red, Brushes.Cyan);
                }
            }

            switch (mode)
            {
                case Mode.AddingNewCurve:
                    for (int i = 0; i < addnew.have; ++i)
                    {
                        e.Graphics.FillEllipse(Brushes.Red, BezierUtils.ComplexToRect(addnew.pt[i]));
                    }
                    break;
                case Mode.Normal:
                    if (normalMode.tracking && normalMode.ptr != null)
                    {
                        e.Graphics.FillEllipse(Brushes.FloralWhite, BezierUtils.ComplexToRect(normalMode.ptr.bez.points[normalMode.ptr.i], 5));
                    }
                break;
            }

            foreach (var b in beziers)
            {
                b.Draw(e, drawCurve, drawPoints, drawConvexHull, drawConnectingLines);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            AddNewCurve();
        }

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            WorkingMode = Mode.Normal;
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.ConstructCurve:
                case Mode.PathCreate:
                    if ((Control.ModifierKeys & Keys.Shift) == 0)
                        break;
                    goto case Mode.Normal;
                case Mode.Normal:
                    if (e.Button == MouseButtons.Left)
                    {
                        normalMode.ptr = null;
                        // find nearest point
                        int n = beziers.Count;
                        for (int i = 0; i < n; ++i)
                        {
                            normalMode.ptr = beziers[i].Find(e.Location, 5);
                            if (normalMode.ptr != null)
                                break;
                            drawingPanel.Invalidate();
                        }

                        // if founded, turn tracking on
                        if (normalMode.ptr != null)
                        {
                            Cursor = Cursors.Hand;
                            normalMode.tracking = true;
                            drawingPanel.Invalidate();
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        // find nearest point
                        normalMode.ptr = FindNearestPoint(e);

                        // if founded, show point context menu
                        if (normalMode.ptr != null)
                        {
                            int i = normalMode.ptr.i;
                            deleteToolStripMenuItem.Enabled = normalMode.ptr.bez.points.Count > 2;
                            mergeSplinesToolStripMenuItem.Enabled = i == 0 || i == (normalMode.ptr.bez.points.Count - 1);
                            contextPoint.Show(PointToScreen(e.Location));
                        }
                        else
                        {
                            contextGlobal.Show(PointToScreen(e.Location));
                        }
                    }
                    break;

            }
        }

        private CurrentPtr FindNearestPoint(MouseEventArgs e, int threshold = 6)
        {
            CurrentPtr ptr = null;
            int n = beziers.Count;
            for (int i = 0; i < n; ++i)
            {
                ptr = beziers[i].Find(e.Location, threshold);
                if (ptr != null)
                    return ptr; 
            }
            return ptr;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (normalMode != null && normalMode.tracking)
            {
                normalMode.tracking = false;
                normalMode.ptr = null;
                Cursor = Cursors.Arrow;
                drawingPanel.Invalidate();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Construct();
        }

        bool drawConvexHull = true;
        bool drawConnectingLines = false;
        bool drawPoints = true;
        bool drawCurve = true;

        private void rysujOtoczkeWypuklaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawConvexHull = !drawConvexHull;
            drawingPanel.Invalidate();
        }

        private void rysujKrzywaKontrolnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawConnectingLines = !drawConnectingLines;
            drawingPanel.Invalidate();
        }

        private void rysujKrzywaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawCurve = !drawCurve;
            drawingPanel.Invalidate();
        }

        private void rysujPunktyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawPoints = !drawPoints;
            drawingPanel.Invalidate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (normalMode.ptr != null)
            {
                normalMode.ptr.bez.points.RemoveAt(normalMode.ptr.i);
                drawingPanel.Invalidate();
            }
        }

        private void fractalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FractalizeForm fract = new FractalizeForm(false);

            fract.ShowDialog(this);

            //var old = normalMode.ptr.bez;
            //var newBez = normalMode.ptr.bez.Subdivide(fract.DivPoint);

            //newBez[0].ConnectLeft(old.left, old.leftNode != 0, true);
            //newBez[1].ConnectRight(old.right, old.rightNode != 0, true);

            //newBez[0].ConnectRight(newBez[1], false); // podepnij po prawej stronie pierwszy

            //normalMode.ptr.bset.set.Remove(old);
            //normalMode.ptr.bset.Add(newBez[0]);
            //normalMode.ptr.bset.Add(newBez[1]);

            List<Bezier> input = new List<Bezier>();
            List<Bezier> output = new List<Bezier>();

            input.Add(normalMode.ptr.bez);
            normalMode.ptr.bset.set.Remove(normalMode.ptr.bez);

            for (int i = 1; i <= fract.Segments; ++i)
            {
                foreach (var bezier in input)
                {
                    var nb = bezier.Subdivide(fract.DivPoint);
                    nb[0].ConnectLeft(bezier.left, bezier.leftNode != 0, true);
                    nb[1].ConnectRight(bezier.right, bezier.rightNode != 0, true);
                    nb[0].ConnectRight(nb[1], false); // podepnij po prawej stronie pierwszy
                    output.AddRange(nb);
                }
                input = output;
                output = new List<Bezier>(2 * input.Count);
            }

            normalMode.ptr.bset.set.AddRange(input.ToArray());
            
            drawingPanel.Invalidate();
        }

        private void podniesStopienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (normalMode.ptr != null)
            {
                int degree = normalMode.ptr.bez.points.Count;
                FormAddCurve form = new FormAddCurve(degree);
                form.ShowDialog(this);

                int diff = form.Degree - degree;
                if (diff > 0)
                    normalMode.ptr.bez.DegreeElevate(diff);
                else if (diff < 0)
                    normalMode.ptr.bez.DegreeReduction(-diff);
                else return;
                drawingPanel.Invalidate();
            }
        }

        private void usunKrzywaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (normalMode.ptr != null)
            {
                //normalMode.ptr.bset.set.Remove(normalMode.ptr.bez);
                //if (normalMode.ptr.bset.set.Count == 0)
                //{
                    beziers.Remove(normalMode.ptr.bset);
                //}
                drawingPanel.Invalidate();
            }
        }

        private void scalKrzyweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (normalMode.ptr != null)
            {
                WorkingMode = Mode.Merging;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                NewEmpty();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Construct();
            WorkingMode = Mode.PathCreate;
        }

    }
}
