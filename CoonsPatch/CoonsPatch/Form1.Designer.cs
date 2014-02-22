namespace CoonsPatch
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorP0 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorP1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorQ0 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorQ1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaRenderowaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrownajPionowoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrownajPoziomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaskadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.widokToolStripMenuItem,
            this.oknaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.wyjścieToolStripMenuItem.Text = "Wyjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.wyjścieToolStripMenuItem_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderWindowToolStripMenuItem,
            this.EditorP0,
            this.EditorP1,
            this.EditorQ0,
            this.EditorQ1,
            this.ustawieniaRenderowaniaToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // renderWindowToolStripMenuItem
            // 
            this.renderWindowToolStripMenuItem.Checked = true;
            this.renderWindowToolStripMenuItem.CheckOnClick = true;
            this.renderWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.renderWindowToolStripMenuItem.Name = "renderWindowToolStripMenuItem";
            this.renderWindowToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.renderWindowToolStripMenuItem.Text = "Render Window";
            this.renderWindowToolStripMenuItem.Click += new System.EventHandler(this.renderWindowToolStripMenuItem_Click);
            // 
            // EditorP0
            // 
            this.EditorP0.Name = "EditorP0";
            this.EditorP0.Size = new System.Drawing.Size(195, 22);
            this.EditorP0.Text = "P0";
            this.EditorP0.Click += new System.EventHandler(this.EditorMenuItem_Click);
            // 
            // EditorP1
            // 
            this.EditorP1.Name = "EditorP1";
            this.EditorP1.Size = new System.Drawing.Size(195, 22);
            this.EditorP1.Text = "P1";
            this.EditorP1.Click += new System.EventHandler(this.EditorMenuItem_Click);
            // 
            // EditorQ0
            // 
            this.EditorQ0.Name = "EditorQ0";
            this.EditorQ0.Size = new System.Drawing.Size(195, 22);
            this.EditorQ0.Text = "Q0";
            this.EditorQ0.Click += new System.EventHandler(this.EditorMenuItem_Click);
            // 
            // EditorQ1
            // 
            this.EditorQ1.Name = "EditorQ1";
            this.EditorQ1.Size = new System.Drawing.Size(195, 22);
            this.EditorQ1.Text = "Q1";
            this.EditorQ1.Click += new System.EventHandler(this.EditorMenuItem_Click);
            // 
            // ustawieniaRenderowaniaToolStripMenuItem
            // 
            this.ustawieniaRenderowaniaToolStripMenuItem.Name = "ustawieniaRenderowaniaToolStripMenuItem";
            this.ustawieniaRenderowaniaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ustawieniaRenderowaniaToolStripMenuItem.Text = "Ustawienia renderowania";
            this.ustawieniaRenderowaniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaRenderowaniaToolStripMenuItem_Click);
            // 
            // oknaToolStripMenuItem
            // 
            this.oknaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyrownajPionowoToolStripMenuItem,
            this.wyrownajPoziomoToolStripMenuItem,
            this.kaskadaToolStripMenuItem});
            this.oknaToolStripMenuItem.Name = "oknaToolStripMenuItem";
            this.oknaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.oknaToolStripMenuItem.Text = "Okna";
            // 
            // wyrownajPionowoToolStripMenuItem
            // 
            this.wyrownajPionowoToolStripMenuItem.Name = "wyrownajPionowoToolStripMenuItem";
            this.wyrownajPionowoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.wyrownajPionowoToolStripMenuItem.Text = "Wyrownaj poziomo";
            this.wyrownajPionowoToolStripMenuItem.Click += new System.EventHandler(this.wyrownajPionowoToolStripMenuItem_Click);
            // 
            // wyrownajPoziomoToolStripMenuItem
            // 
            this.wyrownajPoziomoToolStripMenuItem.Name = "wyrownajPoziomoToolStripMenuItem";
            this.wyrownajPoziomoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.wyrownajPoziomoToolStripMenuItem.Text = "Wyrownaj pionowo";
            this.wyrownajPoziomoToolStripMenuItem.Click += new System.EventHandler(this.wyrownajPoziomoToolStripMenuItem_Click);
            // 
            // kaskadaToolStripMenuItem
            // 
            this.kaskadaToolStripMenuItem.Name = "kaskadaToolStripMenuItem";
            this.kaskadaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.kaskadaToolStripMenuItem.Text = "Kaskada";
            this.kaskadaToolStripMenuItem.Click += new System.EventHandler(this.kaskadaToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "XML file|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML file|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 463);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Coons Patch I";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjścieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditorP0;
        private System.Windows.Forms.ToolStripMenuItem EditorP1;
        private System.Windows.Forms.ToolStripMenuItem EditorQ0;
        private System.Windows.Forms.ToolStripMenuItem EditorQ1;
        private System.Windows.Forms.ToolStripMenuItem wyrownajPionowoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyrownajPoziomoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaskadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaRenderowaniaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

