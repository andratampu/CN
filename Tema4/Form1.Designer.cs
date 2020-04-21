namespace Tema4
{
    partial class Form1
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
            this.readMatrixButton = new System.Windows.Forms.Button();
            this.citesteVectorB = new System.Windows.Forms.Button();
            this.validA = new System.Windows.Forms.Label();
            this.calculeazaXButton = new System.Windows.Forms.Button();
            this.p_val = new System.Windows.Forms.NumericUpDown();
            this.AxBNorma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_val)).BeginInit();
            this.SuspendLayout();
            // 
            // readMatrixButton
            // 
            this.readMatrixButton.Location = new System.Drawing.Point(29, 39);
            this.readMatrixButton.Name = "readMatrixButton";
            this.readMatrixButton.Size = new System.Drawing.Size(91, 41);
            this.readMatrixButton.TabIndex = 0;
            this.readMatrixButton.Text = "Citeste A";
            this.readMatrixButton.UseVisualStyleBackColor = true;
            this.readMatrixButton.Click += new System.EventHandler(this.readMatrixButton_Click);
            // 
            // citesteVectorB
            // 
            this.citesteVectorB.Location = new System.Drawing.Point(29, 97);
            this.citesteVectorB.Name = "citesteVectorB";
            this.citesteVectorB.Size = new System.Drawing.Size(91, 41);
            this.citesteVectorB.TabIndex = 1;
            this.citesteVectorB.Text = "Citeste B";
            this.citesteVectorB.UseVisualStyleBackColor = true;
            this.citesteVectorB.Click += new System.EventHandler(this.citesteVectorB_Click);
            // 
            // validA
            // 
            this.validA.AutoSize = true;
            this.validA.Location = new System.Drawing.Point(126, 51);
            this.validA.Name = "validA";
            this.validA.Size = new System.Drawing.Size(47, 17);
            this.validA.TabIndex = 2;
            this.validA.Text = "Valid: ";
            // 
            // calculeazaXButton
            // 
            this.calculeazaXButton.Location = new System.Drawing.Point(28, 156);
            this.calculeazaXButton.Name = "calculeazaXButton";
            this.calculeazaXButton.Size = new System.Drawing.Size(92, 43);
            this.calculeazaXButton.TabIndex = 3;
            this.calculeazaXButton.Text = "Calculeaza X";
            this.calculeazaXButton.UseVisualStyleBackColor = true;
            this.calculeazaXButton.Click += new System.EventHandler(this.calculeazaXButton_Click);
            // 
            // p_val
            // 
            this.p_val.Location = new System.Drawing.Point(29, 217);
            this.p_val.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.p_val.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.p_val.Name = "p_val";
            this.p_val.Size = new System.Drawing.Size(91, 22);
            this.p_val.TabIndex = 4;
            this.p_val.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // AxBNorma
            // 
            this.AxBNorma.AutoSize = true;
            this.AxBNorma.Location = new System.Drawing.Point(126, 169);
            this.AxBNorma.Name = "AxBNorma";
            this.AxBNorma.Size = new System.Drawing.Size(58, 17);
            this.AxBNorma.TabIndex = 5;
            this.AxBNorma.Text = "Norma: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AxBNorma);
            this.Controls.Add(this.p_val);
            this.Controls.Add(this.calculeazaXButton);
            this.Controls.Add(this.validA);
            this.Controls.Add(this.citesteVectorB);
            this.Controls.Add(this.readMatrixButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.p_val)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readMatrixButton;
        private System.Windows.Forms.Button citesteVectorB;
        private System.Windows.Forms.Label validA;
        private System.Windows.Forms.Button calculeazaXButton;
        private System.Windows.Forms.NumericUpDown p_val;
        private System.Windows.Forms.Label AxBNorma;
    }
}

