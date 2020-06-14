namespace formsHra
{
    partial class Form5
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
            this.namePlayer1 = new System.Windows.Forms.TextBox();
            this.namePlayer2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.okB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namePlayer1
            // 
            this.namePlayer1.Location = new System.Drawing.Point(142, 72);
            this.namePlayer1.Name = "namePlayer1";
            this.namePlayer1.Size = new System.Drawing.Size(162, 20);
            this.namePlayer1.TabIndex = 0;
            // 
            // namePlayer2
            // 
            this.namePlayer2.Location = new System.Drawing.Point(142, 144);
            this.namePlayer2.Name = "namePlayer2";
            this.namePlayer2.Size = new System.Drawing.Size(162, 20);
            this.namePlayer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hráč 1 (červená): ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hráč 2 (modrá):";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label3.Location = new System.Drawing.Point(103, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(154, 20);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Zadejte jména hráčů";
            // 
            // okB
            // 
            this.okB.Location = new System.Drawing.Point(142, 223);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(75, 23);
            this.okB.TabIndex = 3;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 296);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namePlayer2);
            this.Controls.Add(this.namePlayer1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namePlayer1;
        private System.Windows.Forms.TextBox namePlayer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button okB;
    }
}