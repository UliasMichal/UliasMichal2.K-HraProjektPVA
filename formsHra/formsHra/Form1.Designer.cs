namespace formsHra
{
    partial class FormHra
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.karta1P = new System.Windows.Forms.Panel();
            this.karta1L = new System.Windows.Forms.Label();
            this.karta2P = new System.Windows.Forms.Panel();
            this.karta2L = new System.Windows.Forms.Label();
            this.karta3P = new System.Windows.Forms.Panel();
            this.karta3L = new System.Windows.Forms.Label();
            this.karta4P = new System.Windows.Forms.Panel();
            this.karta4L = new System.Windows.Forms.Label();
            this.poradiJednotekLB = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.Button();
            this.staty = new System.Windows.Forms.Button();
            this.Akce = new System.Windows.Forms.Label();
            this.akceDva = new System.Windows.Forms.Label();
            this.target = new System.Windows.Forms.Label();
            this.zlatoPlayer1 = new System.Windows.Forms.Label();
            this.zlatoPlayer2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hraciPole = new System.Windows.Forms.TableLayoutPanel();
            this.preskocitButton = new System.Windows.Forms.Button();
            this.nadpis = new System.Windows.Forms.Label();
            this.karta1P.SuspendLayout();
            this.karta2P.SuspendLayout();
            this.karta3P.SuspendLayout();
            this.karta4P.SuspendLayout();
            this.SuspendLayout();
            // 
            // karta1P
            // 
            this.karta1P.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.karta1P.Controls.Add(this.karta1L);
            this.karta1P.Location = new System.Drawing.Point(433, 330);
            this.karta1P.Name = "karta1P";
            this.karta1P.Size = new System.Drawing.Size(82, 133);
            this.karta1P.TabIndex = 0;
            this.karta1P.Paint += new System.Windows.Forms.PaintEventHandler(this.karty_Paint);
            // 
            // karta1L
            // 
            this.karta1L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.karta1L.Location = new System.Drawing.Point(3, 7);
            this.karta1L.Name = "karta1L";
            this.karta1L.Size = new System.Drawing.Size(75, 125);
            this.karta1L.TabIndex = 0;
            this.karta1L.Text = "Akce:";
            this.karta1L.Click += new System.EventHandler(this.kartaL_Click);
            // 
            // karta2P
            // 
            this.karta2P.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.karta2P.Controls.Add(this.karta2L);
            this.karta2P.Location = new System.Drawing.Point(523, 330);
            this.karta2P.Name = "karta2P";
            this.karta2P.Size = new System.Drawing.Size(82, 133);
            this.karta2P.TabIndex = 0;
            this.karta2P.Paint += new System.Windows.Forms.PaintEventHandler(this.karty_Paint);
            // 
            // karta2L
            // 
            this.karta2L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.karta2L.Location = new System.Drawing.Point(3, 7);
            this.karta2L.Name = "karta2L";
            this.karta2L.Size = new System.Drawing.Size(75, 125);
            this.karta2L.TabIndex = 0;
            this.karta2L.Text = "Akce:";
            this.karta2L.Click += new System.EventHandler(this.kartaL_Click);
            // 
            // karta3P
            // 
            this.karta3P.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.karta3P.Controls.Add(this.karta3L);
            this.karta3P.Location = new System.Drawing.Point(610, 330);
            this.karta3P.Name = "karta3P";
            this.karta3P.Size = new System.Drawing.Size(82, 133);
            this.karta3P.TabIndex = 0;
            this.karta3P.Paint += new System.Windows.Forms.PaintEventHandler(this.karty_Paint);
            // 
            // karta3L
            // 
            this.karta3L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.karta3L.Location = new System.Drawing.Point(3, 7);
            this.karta3L.Name = "karta3L";
            this.karta3L.Size = new System.Drawing.Size(75, 125);
            this.karta3L.TabIndex = 0;
            this.karta3L.Text = "Akce:";
            this.karta3L.Click += new System.EventHandler(this.kartaL_Click);
            // 
            // karta4P
            // 
            this.karta4P.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.karta4P.Controls.Add(this.karta4L);
            this.karta4P.Location = new System.Drawing.Point(698, 330);
            this.karta4P.Name = "karta4P";
            this.karta4P.Size = new System.Drawing.Size(82, 133);
            this.karta4P.TabIndex = 0;
            this.karta4P.Paint += new System.Windows.Forms.PaintEventHandler(this.karty_Paint);
            // 
            // karta4L
            // 
            this.karta4L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.karta4L.Location = new System.Drawing.Point(3, 7);
            this.karta4L.Name = "karta4L";
            this.karta4L.Size = new System.Drawing.Size(75, 125);
            this.karta4L.TabIndex = 0;
            this.karta4L.Text = "Akce:";
            this.karta4L.Click += new System.EventHandler(this.kartaL_Click);
            // 
            // poradiJednotekLB
            // 
            this.poradiJednotekLB.FormattingEnabled = true;
            this.poradiJednotekLB.Location = new System.Drawing.Point(433, 65);
            this.poradiJednotekLB.Name = "poradiJednotekLB";
            this.poradiJednotekLB.Size = new System.Drawing.Size(288, 212);
            this.poradiJednotekLB.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(727, 65);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(112, 62);
            this.menu.TabIndex = 2;
            this.menu.Text = "MENU";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // staty
            // 
            this.staty.Location = new System.Drawing.Point(727, 159);
            this.staty.Name = "staty";
            this.staty.Size = new System.Drawing.Size(112, 45);
            this.staty.TabIndex = 2;
            this.staty.Text = "STATY";
            this.staty.UseVisualStyleBackColor = true;
            this.staty.Click += new System.EventHandler(this.staty_Click);
            // 
            // Akce
            // 
            this.Akce.AutoSize = true;
            this.Akce.Location = new System.Drawing.Point(560, 297);
            this.Akce.Name = "Akce";
            this.Akce.Size = new System.Drawing.Size(77, 13);
            this.Akce.TabIndex = 3;
            this.Akce.Text = "Možnosti akcí:";
            // 
            // akceDva
            // 
            this.akceDva.AutoSize = true;
            this.akceDva.Location = new System.Drawing.Point(64, 450);
            this.akceDva.Name = "akceDva";
            this.akceDva.Size = new System.Drawing.Size(67, 13);
            this.akceDva.TabIndex = 4;
            this.akceDva.Text = "Zlato hráč 1:";
            // 
            // target
            // 
            this.target.AutoSize = true;
            this.target.Location = new System.Drawing.Point(64, 475);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(67, 13);
            this.target.TabIndex = 4;
            this.target.Text = "Zlato hráč 2:";
            // 
            // zlatoPlayer1
            // 
            this.zlatoPlayer1.AutoSize = true;
            this.zlatoPlayer1.Location = new System.Drawing.Point(137, 450);
            this.zlatoPlayer1.Name = "zlatoPlayer1";
            this.zlatoPlayer1.Size = new System.Drawing.Size(13, 13);
            this.zlatoPlayer1.TabIndex = 4;
            this.zlatoPlayer1.Text = "1";
            // 
            // zlatoPlayer2
            // 
            this.zlatoPlayer2.AutoSize = true;
            this.zlatoPlayer2.Location = new System.Drawing.Point(137, 475);
            this.zlatoPlayer2.Name = "zlatoPlayer2";
            this.zlatoPlayer2.Size = new System.Drawing.Size(13, 13);
            this.zlatoPlayer2.TabIndex = 4;
            this.zlatoPlayer2.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Pořadí jednotek:";
            // 
            // hraciPole
            // 
            this.hraciPole.BackColor = System.Drawing.SystemColors.Window;
            this.hraciPole.ColumnCount = 8;
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.Location = new System.Drawing.Point(12, 27);
            this.hraciPole.Name = "hraciPole";
            this.hraciPole.RowCount = 8;
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.hraciPole.Size = new System.Drawing.Size(400, 400);
            this.hraciPole.TabIndex = 5;
            this.hraciPole.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.HraciPole_CellPaint);
            this.hraciPole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HraciPole_MouseClick);
            // 
            // preskocitButton
            // 
            this.preskocitButton.BackColor = System.Drawing.SystemColors.Info;
            this.preskocitButton.Location = new System.Drawing.Point(433, 490);
            this.preskocitButton.Name = "preskocitButton";
            this.preskocitButton.Size = new System.Drawing.Size(347, 23);
            this.preskocitButton.TabIndex = 6;
            this.preskocitButton.Text = "Přeskočit";
            this.preskocitButton.UseVisualStyleBackColor = false;
            this.preskocitButton.Click += new System.EventHandler(this.preskocitButton_Click);
            // 
            // nadpis
            // 
            this.nadpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nadpis.Location = new System.Drawing.Point(616, 13);
            this.nadpis.Name = "nadpis";
            this.nadpis.Size = new System.Drawing.Size(72, 23);
            this.nadpis.TabIndex = 7;
            this.nadpis.Text = "Hra";
            // 
            // FormHra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 525);
            this.Controls.Add(this.nadpis);
            this.Controls.Add(this.preskocitButton);
            this.Controls.Add(this.hraciPole);
            this.Controls.Add(this.target);
            this.Controls.Add(this.zlatoPlayer2);
            this.Controls.Add(this.zlatoPlayer1);
            this.Controls.Add(this.akceDva);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Akce);
            this.Controls.Add(this.staty);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.poradiJednotekLB);
            this.Controls.Add(this.karta4P);
            this.Controls.Add(this.karta3P);
            this.Controls.Add(this.karta2P);
            this.Controls.Add(this.karta1P);
            this.Name = "FormHra";
            this.Text = "Hra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHra_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.karta1P.ResumeLayout(false);
            this.karta2P.ResumeLayout(false);
            this.karta3P.ResumeLayout(false);
            this.karta4P.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel karta1P;
        private System.Windows.Forms.Panel karta2P;
        private System.Windows.Forms.Panel karta3P;
        private System.Windows.Forms.Panel karta4P;
        private System.Windows.Forms.ListBox poradiJednotekLB;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Button staty;
        private System.Windows.Forms.Label Akce;
        private System.Windows.Forms.Label akceDva;
        private System.Windows.Forms.Label target;
        private System.Windows.Forms.Label zlatoPlayer1;
        private System.Windows.Forms.Label zlatoPlayer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel hraciPole;
        private System.Windows.Forms.Label karta1L;
        private System.Windows.Forms.Label karta3L;
        private System.Windows.Forms.Label karta4L;
        private System.Windows.Forms.Button preskocitButton;
        private System.Windows.Forms.Label karta2L;
        private System.Windows.Forms.Label nadpis;
    }
}

