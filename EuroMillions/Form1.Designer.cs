
namespace EuroMillions
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.btnCheckNumbers = new System.Windows.Forms.Button();
            this.lblNumbers = new System.Windows.Forms.Label();
            this.lblHotPicks = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelEuroMillions = new System.Windows.Forms.Label();
            this.btnClearNumbers = new System.Windows.Forms.Button();
            this.btnGenDraws = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 99);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsNumbers);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 99);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsNumbers);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 99);
            this.textBox3.MaxLength = 2;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 23);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsNumbers);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(177, 99);
            this.textBox4.MaxLength = 2;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 23);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsNumbers);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(223, 99);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 23);
            this.textBox5.TabIndex = 4;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsNumbers);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(282, 99);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(40, 23);
            this.textBox7.TabIndex = 6;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsHotPicks);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(328, 99);
            this.textBox8.MaxLength = 2;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(40, 23);
            this.textBox8.TabIndex = 7;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox8.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxValidatingEuroMillionsHotPicks);
            // 
            // btnCheckNumbers
            // 
            this.btnCheckNumbers.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCheckNumbers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCheckNumbers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCheckNumbers.Location = new System.Drawing.Point(397, 70);
            this.btnCheckNumbers.Name = "btnCheckNumbers";
            this.btnCheckNumbers.Size = new System.Drawing.Size(124, 52);
            this.btnCheckNumbers.TabIndex = 8;
            this.btnCheckNumbers.Text = "Check EuroMillions Numbers";
            this.btnCheckNumbers.UseVisualStyleBackColor = true;
            this.btnCheckNumbers.Click += new System.EventHandler(this.btnCheckEuroMillionsNumbers_Click);
            // 
            // lblNumbers
            // 
            this.lblNumbers.AutoSize = true;
            this.lblNumbers.Location = new System.Drawing.Point(93, 70);
            this.lblNumbers.Name = "lblNumbers";
            this.lblNumbers.Size = new System.Drawing.Size(110, 15);
            this.lblNumbers.TabIndex = 9;
            this.lblNumbers.Text = "Pick Numbers 1 -50";
            // 
            // lblHotPicks
            // 
            this.lblHotPicks.AutoSize = true;
            this.lblHotPicks.Location = new System.Drawing.Point(282, 70);
            this.lblHotPicks.Name = "lblHotPicks";
            this.lblHotPicks.Size = new System.Drawing.Size(83, 15);
            this.lblHotPicks.TabIndex = 10;
            this.lblHotPicks.Text = "HotPicks 1 -12";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEuroMillions
            // 
            this.labelEuroMillions.AutoSize = true;
            this.labelEuroMillions.Location = new System.Drawing.Point(165, 35);
            this.labelEuroMillions.Name = "labelEuroMillions";
            this.labelEuroMillions.Size = new System.Drawing.Size(73, 15);
            this.labelEuroMillions.TabIndex = 11;
            this.labelEuroMillions.Text = "EuroMillions";
            // 
            // btnClearNumbers
            // 
            this.btnClearNumbers.Location = new System.Drawing.Point(165, 128);
            this.btnClearNumbers.Name = "btnClearNumbers";
            this.btnClearNumbers.Size = new System.Drawing.Size(122, 23);
            this.btnClearNumbers.TabIndex = 12;
            this.btnClearNumbers.Text = "Clear Numbers";
            this.btnClearNumbers.UseVisualStyleBackColor = true;
            this.btnClearNumbers.Click += new System.EventHandler(this.btnClearNumbers_Click);
            // 
            // btnGenDraws
            // 
            this.btnGenDraws.Location = new System.Drawing.Point(397, 226);
            this.btnGenDraws.Name = "btnGenDraws";
            this.btnGenDraws.Size = new System.Drawing.Size(124, 55);
            this.btnGenDraws.TabIndex = 13;
            this.btnGenDraws.Text = "Generate Draws";
            this.btnGenDraws.UseMnemonic = false;
            this.btnGenDraws.UseVisualStyleBackColor = true;
            this.btnGenDraws.Click += new System.EventHandler(this.btnGenerateDraws_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(114, 226);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(173, 23);
            this.textBox6.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Number of Years";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.btnGenDraws);
            this.Controls.Add(this.btnClearNumbers);
            this.Controls.Add(this.labelEuroMillions);
            this.Controls.Add(this.lblHotPicks);
            this.Controls.Add(this.lblNumbers);
            this.Controls.Add(this.btnCheckNumbers);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button btnCheckNumbers;
        private System.Windows.Forms.Label lblNumbers;
        private System.Windows.Forms.Label lblHotPicks;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEuroMillions;
        private System.Windows.Forms.Button btnClearNumbers;
        private System.Windows.Forms.Button btnGenDraws;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
    }
}

