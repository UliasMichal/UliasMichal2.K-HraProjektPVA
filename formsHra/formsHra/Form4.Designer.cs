namespace formsHra
{
    partial class Form4
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
            this.safeClose = new System.Windows.Forms.Button();
            this.closeOnly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // safeClose
            // 
            this.safeClose.Location = new System.Drawing.Point(48, 59);
            this.safeClose.Name = "safeClose";
            this.safeClose.Size = new System.Drawing.Size(125, 23);
            this.safeClose.TabIndex = 0;
            this.safeClose.Text = "Uložit a zavřít";
            this.safeClose.UseVisualStyleBackColor = true;
            this.safeClose.Click += new System.EventHandler(this.safeClose_Click);
            // 
            // closeOnly
            // 
            this.closeOnly.Location = new System.Drawing.Point(48, 88);
            this.closeOnly.Name = "closeOnly";
            this.closeOnly.Size = new System.Drawing.Size(125, 23);
            this.closeOnly.TabIndex = 0;
            this.closeOnly.Text = "Zavřít hru bez uložení";
            this.closeOnly.UseVisualStyleBackColor = true;
            this.closeOnly.Click += new System.EventHandler(this.closeOnly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(65, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // closeWindow
            // 
            this.closeWindow.Location = new System.Drawing.Point(48, 147);
            this.closeWindow.Name = "closeWindow";
            this.closeWindow.Size = new System.Drawing.Size(125, 23);
            this.closeWindow.TabIndex = 2;
            this.closeWindow.Text = "Zavřít okno";
            this.closeWindow.UseVisualStyleBackColor = true;
            this.closeWindow.Click += new System.EventHandler(this.closeWindow_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 181);
            this.Controls.Add(this.closeWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeOnly);
            this.Controls.Add(this.safeClose);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button safeClose;
        private System.Windows.Forms.Button closeOnly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeWindow;
    }
}