namespace BezierCurveEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.workingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.contextPoint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.podniesStopienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeSplinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fractalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.usunKrzywaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.contextGlobal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rysujOtoczkeWypuklaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rysujKrzywaKontrolnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rysujKrzywaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rysujPunktyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.drawingPanel = new BezierCurveEditor.DoubleBufferPanel();
            this.statusStrip.SuspendLayout();
            this.contextPoint.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workingMode,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 629);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1016, 23);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // workingMode
            // 
            this.workingMode.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workingMode.ForeColor = System.Drawing.Color.LightCoral;
            this.workingMode.Name = "workingMode";
            this.workingMode.Size = new System.Drawing.Size(55, 18);
            this.workingMode.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 17);
            // 
            // contextPoint
            // 
            this.contextPoint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podniesStopienToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.mergeSplinesToolStripMenuItem,
            this.fractalizeToolStripMenuItem,
            this.toolStripSeparator3,
            this.usunKrzywaToolStripMenuItem});
            this.contextPoint.Name = "pointContext";
            this.contextPoint.Size = new System.Drawing.Size(137, 120);
            // 
            // podniesStopienToolStripMenuItem
            // 
            this.podniesStopienToolStripMenuItem.Name = "podniesStopienToolStripMenuItem";
            this.podniesStopienToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.podniesStopienToolStripMenuItem.Text = "Ustal stopien";
            this.podniesStopienToolStripMenuItem.Click += new System.EventHandler(this.podniesStopienToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteToolStripMenuItem.Text = "Usun punkt";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // mergeSplinesToolStripMenuItem
            // 
            this.mergeSplinesToolStripMenuItem.Name = "mergeSplinesToolStripMenuItem";
            this.mergeSplinesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.mergeSplinesToolStripMenuItem.Text = "Scal krzywe";
            this.mergeSplinesToolStripMenuItem.Click += new System.EventHandler(this.scalKrzyweToolStripMenuItem_Click);
            // 
            // fractalizeToolStripMenuItem
            // 
            this.fractalizeToolStripMenuItem.Name = "fractalizeToolStripMenuItem";
            this.fractalizeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fractalizeToolStripMenuItem.Text = "Fraktalizuj";
            this.fractalizeToolStripMenuItem.Click += new System.EventHandler(this.fractalizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // usunKrzywaToolStripMenuItem
            // 
            this.usunKrzywaToolStripMenuItem.Name = "usunKrzywaToolStripMenuItem";
            this.usunKrzywaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.usunKrzywaToolStripMenuItem.Text = "Usun krzywa";
            this.usunKrzywaToolStripMenuItem.Click += new System.EventHandler(this.usunKrzywaToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton2.Text = "Nowy";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton4.Text = "Otwórz";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton3.Text = "Zapisz";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton6.Text = "Dodaj krzywą";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(94, 22);
            this.toolStripButton7.Text = "Konstruuj krzywą";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(94, 22);
            this.toolStripButton1.Text = "Konstruuj ścieżkę";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // contextGlobal
            // 
            this.contextGlobal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rysujOtoczkeWypuklaToolStripMenuItem,
            this.rysujKrzywaKontrolnaToolStripMenuItem,
            this.rysujKrzywaToolStripMenuItem,
            this.rysujPunktyToolStripMenuItem});
            this.contextGlobal.Name = "contextGlobal";
            this.contextGlobal.Size = new System.Drawing.Size(187, 92);
            // 
            // rysujOtoczkeWypuklaToolStripMenuItem
            // 
            this.rysujOtoczkeWypuklaToolStripMenuItem.Name = "rysujOtoczkeWypuklaToolStripMenuItem";
            this.rysujOtoczkeWypuklaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rysujOtoczkeWypuklaToolStripMenuItem.Text = "Rysuj otoczke wypukla";
            this.rysujOtoczkeWypuklaToolStripMenuItem.Click += new System.EventHandler(this.rysujOtoczkeWypuklaToolStripMenuItem_Click);
            // 
            // rysujKrzywaKontrolnaToolStripMenuItem
            // 
            this.rysujKrzywaKontrolnaToolStripMenuItem.Name = "rysujKrzywaKontrolnaToolStripMenuItem";
            this.rysujKrzywaKontrolnaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rysujKrzywaKontrolnaToolStripMenuItem.Text = "Rysuj krzywa kontrolna";
            this.rysujKrzywaKontrolnaToolStripMenuItem.Click += new System.EventHandler(this.rysujKrzywaKontrolnaToolStripMenuItem_Click);
            // 
            // rysujKrzywaToolStripMenuItem
            // 
            this.rysujKrzywaToolStripMenuItem.Name = "rysujKrzywaToolStripMenuItem";
            this.rysujKrzywaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rysujKrzywaToolStripMenuItem.Text = "Rysuj krzywa";
            this.rysujKrzywaToolStripMenuItem.Click += new System.EventHandler(this.rysujKrzywaToolStripMenuItem_Click);
            // 
            // rysujPunktyToolStripMenuItem
            // 
            this.rysujPunktyToolStripMenuItem.Name = "rysujPunktyToolStripMenuItem";
            this.rysujPunktyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rysujPunktyToolStripMenuItem.Text = "Rysuj punkty";
            this.rysujPunktyToolStripMenuItem.Click += new System.EventHandler(this.rysujPunktyToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Bezier Curve File|*.bcf|All files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Bezier Curve File|*.bcf|All files|*.*";
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.drawingPanel.BackgroundImage = global::BezierCurveEditor.Properties.Resources.bkg2;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingPanel.CausesValidation = false;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 25);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1016, 627);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Click += new System.EventHandler(this.drawingPanel_Click);
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseEnter += new System.EventHandler(this.drawingPanel_MouseEnter);
            this.drawingPanel.MouseLeave += new System.EventHandler(this.drawingPanel_MouseLeave);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::BezierCurveEditor.Properties.Resources.bkg2;
            this.ClientSize = new System.Drawing.Size(1016, 652);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Bezier Curve Editor";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextPoint.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextGlobal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferPanel drawingPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ContextMenuStrip contextPoint;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripStatusLabel workingMode;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ContextMenuStrip contextGlobal;
        private System.Windows.Forms.ToolStripMenuItem rysujOtoczkeWypuklaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rysujKrzywaKontrolnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fractalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rysujKrzywaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rysujPunktyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podniesStopienToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem usunKrzywaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeSplinesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

