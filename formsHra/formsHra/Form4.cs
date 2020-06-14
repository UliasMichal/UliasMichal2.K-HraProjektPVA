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
    public partial class Form4 : Form
    {
        public string path = "C:\\Users\\Public\\Documents\\hraMU.txt";

        List<string> jednotkyStringu;
        List<string> neutralniObjektyString;
        int[] zlato;
        string karty;

        public Form4(List<string> jednotkyStringuIn, List<string> neutralniObjektyStringIn, int[] zlatoIn, int[] kartyIn)
        {
            InitializeComponent();
            jednotkyStringu = jednotkyStringuIn;
            neutralniObjektyString = neutralniObjektyStringIn;
            zlato = zlatoIn;
            karty = kartyIn[0] + " " + kartyIn[1] + " " + kartyIn[2] + " " + kartyIn[3];
        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void safeClose_Click(object sender, EventArgs e)
        {
            string[] vsechnyKarty =
            {
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)",
                    "Pohyb: pohyb až o 2 pole",
                    "Kněžský spěch: pohyb až o 4 pole",
                    "Blesk: udeří do sousední jednotky za 1 DMG a vyléčí sebe o 1 HP",
                    "Sežehnout hříšníka: udeří do jednotky za 1 DMG (range 2)",
                    "Vyléčit: vyléčí jednotku o 1 HP (range 3)",
                    "Válečný spěch: pohyb až o 3 pole",
                    "Požehnaný výpad: udeří do jednotky za 1 DMG a posune sebe na sousední pole (range 2)",
                    "Praštit po palici: udeří do sousední jednotky za 2 DMG (range 1)",
                    "Bojové léčení: vyléčí sebe o 2 HP",
                    "Magická past: vyvolá past na zvoleném poli",
                    "Vodič magie: udeří do jednotky za 3 DMG, ale mág utrpí smrtelné poškození (range 1)",
                    "Magický útok: jednotka utrpí 2 DMG (range 2)",
                    "Teleportace: posune libovolnou jednotku o 1 pole",
                    "Pomalý přesun: pohyb až o 1 pole",
                    "Výstřel: udeří do jednotky za 1 DMG s neomezeným dosahem",
                    "Kanonáda: udeří do jednotky za 2 DMG (range 3)",
                    "Masivní úder: udeří do jednotky za 3 DMG (range 2)",
                    "Spěch ve stínech: pohyb až o 4 pole",
                    "Temný úder: udeří do sousední jednotky za 3 DMG (range 1)",
                    "Hamežný úder: udeří do jednotky za 1 DMG. Pokud má nepřítel zlato převede seber 1 jednotku zlata (range 1)",
                    "Hbitý úder: posune zloděje až o 1 pole a udeří VŠECHNY sousední jednotky",
                    "Lukostřelčí spěch: pohyb až o 4 pole",
                    "Výstřel: udeří do jednotky za 1 DMG (range 3)",
                    "Přesný výstřel: udeří do jednotky za 2 DMG (range 3)",
                    "Nastražit past: nastraží na sousedním poli past"
            };
            if (File.Exists(path))
            {
                string[] zeSouboru = File.ReadAllLines(path);
                bool obsahujeJizSafeFile = false;
                int indexStartuSafeFile = 0;
                foreach(string s in zeSouboru) 
                {
                    indexStartuSafeFile++;
                    if(s == "jednotky") 
                    {
                        obsahujeJizSafeFile = true;
                        break;
                    }
                }
                if (obsahujeJizSafeFile)
                {
                    DialogResult vysledek = MessageBox.Show("Ok = přepíše soubor, Cancel = zruší akci", "Safefile obsahuje uloženou hru - chcete jí smazat?", MessageBoxButtons.OKCancel);
                    if (vysledek == DialogResult.OK)
                    {
                        List<string> doSouboruList = new List<string>();
                        foreach (string s in zeSouboru)
                        {
                            doSouboruList.Add(s);
                            if (s == "Safefile") { break; }

                        }
                        doSouboruList.Add("jednotky");
                        foreach (string s in jednotkyStringu)
                        {
                            doSouboruList.Add(s);
                        }
                        doSouboruList.Add("objekty");
                        foreach (string s in neutralniObjektyString)
                        {
                            doSouboruList.Add(s);
                        }

                        doSouboruList.Add(karty);
                        doSouboruList.Add(zlato[0].ToString());
                        doSouboruList.Add(zlato[1].ToString());

                        string[] doSouboru = new string[doSouboruList.Count];
                        int i = 0;
                        foreach (string s in doSouboruList)
                        {
                            doSouboru[i++] = s;
                        }
                        File.WriteAllLines(path, doSouboru);

                        Application.Exit();
                    }
                    else
                    {
                        //neudělá nic
                    }
                }
                else
                {
                    List<string> doSouboruList = new List<string>();
                    foreach (string s in zeSouboru)
                    {
                        doSouboruList.Add(s);
                        if (s == "Safefile") { break; }

                    }
                    doSouboruList.Add("jednotky");
                    foreach (string s in jednotkyStringu)
                    {
                        doSouboruList.Add(s);
                    }
                    doSouboruList.Add("objekty");
                    foreach (string s in neutralniObjektyString)
                    {
                        doSouboruList.Add(s);
                    }

                    doSouboruList.Add(karty);
                    doSouboruList.Add(zlato[0].ToString());
                    doSouboruList.Add(zlato[1].ToString());

                    string[] doSouboru = new string[doSouboruList.Count];
                    int i = 0;
                    foreach (string s in doSouboruList)
                    {
                        doSouboru[i++] = s;
                    }
                    File.WriteAllLines(path, doSouboru);
                    Application.Exit();

                }


            }
            else
            {
                MessageBox.Show("Herní soubor nebyl nalezen - byl vytvořen nový: " + path);
                List<string> doSouboruList = new List<string>();
                doSouboruList.Add("Stats");
                doSouboruList.Add("");
                doSouboruList.Add("Safefile");
                doSouboruList.Add("jednotky");
                foreach (string s in jednotkyStringu) 
                {
                    doSouboruList.Add(s);
                }
                doSouboruList.Add("objekty");
                foreach (string s in neutralniObjektyString)
                {
                    doSouboruList.Add(s);
                }
                
                doSouboruList.Add(karty);
                doSouboruList.Add(zlato[0].ToString());
                doSouboruList.Add(zlato[1].ToString());

                string[] doSouboru = new string[doSouboruList.Count];
                int i = 0;
                foreach(string s in doSouboruList) 
                {
                    doSouboru[i++] = s;
                }
                File.WriteAllLines(path, doSouboru);
                Application.Exit();

            }

        }

        private void closeOnly_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
