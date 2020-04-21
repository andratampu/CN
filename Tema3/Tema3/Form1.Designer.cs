namespace Tema3
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
            this.readA = new System.Windows.Forms.Button();
            this.readB = new System.Windows.Forms.Button();
            this.readAplusB = new System.Windows.Forms.Button();
            this.readAoriB = new System.Windows.Forms.Button();
            this.validA = new System.Windows.Forms.Label();
            this.validB = new System.Windows.Forms.Label();
            this.validAplusB = new System.Windows.Forms.Label();
            this.validAoriB = new System.Windows.Forms.Label();
            this.calculAplusB = new System.Windows.Forms.Button();
            this.calcAplusB = new System.Windows.Forms.Label();
            this.calculAoriB = new System.Windows.Forms.Button();
            this.calcAoriB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readA
            // 
            this.readA.Location = new System.Drawing.Point(34, 23);
            this.readA.Name = "readA";
            this.readA.Size = new System.Drawing.Size(97, 40);
            this.readA.TabIndex = 0;
            this.readA.Text = "Read A";
            this.readA.UseVisualStyleBackColor = true;
            this.readA.Click += new System.EventHandler(this.readA_Click);
            // 
            // readB
            // 
            this.readB.Location = new System.Drawing.Point(34, 89);
            this.readB.Name = "readB";
            this.readB.Size = new System.Drawing.Size(96, 42);
            this.readB.TabIndex = 1;
            this.readB.Text = "Read B";
            this.readB.UseVisualStyleBackColor = true;
            this.readB.Click += new System.EventHandler(this.readB_Click);
            // 
            // readAplusB
            // 
            this.readAplusB.Location = new System.Drawing.Point(34, 154);
            this.readAplusB.Name = "readAplusB";
            this.readAplusB.Size = new System.Drawing.Size(96, 44);
            this.readAplusB.TabIndex = 2;
            this.readAplusB.Text = "Read A+B";
            this.readAplusB.UseVisualStyleBackColor = true;
            this.readAplusB.Click += new System.EventHandler(this.readAplusB_Click);
            // 
            // readAoriB
            // 
            this.readAoriB.Location = new System.Drawing.Point(34, 225);
            this.readAoriB.Name = "readAoriB";
            this.readAoriB.Size = new System.Drawing.Size(96, 38);
            this.readAoriB.TabIndex = 3;
            this.readAoriB.Text = "Read A*B";
            this.readAoriB.UseVisualStyleBackColor = true;
            this.readAoriB.Click += new System.EventHandler(this.readAoriB_Click);
            // 
            // validA
            // 
            this.validA.AutoSize = true;
            this.validA.Location = new System.Drawing.Point(137, 35);
            this.validA.Name = "validA";
            this.validA.Size = new System.Drawing.Size(58, 17);
            this.validA.TabIndex = 4;
            this.validA.Text = "A valid: ";
            // 
            // validB
            // 
            this.validB.AutoSize = true;
            this.validB.Location = new System.Drawing.Point(137, 102);
            this.validB.Name = "validB";
            this.validB.Size = new System.Drawing.Size(58, 17);
            this.validB.TabIndex = 5;
            this.validB.Text = "B valid: ";
            // 
            // validAplusB
            // 
            this.validAplusB.AutoSize = true;
            this.validAplusB.Location = new System.Drawing.Point(137, 168);
            this.validAplusB.Name = "validAplusB";
            this.validAplusB.Size = new System.Drawing.Size(75, 17);
            this.validAplusB.TabIndex = 6;
            this.validAplusB.Text = "A+B valid: ";
            // 
            // validAoriB
            // 
            this.validAoriB.AutoSize = true;
            this.validAoriB.Location = new System.Drawing.Point(137, 236);
            this.validAoriB.Name = "validAoriB";
            this.validAoriB.Size = new System.Drawing.Size(72, 17);
            this.validAoriB.TabIndex = 7;
            this.validAoriB.Text = "A*B valid: ";
            // 
            // calculAplusB
            // 
            this.calculAplusB.Location = new System.Drawing.Point(34, 287);
            this.calculAplusB.Name = "calculAplusB";
            this.calculAplusB.Size = new System.Drawing.Size(96, 45);
            this.calculAplusB.TabIndex = 8;
            this.calculAplusB.Text = "Calculeaza\r\nA+B";
            this.calculAplusB.UseVisualStyleBackColor = true;
            this.calculAplusB.Click += new System.EventHandler(this.calculAplusB_Click);
            // 
            // calcAplusB
            // 
            this.calcAplusB.AutoSize = true;
            this.calcAplusB.Location = new System.Drawing.Point(137, 301);
            this.calcAplusB.Name = "calcAplusB";
            this.calcAplusB.Size = new System.Drawing.Size(85, 17);
            this.calcAplusB.TabIndex = 9;
            this.calcAplusB.Text = "Corespund: ";
            // 
            // calculAoriB
            // 
            this.calculAoriB.Location = new System.Drawing.Point(34, 358);
            this.calculAoriB.Name = "calculAoriB";
            this.calculAoriB.Size = new System.Drawing.Size(95, 43);
            this.calculAoriB.TabIndex = 10;
            this.calculAoriB.Text = "Calculeaza\r\nA*B";
            this.calculAoriB.UseVisualStyleBackColor = true;
            this.calculAoriB.Click += new System.EventHandler(this.calculAoriB_Click);
            // 
            // calcAoriB
            // 
            this.calcAoriB.AutoSize = true;
            this.calcAoriB.Location = new System.Drawing.Point(137, 371);
            this.calcAoriB.Name = "calcAoriB";
            this.calcAoriB.Size = new System.Drawing.Size(85, 17);
            this.calcAoriB.TabIndex = 11;
            this.calcAoriB.Text = "Corespund: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calcAoriB);
            this.Controls.Add(this.calculAoriB);
            this.Controls.Add(this.calcAplusB);
            this.Controls.Add(this.calculAplusB);
            this.Controls.Add(this.validAoriB);
            this.Controls.Add(this.validAplusB);
            this.Controls.Add(this.validB);
            this.Controls.Add(this.validA);
            this.Controls.Add(this.readAoriB);
            this.Controls.Add(this.readAplusB);
            this.Controls.Add(this.readB);
            this.Controls.Add(this.readA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readA;
        private System.Windows.Forms.Button readB;
        private System.Windows.Forms.Button readAplusB;
        private System.Windows.Forms.Button readAoriB;
        private System.Windows.Forms.Label validA;
        private System.Windows.Forms.Label validB;
        private System.Windows.Forms.Label validAplusB;
        private System.Windows.Forms.Label validAoriB;
        private System.Windows.Forms.Button calculAplusB;
        private System.Windows.Forms.Label calcAplusB;
        private System.Windows.Forms.Button calculAoriB;
        private System.Windows.Forms.Label calcAoriB;
    }
}

