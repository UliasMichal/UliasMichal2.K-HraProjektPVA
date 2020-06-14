using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace formsHra
{
    public partial class FormStartGame : Form
    {

        public string path = "C:\\Users\\Public\\Documents\\hraMU.txt";
        public FormStartGame()
        {
            InitializeComponent();
        
        }


        private void closeAllB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadGameB_Click(object sender, EventArgs e)
        {

            if (File.Exists(path))
            {
                string[] poleZeSouboru = File.ReadAllLines(path);
                List<string> safeFileList = new List<string>();
                bool safeFileNalezen = false;
                foreach (string s in poleZeSouboru)
                {
                    if (safeFileNalezen)
                    {
                        if (s == "" || s == " ")
                        {
                            MessageBox.Show("Nebyl nalezen safe-file - nejspíše jste zapomněli hru uložit");
                            break;
                        }
                        else
                        {
                            safeFileList.Add(s);
                        }
                    }
                    if (s == "Safefile")
                    {
                        if (s == poleZeSouboru[poleZeSouboru.Length - 1])
                        {
                            MessageBox.Show("Nebyl nalezen safe-file - nejspíše jste zapomněli hru uložit");
                        }
                        else
                        {
                            safeFileNalezen = true;
                        }
                    }
                }
                if (safeFileNalezen)
                {
                    FormHra form = new FormHra(false);
                    form.Show();
                    FormStartGame tenhleForm = new FormStartGame();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Toto je vaše první hra, protože nebyl nalezen soubor - safefile chybí - možná si přejte spustit novou hru");
            }
        }

        private void newGameStartB_Click(object sender, EventArgs e)
        {
            FormHra form = new FormHra(true);
            form.Show();
            FormStartGame tenhleForm = new FormStartGame();
            this.Hide();
        }
    }
}
