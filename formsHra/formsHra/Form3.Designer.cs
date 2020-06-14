namespace formsHra
{
    partial class Form3
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
            this.Statistka = new System.Windows.Forms.ListBox();
            this.closeB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Statistka
            // 
            this.Statistka.FormattingEnabled = true;
            this.Statistka.Location = new System.Drawing.Point(12, 51);
            this.Statistka.Name = "Statistka";
            this.Statistka.Size = new System.Drawing.Size(360, 303);
            this.Statistka.TabIndex = 0;
            // 
            // closeB
            // 
            this.closeB.Location = new System.Drawing.Point(279, 12);
            this.closeB.Name = "closeB";
            this.closeB.Size = new System.Drawing.Size(75, 23);
            this.closeB.TabIndex = 1;
            this.closeB.Text = "Zavřít";
            this.closeB.UseVisualStyleBackColor = true;
            this.closeB.Click += new System.EventHandler(this.closeB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Př.: jménoHráče výhry/prohry/remízy";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeB);
            this.Controls.Add(this.Statistka);
            this.Name = "Form3";
            this.Text = "Statistiky";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Statistka;
        private System.Windows.Forms.Button closeB;
        private System.Windows.Forms.Label label1;
    }
}