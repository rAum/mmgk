namespace BezierCurveEditor
{
    partial class FractalizeForm
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
            this.nudReal = new System.Windows.Forms.NumericUpDown();
            this.nudComplex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSegments = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // nudReal
            // 
            this.nudReal.DecimalPlaces = 3;
            this.nudReal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudReal.Location = new System.Drawing.Point(127, 7);
            this.nudReal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReal.Name = "nudReal";
            this.nudReal.Size = new System.Drawing.Size(71, 20);
            this.nudReal.TabIndex = 0;
            this.nudReal.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudReal.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // nudComplex
            // 
            this.nudComplex.DecimalPlaces = 3;
            this.nudComplex.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudComplex.Location = new System.Drawing.Point(127, 33);
            this.nudComplex.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudComplex.Name = "nudComplex";
            this.nudComplex.Size = new System.Drawing.Size(71, 20);
            this.nudComplex.TabIndex = 1;
            this.nudComplex.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Część rzeczywista:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Część zespolona:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Liczba segmentów:";
            // 
            // nudSegments
            // 
            this.nudSegments.Location = new System.Drawing.Point(127, 60);
            this.nudSegments.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.nudSegments.Name = "nudSegments";
            this.nudSegments.Size = new System.Drawing.Size(71, 20);
            this.nudSegments.TabIndex = 5;
            this.nudSegments.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSegments.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FractalizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 115);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudSegments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudComplex);
            this.Controls.Add(this.nudReal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FractalizeForm";
            this.Text = "Fraktalizacja";
            ((System.ComponentModel.ISupportInitialize)(this.nudReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudReal;
        private System.Windows.Forms.NumericUpDown nudComplex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSegments;
        private System.Windows.Forms.Button button1;
    }
}