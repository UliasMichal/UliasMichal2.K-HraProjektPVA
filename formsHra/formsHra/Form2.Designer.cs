namespace formsHra
{
    partial class FormStartGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.newGameStartB = new System.Windows.Forms.Button();
            this.loadGameB = new System.Windows.Forms.Button();
            this.closeAllB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vítejte ve hře!";
            // 
            // newGameStartB
            // 
            this.newGameStartB.Location = new System.Drawing.Point(46, 41);
            this.newGameStartB.Name = "newGameStartB";
            this.newGameStartB.Size = new System.Drawing.Size(153, 52);
            this.newGameStartB.TabIndex = 1;
            this.newGameStartB.Text = "Začít novou hru 2 hráčů (lokálně)";
            this.newGameStartB.UseVisualStyleBackColor = true;
            this.newGameStartB.Click += new System.EventHandler(this.newGameStartB_Click);
            // 
            // loadGameB
            // 
            this.loadGameB.Location = new System.Drawing.Point(46, 112);
            this.loadGameB.Name = "loadGameB";
            this.loadGameB.Size = new System.Drawing.Size(153, 23);
            this.loadGameB.TabIndex = 2;
            this.loadGameB.Text = "Načíst uloženou hru";
            this.loadGameB.UseVisualStyleBackColor = true;
            this.loadGameB.Click += new System.EventHandler(this.loadGameB_Click);
            // 
            // closeAllB
            // 
            this.closeAllB.Location = new System.Drawing.Point(75, 159);
            this.closeAllB.Name = "closeAllB";
            this.closeAllB.Size = new System.Drawing.Size(86, 33);
            this.closeAllB.TabIndex = 3;
            this.closeAllB.Text = "Zavřít vše";
            this.closeAllB.UseVisualStyleBackColor = true;
            this.closeAllB.Click += new System.EventHandler(this.closeAllB_Click);
            // 
            // FormStartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 204);
            this.Controls.Add(this.closeAllB);
            this.Controls.Add(this.loadGameB);
            this.Controls.Add(this.newGameStartB);
            this.Controls.Add(this.label1);
            this.Name = "FormStartGame";
            this.Text = "StartGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newGameStartB;
        private System.Windows.Forms.Button loadGameB;
        private System.Windows.Forms.Button closeAllB;
    }
}