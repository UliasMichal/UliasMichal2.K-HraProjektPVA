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
    public partial class Form3 : Form
    {

        public string path = "C:\\Users\\Public\\Documents\\hraMU.txt";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                string[] poleZeSouboru = File.ReadAllLines(path);
                foreach(string s in poleZeSouboru) 
                {
                    //s = "jméno výhry/prohry/remízy"
                    if(s == "Safefile") { break; }
                    if(s != "Stats" && s != "Safefile" && s != "" && s != " ") 
                    {
                        Statistka.Items.Add(s);
                    }
                    SeradListStatu(Statistka);
                }
                if(Statistka.Items.Count == 0) 
                {
                    MessageBox.Show("Nebyl nalezen žádný záznam v souboru -> vrácení do hry");
                    this.Close();
                }
            }
            else 
            {
                MessageBox.Show("Toto je vaše první hra, protože nebyl nalezen soubor - statistika chybí -> vrácení do hry");
                this.Close();
            }
        }

        private void SeradListStatu(ListBox staty) 
        {
            int[] hodnotaStatu = new int[staty.Items.Count];
            int i = 0;
            foreach(var v in staty.Items) 
            {
                string s = (string)v;
                int doPole = int.Parse(s.Split(' ')[1].Split('/')[0])*2 + int.Parse(s.Split(' ')[1].Split('/')[1])*0 + int.Parse(s.Split(' ')[1].Split('/')[2])*1;
                hodnotaStatu[i++] = doPole;
            }
            for(int y = 0; y<(hodnotaStatu.Length-1); y++) 
            {
                if(hodnotaStatu[y] < hodnotaStatu[y + 1]) 
                {
                    var temp1 = hodnotaStatu[y];
                    var temp2 = staty.Items[y];
                    hodnotaStatu[y] = hodnotaStatu[y + 1];
                    staty.Items[y] = staty.Items[y + 1];
                    hodnotaStatu[y+1] = temp1;
                    staty.Items[y+1] = temp2;

                }
            }

        }

        private void closeB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
