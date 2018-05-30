namespace L1
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
            this.prad1 = new System.Windows.Forms.RichTextBox();
            this.Uzdaryti = new System.Windows.Forms.Button();
            this.Pasalinti = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Skaiciuoti = new System.Windows.Forms.Button();
            this.Ivesti = new System.Windows.Forms.Button();
            this.prad2 = new System.Windows.Forms.RichTextBox();
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // prad1
            // 
            this.prad1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.prad1.Location = new System.Drawing.Point(14, 12);
            this.prad1.Name = "prad1";
            this.prad1.Size = new System.Drawing.Size(233, 242);
            this.prad1.TabIndex = 0;
            this.prad1.Text = "";
            // 
            // Uzdaryti
            // 
            this.Uzdaryti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Uzdaryti.Location = new System.Drawing.Point(783, 475);
            this.Uzdaryti.Name = "Uzdaryti";
            this.Uzdaryti.Size = new System.Drawing.Size(102, 46);
            this.Uzdaryti.TabIndex = 1;
            this.Uzdaryti.Text = "Uždaryti";
            this.Uzdaryti.UseVisualStyleBackColor = true;
            this.Uzdaryti.Click += new System.EventHandler(this.Uzdaryti_Click);
            // 
            // Pasalinti
            // 
            this.Pasalinti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Pasalinti.Location = new System.Drawing.Point(783, 114);
            this.Pasalinti.Name = "Pasalinti";
            this.Pasalinti.Size = new System.Drawing.Size(102, 46);
            this.Pasalinti.TabIndex = 3;
            this.Pasalinti.Text = "Pašalinti";
            this.Pasalinti.UseVisualStyleBackColor = true;
            this.Pasalinti.Click += new System.EventHandler(this.Pasalinti_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(799, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 29);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(791, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kokią šalinti";
            // 
            // Skaiciuoti
            // 
            this.Skaiciuoti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Skaiciuoti.Location = new System.Drawing.Point(783, 307);
            this.Skaiciuoti.Name = "Skaiciuoti";
            this.Skaiciuoti.Size = new System.Drawing.Size(102, 46);
            this.Skaiciuoti.TabIndex = 6;
            this.Skaiciuoti.Text = "Skaičiuoti";
            this.Skaiciuoti.UseVisualStyleBackColor = true;
            this.Skaiciuoti.Click += new System.EventHandler(this.Skaiciuoti_Click);
            // 
            // Ivesti
            // 
            this.Ivesti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Ivesti.Location = new System.Drawing.Point(783, 208);
            this.Ivesti.Name = "Ivesti";
            this.Ivesti.Size = new System.Drawing.Size(102, 46);
            this.Ivesti.TabIndex = 7;
            this.Ivesti.Text = "Įvesti";
            this.Ivesti.UseVisualStyleBackColor = true;
            this.Ivesti.Click += new System.EventHandler(this.Ivesti_Click);
            // 
            // prad2
            // 
            this.prad2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.prad2.Location = new System.Drawing.Point(14, 285);
            this.prad2.Name = "prad2";
            this.prad2.Size = new System.Drawing.Size(233, 236);
            this.prad2.TabIndex = 8;
            this.prad2.Text = "";
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(253, 12);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(508, 509);
            this.rezultatai.TabIndex = 9;
            this.rezultatai.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 533);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.prad2);
            this.Controls.Add(this.Ivesti);
            this.Controls.Add(this.Skaiciuoti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Pasalinti);
            this.Controls.Add(this.Uzdaryti);
            this.Controls.Add(this.prad1);
            this.Name = "Form1";
            this.Text = "Pabaisos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox prad1;
        private System.Windows.Forms.Button Uzdaryti;
        private System.Windows.Forms.Button Pasalinti;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Skaiciuoti;
        private System.Windows.Forms.Button Ivesti;
        private System.Windows.Forms.RichTextBox prad2;
        private System.Windows.Forms.RichTextBox rezultatai;
    }
}

