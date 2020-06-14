using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formsHra
{
    public partial class Form5 : Form
    {
        public int vyhercePartie;
        public string path = "C:\\Users\\Public\\Documents\\hraMU.txt";
        public Form5(int vitez)
        {
            InitializeComponent();
            vyhercePartie = vitez;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            if (ValidniVstup())
            {
                if (File.Exists(path))
                {
                    string[] zeSouboru = File.ReadAllLines(path);
                    bool nalezenHrac1 = false;
                    bool nalezenHrac2 = false;
                    for(int i = 0; i< zeSouboru.Length; i++) 
                    {
                        string[] radek = zeSouboru[i].Split(' ');
                        if (radek[0] == namePlayer1.Text) 
                        {
                            nalezenHrac1 = true;
                            int[] score = { int.Parse(radek[1].Split('/')[0]), int.Parse(radek[1].Split('/')[1]), int.Parse(radek[1].Split('/')[2]) };
                            if (vyhercePartie == -1)
                            {
                                score[2] += 1;
                            }
                            if (vyhercePartie == 0)
                            {
                                score[0] += 1;
                            }
                            if (vyhercePartie == 1)
                            {
                                score[1] += 1;
                            }
                            string scoreString = score[0] + "/" + score[1] + "/" + score[2];
                            zeSouboru[i] = namePlayer1.Text + " " + scoreString;
                        }

                        if (radek[0] == namePlayer2.Text)
                        {
                            nalezenHrac2 = true;
                            int[] score = { int.Parse(radek[1].Split('/')[0]), int.Parse(radek[1].Split('/')[1]), int.Parse(radek[1].Split('/')[2]) };
                            if (vyhercePartie == -1)
                            {
                                score[2] += 1;
                            }
                            if (vyhercePartie == 0)
                            {
                                score[1] += 1;
                            }
                            if (vyhercePartie == 1)
                            {
                                score[0] += 1;
                            }
                            string scoreString = score[0] + "/" + score[1] + "/" + score[2];
                            zeSouboru[i] = namePlayer2.Text + " " + scoreString;

                        }
                    }
                    if(nalezenHrac1==true && nalezenHrac2 == true) 
                    {
                        File.WriteAllLines(path, zeSouboru);
                    }

                    if (nalezenHrac1 == false && nalezenHrac2 == false) 
                    {
                        string[] doSouboru = new string[zeSouboru.Length + 2];
                        int i = 0;
                        for (i = 0; i<zeSouboru.Length; i++) 
                        {
                            if (zeSouboru[i] == "") { break; }
                            else
                            {
                                doSouboru[i] = zeSouboru[i];
                            }
                        }

                        if (vyhercePartie == -1)
                        {
                            doSouboru[i] = namePlayer1.Text + " 0/0/1";
                            doSouboru[i+1] = namePlayer2.Text + " 0/0/1";
                        }
                        if (vyhercePartie == 0)
                        {
                            doSouboru[i] = namePlayer1.Text + " 1/0/0";
                            doSouboru[i+1] = namePlayer2.Text + " 0/1/0";
                        }
                        if (vyhercePartie == 1)
                        {
                            doSouboru[i] = namePlayer1.Text + " 0/1/0";
                            doSouboru[i+1] = namePlayer2.Text + " 1/0/0";
                        }
                        for(int y = i; y<zeSouboru.Length;y++) 
                        {
                            doSouboru[i + 2] = zeSouboru[y];
                            i++;
                        }
                        File.WriteAllLines(path, doSouboru);

                    }
                    else 
                    {
                        if(nalezenHrac1==false && nalezenHrac2 == true) 
                        {
                            string[] doSouboru = new string[zeSouboru.Length + 1];
                            int i = 0;
                            for (i = 0; i < zeSouboru.Length; i++)
                            {
                                if (zeSouboru[i] == "") { break; }
                                else
                                {
                                    doSouboru[i] = zeSouboru[i];
                                }
                            }

                            if (vyhercePartie == -1)
                            {
                                doSouboru[i] = namePlayer1.Text + " 0/0/1";
                            }
                            if (vyhercePartie == 0)
                            {
                                doSouboru[i] = namePlayer1.Text + " 1/0/0";
                            }
                            if (vyhercePartie == 1)
                            {
                                doSouboru[i] = namePlayer1.Text + " 0/1/0";
                            }
                            for (int y = i; y < zeSouboru.Length; y++)
                            {
                                doSouboru[i + 1] = zeSouboru[y];
                                i++;
                            }
                            File.WriteAllLines(path, doSouboru);

                        }
                        if (nalezenHrac1 == true && nalezenHrac2 == false)
                        {
                            string[] doSouboru = new string[zeSouboru.Length + 1];
                            int i = 0;
                            for (i = 0; i < zeSouboru.Length; i++)
                            {
                                if (zeSouboru[i] == "") { break; }
                                else
                                {
                                    doSouboru[i] = zeSouboru[i];
                                }
                            }

                            if (vyhercePartie == -1)
                            {
                                doSouboru[i] = namePlayer2.Text + " 0/0/1";
                            }
                            if (vyhercePartie == 0)
                            {
                                doSouboru[i] = namePlayer2.Text + " 0/1/0";
                            }
                            if (vyhercePartie == 1)
                            {
                                doSouboru[i] = namePlayer2.Text + " 1/0/0";
                            }
                            for (int y = i; y < zeSouboru.Length; y++)
                            {
                                doSouboru[i + 1] = zeSouboru[y];
                                i++;
                            }
                            File.WriteAllLines(path, doSouboru);

                        }
                    }
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Herní soubor nebyl nalezen - byl vytvořen nový: " + path);
                    string[] doSouboru = new string[5];
                    doSouboru[0] = "Stats";
                    doSouboru[4] = "Safefile";
                    if (vyhercePartie == -1)
                    {
                        doSouboru[1] = namePlayer1.Text + " 0/0/1";
                        doSouboru[2] = namePlayer2.Text + " 0/0/1";
                    }
                    if (vyhercePartie == 0)
                    {
                        doSouboru[1] = namePlayer1.Text + " 1/0/0";
                        doSouboru[2] = namePlayer2.Text + " 0/1/0";
                    }
                    if (vyhercePartie == 1)
                    {
                        doSouboru[1] = namePlayer1.Text + " 0/1/0";
                        doSouboru[2] = namePlayer2.Text + " 1/0/0";
                    }
                    File.WriteAllLines(path, doSouboru);
                    Application.Exit();
                }
            }
            else 
            {
                MessageBox.Show("Není validní vstup - jméno nesmí být prázdné a nesmí obsahovat mezeru", "ERROR");
            }
        }
        
        private bool ValidniVstup() 
        {
            if (namePlayer1.Text.Length>0) 
            {
                if(namePlayer1.Text.Contains(' ')) 
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
            if (namePlayer2.Text.Length > 0)
            {
                if (namePlayer2.Text.Contains(' '))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
