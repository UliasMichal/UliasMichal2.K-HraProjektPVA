using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace formsHra
{    

    public partial class FormHra : Form
    {
        bool nove;
        public string path = "C:\\Users\\Public\\Documents\\hraMU.txt";

        //třída určená pro dědění - obsahuje souřadnice (číslo řádku a sloupce)
        public class ObjektyHerni
        {
            public int radek;
            public int sloupec;
            
        }

        //třída určená pro definici herní jednotky
        public class Jednotka : ObjektyHerni
        {
            public int indexDruhu;
            public int hpSoucasne;
            public int hpMax;
            public int vlastnik;

            public override string ToString()
            {
                string[] druhyJednotek = {
                    "Rytíř",
                    "Katapult",
                    "Mág",
                    "Kněz",
                    "Zloděj",
                    "Lukostřelec"
                };
                return (druhyJednotek[indexDruhu] + " " + "hráče " + vlastnik);
            }

            public Jednotka(int radekIn, int sloupecIn, int indexDruhuIn, int vlastnikIn) 
            {
                radek = radekIn;
                sloupec = sloupecIn;
                indexDruhu = indexDruhuIn;
                vlastnik = vlastnikIn;
                if (indexDruhu == 0)
                {
                    hpMax = 3;
                }
                else { 
                    if (indexDruhu == 1 || indexDruhu == 2)
                    {
                        hpMax = 1;
                    }
                    else 
                    {
                        hpMax = 2;
                    }
                }
                hpSoucasne = hpMax;
            }
            public Jednotka(int radekIn, int sloupecIn, int indexDruhuIn, int vlastnikIn, int hpSoucasneIn)
            {
                radek = radekIn;
                sloupec = sloupecIn;
                indexDruhu = indexDruhuIn;
                vlastnik = vlastnikIn;
                if (indexDruhu == 0)
                {
                    hpMax = 3;
                }
                else
                {
                    if (indexDruhu == 1 || indexDruhu == 2)
                    {
                        hpMax = 1;
                    }
                    else
                    {
                        hpMax = 2;
                    }
                }
                hpSoucasne = hpSoucasneIn;
            }

        }

        //třída určená pro definici neturálního herního objektu
        public class NeutralniObjekty : ObjektyHerni
        {
            public int indexDruhu;
            public NeutralniObjekty(int x,int y,int indexDruhuIn) 
            {
                radek = x;
                sloupec = y;
                indexDruhu = indexDruhuIn;
            }
        }
        NeutralniObjekty[] neutralniObjekty = new NeutralniObjekty[64];

        public FormHra(bool noveIn)
        {
            InitializeComponent();
            List<Label> vytvoreneLabely = new List<Label>();
            preskocitButton.Tag = vytvoreneLabely;
            nove = noveIn;
        }

        public class GeneratorKaret
        {
            public static int[] RNGProPoleInt()
            {
                Random r = new Random();
                int[] vygenerovaneIndexy = new int[4];
                r.Next(0, 6);

                for (int i = 0; i < 4; i++)
                {
                    vygenerovaneIndexy[i] = r.Next(0, 6);

                    if (i != 0)
                    {
                        while (0 == 0)
                        {
                            bool vPoradku = true;
                            for (int x = i - 1; x >= 0; x--)
                            {
                                if (vygenerovaneIndexy[x] == vygenerovaneIndexy[i])
                                {
                                    vygenerovaneIndexy[i] = r.Next(0, 6);
                                    vPoradku = false;
                                }
                            }

                            if (vPoradku)
                            {
                                break;
                            }
                        }
                    }
                }

                return vygenerovaneIndexy;

            }
            
            public static string[] GenerujKartyDleIndexuPriNacitani(int[] cislaKaretZeSouboru) 
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

                string[] karty = new string[4];
                karty[0] = vsechnyKarty[cislaKaretZeSouboru[0]];
                karty[1] = vsechnyKarty[cislaKaretZeSouboru[1]];
                karty[2] = vsechnyKarty[cislaKaretZeSouboru[2]];
                karty[3] = vsechnyKarty[cislaKaretZeSouboru[3]];
                return karty;
            }
            
            public static string[] GenerujKartyProKneze()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Kněžský spěch: pohyb až o 4 pole",
                    "Pohyb: pohyb až o 2 pole",
                    "Blesk: udeří do sousední jednotky za 1 DMG a vyléčí sebe o 1 HP",
                    "Sežehnout hříšníka: udeří do jednotky za 1 DMG (range 2)",
                    "Vyléčit: vyléčí jednotku o 1 HP (range 3)",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyKneze = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyKneze;
            }
            public static string[] GenerujKartyProRytire()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Válečný spěch: pohyb až o 3 pole",
                    "Pohyb: pohyb až o 2 pole",
                    "Požehnaný výpad: udeří do jednotky za 1 DMG a posune sebe na sousední pole (range 2)",
                    "Praštit po palici: udeří do sousední jednotky za 2 DMG (range 1)",
                    "Bojové léčení: vyléčí sebe o 2 HP",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyRytire = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyRytire;
            }
            public static string[] GenerujKartyProMaga()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Magická past: vyvolá past na zvoleném poli",
                    "Pohyb: pohyb až o 2 pole",
                    "Vodič magie: udeří do jednotky za 3 DMG, ale mág utrpí smrtelné poškození (range 1)",
                    "Magický útok: jednotka utrpí 2 DMG (range 2)",
                    "Teleportace: posune libovolnou jednotku o 1 pole",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyMaga = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyMaga;
            }
            public static string[] GenerujKartyProKatapult()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Pomalý přesun: pohyb až o 1 pole",
                    "Pohyb: pohyb až o 2 pole",
                    "Výstřel: udeří do jednotky za 1 DMG s neomezeným dosahem",
                    "Kanonáda: udeří do jednotky za 2 DMG (range 3)",
                    "Masivní úder: udeří do jednotky za 3 DMG (range 2)",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyKatapultu = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyKatapultu;
            }
            public static string[] GenerujKartyProZlodeje()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Spěch ve stínech: pohyb až o 4 pole",
                    "Pohyb: pohyb až o 2 pole",
                    "Temný úder: udeří do sousední jednotky za 3 DMG (range 1)",
                    "Hamežný úder: udeří do jednotky za 1 DMG. Pokud má nepřítel zlato převede seber 1 jednotku zlata (range 1)",
                    "Hbitý úder: posune zloděje až o 1 pole a udeří VŠECHNY sousední jednotky",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyZlodeje = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyZlodeje;
            }
            public static string[] GenerujKartyProLukostrelce()
            {

                string[] kartyNaVyberVsechny =
                {
                    "Lukostřelčí spěch: pohyb až o 4 pole",
                    "Pohyb: pohyb až o 2 pole",
                    "Výstřel: udeří do jednotky za 1 DMG (range 3)",
                    "Přesný výstřel: udeří do jednotky za 2 DMG (range 3)",
                    "Nastražit past: nastraží na sousedním poli past",
                    "Nasadit: nasadí jednotku za cenu 1 zlata (mága či zloděje - nelze vlastnit 2 jednotky stejného typu)"
                };
                int[] vygenerovaneIndexy = RNGProPoleInt();
                string[] kartyLukostrelce = { kartyNaVyberVsechny[vygenerovaneIndexy[0]], kartyNaVyberVsechny[vygenerovaneIndexy[1]], kartyNaVyberVsechny[vygenerovaneIndexy[2]], kartyNaVyberVsechny[vygenerovaneIndexy[3]] };
                return kartyLukostrelce;
            }
        }

        public Jednotka[] PridejJednotkuDoPole(Jednotka[] soucasnyStav, Jednotka nova) 
        {
            Jednotka[] novePole = new Jednotka[soucasnyStav.Length+1];
            for(int i = 0; i<soucasnyStav.Length; i++) 
            {
                novePole[i] = soucasnyStav[i];
            }
            novePole[Array.IndexOf(novePole, null)] = nova;
            return novePole;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Jednotka[] poleJednotek = new Jednotka[64];

            if (nove)
            {
                Jednotka rytirB = new Jednotka(6, 6, 0, 0);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, rytirB);

                Jednotka lukostrelecB = new Jednotka(7, 6, 5, 0);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, lukostrelecB);

                Jednotka knezB = new Jednotka(6, 7, 3, 0);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, knezB);

                Jednotka katapultB = new Jednotka(7, 7, 1, 0);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, katapultB);



                Jednotka rytirA = new Jednotka(1, 1, 0, 1);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, rytirA);

                Jednotka lukostrelecA = new Jednotka(0, 1, 5, 1);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, lukostrelecA);

                Jednotka knezA = new Jednotka(1, 0, 3, 1);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, knezA);

                Jednotka katapultA = new Jednotka(0, 0, 1, 1);
                poleJednotek = PridejJednotkuDoPole(poleJednotek, katapultA);

                neutralniObjekty[0] = new NeutralniObjekty(1, 6, 0);
                neutralniObjekty[1] = new NeutralniObjekty(6, 1, 0);
                neutralniObjekty[2] = new NeutralniObjekty(1, 5, 1);
                neutralniObjekty[3] = new NeutralniObjekty(2, 6, 1);
                neutralniObjekty[4] = new NeutralniObjekty(5, 1, 1);
                neutralniObjekty[5] = new NeutralniObjekty(6, 2, 1);

                VypisTextKaret(poleJednotek);
            }
            else 
            {
                string[] zeSouboru = File.ReadAllLines(path);
                bool jednotkyNalezeny = false;
                bool neutralniObjektyNalezeny = false;

                int y = 0;
                for(int i = 0; i<(zeSouboru.Length-3); i++)
                {
                    if (zeSouboru[i] == "jednotky" || zeSouboru[i] == "objekty")
                    {
                        if (zeSouboru[i] == "jednotky")
                        {
                            jednotkyNalezeny = true;
                        }
                        if (zeSouboru[i] == "objekty")
                        {
                            neutralniObjektyNalezeny = true;
                        }
                    }
                    else
                    {
                        if (neutralniObjektyNalezeny)
                        {
                            string[] neutralniObjektVeStringovemPoli = zeSouboru[i].Split(' ');
                            neutralniObjekty[y++] = new NeutralniObjekty(int.Parse(neutralniObjektVeStringovemPoli[0]), int.Parse(neutralniObjektVeStringovemPoli[1]), int.Parse(neutralniObjektVeStringovemPoli[2]));
                        }
                        else
                        {
                            if (jednotkyNalezeny)
                            {
                                string[] jednotkaVeStringovemPoli = zeSouboru[i].Split(' ');
                                poleJednotek = PridejJednotkuDoPole(poleJednotek, new Jednotka(int.Parse(jednotkaVeStringovemPoli[0]), int.Parse(jednotkaVeStringovemPoli[1]), int.Parse(jednotkaVeStringovemPoli[2]), int.Parse(jednotkaVeStringovemPoli[3]), int.Parse(jednotkaVeStringovemPoli[4])));
                            }
                        }
                    }
                }
                zlatoPlayer2.Text = zeSouboru[zeSouboru.Length - 1];
                zlatoPlayer1.Text = zeSouboru[zeSouboru.Length - 2];
                string indexyKaretVeStringu = zeSouboru[zeSouboru.Length - 3];
                string[] indexKaretVPoli = indexyKaretVeStringu.Split(' ');
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
                karta1L.Text = vsechnyKarty[int.Parse(indexKaretVPoli[0])];
                karta2L.Text = vsechnyKarty[int.Parse(indexKaretVPoli[1])];
                karta3L.Text = vsechnyKarty[int.Parse(indexKaretVPoli[2])];
                karta4L.Text = vsechnyKarty[int.Parse(indexKaretVPoli[3])];

            }

            hraciPole.Tag = poleJednotek;
            Akce.Tag = null;
            akceDva.Tag = null;
            target.Tag = null;



        }


        //vykreslení karet akcí
        private void karty_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pHrana = new Pen(Color.Black);
            g.DrawRectangle(pHrana, 0,0, karta1P.Width-1, karta1P.Height-1);
            
        }

        //vykreslení jednotek
        #region
        private void vykresleniJednotky(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni) 
        {
            Graphics g = e.Graphics;
            Pen barvaJednotky;
            Pen pHrana = new Pen(Color.Black);
            if (jednotkaProVykresleni != null)
            {
                if (jednotkaProVykresleni.vlastnik == 0)
                {
                    barvaJednotky = new Pen(Color.Red);
                }
                else
                {
                    barvaJednotky = new Pen(Color.Blue);
                }


                if (e.Column == jednotkaProVykresleni.sloupec && e.Row == jednotkaProVykresleni.radek)
                {
                    Rectangle bunka = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    g.DrawRectangle(pHrana, bunka);
                    Label cisloLabel = new Label();
                    cisloLabel.Location = new Point(bunka.X + 12 + 1, bunka.Y + 37 + 27 + 1);
                    cisloLabel.Size = new Size(11, 11);
                    cisloLabel.Text = jednotkaProVykresleni.vlastnik.ToString();
                    cisloLabel.ForeColor = Color.Black;
                    float fontSize = 6.5f;
                    cisloLabel.Font = new Font("Microsoft Sans Serif", fontSize);
                    cisloLabel.TextAlign = ContentAlignment.MiddleCenter;
                    cisloLabel.Tag = "created";
                    this.Controls.Add(cisloLabel);
                    ((List<Label>)preskocitButton.Tag).Add(cisloLabel);
                    g.DrawRectangle(barvaJednotky, bunka.X, bunka.Y + 37, 12, 12);

                    Label hpLabel = new Label();
                    hpLabel.Location = new Point(bunka.X + 12 + 1 + 12, bunka.Y + 37 + 27 + 1);
                    hpLabel.Size = new Size(36, 11);
                    hpLabel.Text = jednotkaProVykresleni.hpSoucasne.ToString() + "/" + jednotkaProVykresleni.hpMax.ToString();
                    hpLabel.ForeColor = Color.Black;
                    hpLabel.Font = new Font("Microsoft Sans Serif", fontSize);
                    hpLabel.TextAlign = ContentAlignment.MiddleCenter;
                    hpLabel.Tag = "created";
                    this.Controls.Add(hpLabel);
                    ((List<Label>)preskocitButton.Tag).Add(hpLabel);
                    g.DrawRectangle(barvaJednotky, bunka.X + 12, bunka.Y + 37, 37, 12);

                    cisloLabel.BringToFront();
                    hpLabel.BringToFront();

                    poradiJednotekLB.Items.Add(jednotkaProVykresleni);

                    switch (jednotkaProVykresleni.indexDruhu)
                    {
                        case 0:
                            vykresleniRytire(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;
                        case 1:
                            vykresleniKatapultu(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;
                        case 2:
                            vykresleniMaga(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;
                        case 3:
                            vykresleniKneze(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;
                        case 4:
                            vykresleniZlodeje(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;
                        case 5:
                            vykresleniLukostrelce(e, jednotkaProVykresleni, barvaJednotky, bunka);
                            break;

                    }

                }
            }
        }

        private void vykresleniRytire(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;
            
            Point[] bodyRytire = { new Point(bunkaProJednotku.X + 49/2, bunkaProJednotku.Y), 
                new Point(bunkaProJednotku.X + 49/2 + 12, bunkaProJednotku.Y + 10), 
                new Point(bunkaProJednotku.X + 49 / 2, bunkaProJednotku.Y + 35),
                new Point(bunkaProJednotku.X + 49 / 2 - 12, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49/2, bunkaProJednotku.Y)
            };
            g.DrawLines(barvaJednotky, bodyRytire);

        }

        private void vykresleniKatapultu(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(barvaJednotky, bunkaProJednotku.X+5, bunkaProJednotku.Y+28, 8,8);
            g.DrawEllipse(barvaJednotky, bunkaProJednotku.X+30, bunkaProJednotku.Y + 28, 8, 8);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X+5+4, bunkaProJednotku.Y+28, bunkaProJednotku.X+34, bunkaProJednotku.Y+28);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 5 + 4, bunkaProJednotku.Y + 28, bunkaProJednotku.X + 27, bunkaProJednotku.Y + 21+7/2);
            g.DrawArc(barvaJednotky, bunkaProJednotku.X + 27, bunkaProJednotku.Y + 21, 7, 7, 0, 180);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 27, bunkaProJednotku.Y + 21+7/2, bunkaProJednotku.X + 27 + 7, bunkaProJednotku.Y + 21 + 7 / 2);

        }

        private void vykresleniMaga(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;

            Point[] bodyMaga = { new Point(bunkaProJednotku.X + 49/2 + 5/2, bunkaProJednotku.Y +12),
                new Point(bunkaProJednotku.X + 49/2 +5/2, bunkaProJednotku.Y + 33),
                new Point(bunkaProJednotku.X + 49/2, bunkaProJednotku.Y + 35),
                new Point(bunkaProJednotku.X + 49/2 -5/2, bunkaProJednotku.Y + 33),
                new Point(bunkaProJednotku.X + 49/2 -5/2, bunkaProJednotku.Y + 12)


            };
            g.DrawEllipse(barvaJednotky, bunkaProJednotku.X+ 49/2-6, bunkaProJednotku.Y+1, 12, 12);
            g.DrawLines(barvaJednotky, bodyMaga);

        }

        private void vykresleniKneze(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;

            Point[] bodyKneze = { new Point(bunkaProJednotku.X + 49/2 - 5/2, bunkaProJednotku.Y +1),
                new Point(bunkaProJednotku.X + 49/2 + 5/2, bunkaProJednotku.Y +1),
                new Point(bunkaProJednotku.X + 49 / 2 + 5/2, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49 / 2 + 12, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49/2 + 12, bunkaProJednotku.Y+15),
                new Point(bunkaProJednotku.X + 49 / 2 + 5/2, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 + 5/2, bunkaProJednotku.Y + 35),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 35),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 - 12, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 - 12, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 1)

            };
            g.DrawLines(barvaJednotky, bodyKneze);

        }

        private void vykresleniZlodeje(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;

            Point[] bodyZlodeje = { new Point(bunkaProJednotku.X + 49/2 - 5/2/2, bunkaProJednotku.Y +1),
                new Point(bunkaProJednotku.X + 49/2 + 5/2/2, bunkaProJednotku.Y +1),
                new Point(bunkaProJednotku.X + 49 / 2 + 5/2, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49 / 2 + 6, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49/2 + 6, bunkaProJednotku.Y+10),
                new Point(bunkaProJednotku.X + 49 / 2 + 5/2, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 35),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 - 6, bunkaProJednotku.Y + 15),
                new Point(bunkaProJednotku.X + 49 / 2 - 6, bunkaProJednotku.Y + 10),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2, bunkaProJednotku.Y + 12),
                new Point(bunkaProJednotku.X + 49 / 2 - 5/2/2, bunkaProJednotku.Y + 1)

            };
            g.DrawLines(barvaJednotky, bodyZlodeje);


        }

        private void vykresleniLukostrelce(TableLayoutCellPaintEventArgs e, Jednotka jednotkaProVykresleni, Pen barvaJednotky, Rectangle bunkaProJednotku)
        {
            Graphics g = e.Graphics;
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 49 / 2 + 5 / 2 / 2, bunkaProJednotku.Y+2, bunkaProJednotku.X + 49 / 2 + 5 / 2 / 2, bunkaProJednotku.Y+35);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 10, bunkaProJednotku.Y + 37/2, bunkaProJednotku.X+35, bunkaProJednotku.Y+37/2);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 10, bunkaProJednotku.Y+37/2, bunkaProJednotku.X+15, bunkaProJednotku.Y+37/2+4);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 10, bunkaProJednotku.Y + 37 / 2, bunkaProJednotku.X + 15, bunkaProJednotku.Y + 37 / 2 - 4);
            Rectangle obloukObdelnik = new Rectangle(bunkaProJednotku.X+20,bunkaProJednotku.Y+2, 10 ,  35-2);
            g.DrawArc(barvaJednotky, obloukObdelnik, 90, 180);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 35, bunkaProJednotku.Y + 37 / 2, bunkaProJednotku.X + 37, bunkaProJednotku.Y + 37 / 2 + 3);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 35, bunkaProJednotku.Y + 37 / 2, bunkaProJednotku.X + 37, bunkaProJednotku.Y + 37 / 2 - 3);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 35, bunkaProJednotku.Y + 37 / 2, bunkaProJednotku.X + 37, bunkaProJednotku.Y + 37 / 2 + 1);
            g.DrawLine(barvaJednotky, bunkaProJednotku.X + 35, bunkaProJednotku.Y + 37 / 2, bunkaProJednotku.X + 37, bunkaProJednotku.Y + 37 / 2 - 1);
        }

        private void vykresleniJednotek(TableLayoutCellPaintEventArgs e, Jednotka[] poleJednotek) 
        {
            foreach(Jednotka j in poleJednotek) 
            {
                vykresleniJednotky(e, j);
            }
        }
        #endregion

        //vykreslování neutrálních objektů
        #region
        private void VykreslovaniNeutralnihoObjektu(TableLayoutCellPaintEventArgs e, NeutralniObjekty neutralProVykresleni)
        {
            Graphics g = e.Graphics;
            Pen barvaObjektu = new Pen(Color.Black);
            Pen pHrana = new Pen(Color.Black);

            if (e.Column == neutralProVykresleni.sloupec && e.Row == neutralProVykresleni.radek)
            {

                Rectangle bunka = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                switch (neutralProVykresleni.indexDruhu)
                {
                    case 0:
                        VykresleniZlateRudy(e, neutralProVykresleni, barvaObjektu, bunka);
                        break;
                    case 1:
                        VykresleniNepruchodnehoPole(e, neutralProVykresleni, barvaObjektu, bunka);
                        break;
                    case 2:
                        VykresleniPasti(e, neutralProVykresleni, barvaObjektu, bunka);
                        break;

                }
            }
        }

        private void VykresleniZlateRudy(TableLayoutCellPaintEventArgs e, NeutralniObjekty neutralProVykresleni, Pen barvaObjektu, Rectangle bunkaProObjekt) 
        {
            Graphics g = e.Graphics;
            SolidBrush zlata = new SolidBrush(Color.Gold);

            g.FillEllipse(zlata, bunkaProObjekt.X + 1, bunkaProObjekt.Y + 1, 47, 47);

        }

        private void VykresleniNepruchodnehoPole(TableLayoutCellPaintEventArgs e, NeutralniObjekty neutralProVykresleni, Pen barvaObjektu, Rectangle bunkaProObjekt)
        {
            Graphics g = e.Graphics;
            g.DrawLine(barvaObjektu, bunkaProObjekt.X, bunkaProObjekt.Y, bunkaProObjekt.X+49, bunkaProObjekt.Y+ 49);
            g.DrawLine(barvaObjektu, bunkaProObjekt.X, bunkaProObjekt.Y+ 49, bunkaProObjekt.X+ 49, bunkaProObjekt.Y);

        }

        private void VykresleniPasti(TableLayoutCellPaintEventArgs e, NeutralniObjekty neutralProVykresleni, Pen barvaObjektu, Rectangle bunkaProObjekt)
        {
            Graphics g = e.Graphics;

            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 1, bunkaProObjekt.Y + 1, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 1, bunkaProObjekt.Y + 20, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 1, bunkaProObjekt.Y + 39, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 20, bunkaProObjekt.Y + 1, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 20, bunkaProObjekt.Y + 20, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 20, bunkaProObjekt.Y + 39, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 39, bunkaProObjekt.Y + 1, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 39, bunkaProObjekt.Y + 20, 10, 10);
            g.DrawEllipse(barvaObjektu, bunkaProObjekt.X + 39, bunkaProObjekt.Y + 39, 10, 10);
        }

        private void VykreslovaniNeutralnichObjektu(TableLayoutCellPaintEventArgs e, NeutralniObjekty[] poleNeutralu) 
        {
            foreach (NeutralniObjekty nO in poleNeutralu)
            {
                if (nO is null) { break; }
                else
                {
                    VykreslovaniNeutralnihoObjektu(e, nO);
                }
            }
        }
        #endregion

        //vykreslování hracího pole s objekty
        private void HraciPole_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen pHrana = new Pen(Color.Black);

            g.DrawRectangle(pHrana, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
            
            vykresleniJednotek(e, (Jednotka[]) hraciPole.Tag);
            VykreslovaniNeutralnichObjektu(e, neutralniObjekty);

            if (e.Row == 0 && e.Column == 0) 
            {
                g.DrawEllipse(new Pen(Color.Blue), e.CellBounds);
            }

            if (e.Row == 7 && e.Column == 7)
            {
                g.DrawEllipse(new Pen(Color.Red), e.CellBounds);

                Jednotka[] poleJednotek = (Jednotka[])hraciPole.Tag;
                
                //SeradPoleJednotek(poleJednotek);
                poradiJednotekLB = SeradListPriorit(poradiJednotekLB, poleJednotek);
                
                Invalidate();

            }
        }

        private void HraciPole_MouseClick(object sender, MouseEventArgs e)
        {
            int lokaceY = (e.Location.X - (e.Location.X % 50)) / 50;
            int lokaceX = (e.Location.Y - (e.Location.Y % 50)) / 50;
            Jednotka[] jednotky = (Jednotka[])hraciPole.Tag;
            if (!(Akce.Tag is null) && akceDva.Tag is null) {
                switch (Akce.Tag)
                {
                    case 0:
                        Label zlatoHrace;
                        if(jednotky[0].vlastnik == 0) 
                        {
                            zlatoHrace = zlatoPlayer1;
                        }
                        else 
                        {
                            zlatoHrace = zlatoPlayer2;
                        }
                        if(int.Parse(zlatoHrace.Text) > 0) 
                        {
                            if (((jednotky[0].vlastnik == 0 && (lokaceY == 6 || lokaceY == 7) && (lokaceX == 6 || lokaceX == 7)) || (jednotky[0].vlastnik == 1 && (lokaceY == 0 || lokaceY == 1) && (lokaceX == 0 || lokaceX == 1))) && PoleJePrazdne(jednotky, lokaceX, lokaceY))
                            {
                                zlatoHrace.Text = (int.Parse(zlatoHrace.Text) - 1).ToString();
                                bool vlastniMaga = false;
                                bool vlastniZlodeje = false;
                                foreach (Jednotka j in jednotky)
                                {
                                    if(j is null) { break; }
                                    if (j.vlastnik == jednotky[0].vlastnik && j.indexDruhu == 2)
                                    {
                                        vlastniMaga = true;
                                    }
                                    if (j.vlastnik == jednotky[0].vlastnik && j.indexDruhu == 4)
                                    {
                                        vlastniZlodeje = true;
                                    }
                                }

                                if (vlastniMaga == false && vlastniZlodeje == false)
                                {
                                    DialogResult vysledek = MessageBox.Show("Ano/Yes = mág, Ne/No = zloděj", "Vyberte jednotku pro nasazení", MessageBoxButtons.YesNo);
                                    if (vysledek == DialogResult.Yes)
                                    {
                                        VyvolejJednotku(jednotky, lokaceX, lokaceY, 2);
                                    }
                                    else
                                    {
                                        VyvolejJednotku(jednotky, lokaceX, lokaceY, 4);
                                    }
                                }
                                else 
                                {
                                    if(vlastniMaga == true && vlastniZlodeje == false)
                                    {
                                        VyvolejJednotku(jednotky, lokaceX, lokaceY, 4);
                                    }
                                    if(vlastniZlodeje == true && vlastniMaga == false)
                                    {
                                        VyvolejJednotku(jednotky, lokaceX, lokaceY, 2);
                                    }
                                }

                            }
                            else 
                            {
                                MessageBox.Show("Pole není prázdné - přeskočení vašeho tahu!");
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Nedostatek zlata - přeskočení vašeho tahu!");
                        }
                        break;
                    case 1:
                        Pohyb(jednotky, lokaceX, lokaceY, 2);
                        break;
                    case 2:
                        Pohyb(jednotky, lokaceX, lokaceY, 4);
                        break;
                    case 3:
                        Utok(jednotky, lokaceX, lokaceY, 1, 1);
                        jednotky[0].hpSoucasne = jednotky[0].hpSoucasne + 1;
                        break;
                    case 4:
                        Utok(jednotky, lokaceX, lokaceY, 1, 2);
                        break;
                    case 5:
                        //léčení je to samé jako útok se záporným poškozením
                        Utok(jednotky, lokaceX, lokaceY, -1, 3);
                        break;
                    case 6:
                        Pohyb(jednotky, lokaceX, lokaceY, 3);
                        break;
                    case 7:
                        Utok(jednotky, lokaceX, lokaceY, 1, 2);
                        MessageBox.Show("Nyní posuňte jednotkou");
                        akceDva.Tag = 7;
                        break;
                    case 8:
                        Utok(jednotky, lokaceX, lokaceY, 2, 1);
                        break;
                    case 9:
                        jednotky[0].hpSoucasne = jednotky[0].hpSoucasne + 2; 
                        break;
                    case 10:
                        //past na libovolném poli
                        if (PoleJePrazdne(jednotky, lokaceX, lokaceY))
                        {
                            for (int i = 0; i < neutralniObjekty.Length; i++)
                            {
                                NeutralniObjekty nO = neutralniObjekty[i];
                                if (nO is null)
                                {
                                    neutralniObjekty[i] = new NeutralniObjekty(lokaceX, lokaceY, 2);
                                    break;
                                }
                            }
                        }
                        break;
                    case 11:
                        Utok(jednotky, lokaceX, lokaceY, 3, 1);
                        MessageBox.Show("Mág špatně vyčaroval své kouzlo - hrdinně umřel.");
                        jednotky[0].hpSoucasne = 0;
                        break;
                    case 12:
                        Utok(jednotky, lokaceX, lokaceY, 2, 2);
                        break;
                    case 13:
                        //teleportace libovolné jednotky o 1 pole
                        int x = 0;
                        bool skipTahu = false;
                        for(x = 0; x<jednotky.Length; x++) 
                        {
                            if(jednotky[x]is null) 
                            {
                                skipTahu = true; 
                                break; 
                            }
                            if(jednotky[x].radek == lokaceX && jednotky[x].sloupec == lokaceY) 
                            {
                                break;
                            }
                        }
                        if (skipTahu == false)
                        {
                            MessageBox.Show("Nyní hýbete zvolenou jednotku - range 1 pole");
                            akceDva.Tag = 13;
                            target.Tag = jednotky[x];
                        }
                        else 
                        {
                            MessageBox.Show("Nebyla zvolena žádná jednotka pro teleportaci - přeskočení vašeho tahu!");
                        }
                        break;
                    case 14:
                        Pohyb(jednotky, lokaceX, lokaceY, 1);
                        break;
                    case 15:
                        Utok(jednotky, lokaceX, lokaceY, 1, 256);
                        break;
                    case 16:
                        Utok(jednotky, lokaceX, lokaceY, 2, 3);
                        break;
                    case 17:
                        Utok(jednotky, lokaceX, lokaceY, 3, 2);
                        break;
                    case 18:
                        Pohyb(jednotky, lokaceX, lokaceY, 4);
                        break;
                    case 19:
                        Utok(jednotky, lokaceX, lokaceY, 3, 1);
                        break;
                    case 20:
                        Utok(jednotky, lokaceX, lokaceY, 1, 1);
                        if(jednotky[0].vlastnik == 0) 
                        {
                            if(int.Parse(zlatoPlayer2.Text) > 0) 
                            {
                                zlatoPlayer2.Text = (int.Parse(zlatoPlayer2.Text) - 1).ToString();
                                zlatoPlayer1.Text = (int.Parse(zlatoPlayer1.Text) + 1).ToString();
                            }
                        }
                        else
                        {
                            if (int.Parse(zlatoPlayer1.Text) > 0)
                            {
                                zlatoPlayer1.Text = (int.Parse(zlatoPlayer1.Text) - 1).ToString();
                                zlatoPlayer2.Text = (int.Parse(zlatoPlayer2.Text) + 1).ToString();
                            }
                        }
                        break;
                    case 21:
                        //hbitý úder
                        bool kontrolaMoznostiAkce = PoleJePrazdne(jednotky, lokaceX, lokaceY);
                        Pohyb(jednotky, lokaceX, lokaceY, 1);
                        if(kontrolaMoznostiAkce) 
                        {
                            int[] lokacePole1 = { jednotky[0].radek - 1, jednotky[0].sloupec };
                            int[] lokacePole2 = { jednotky[0].radek + 1, jednotky[0].sloupec };
                            int[] lokacePole3 = { jednotky[0].radek, jednotky[0].sloupec-1 };
                            int[] lokacePole4 = { jednotky[0].radek, jednotky[0].sloupec+1 };

                            UtokKolemSebe(jednotky, lokacePole1, 1);
                            UtokKolemSebe(jednotky, lokacePole2, 1);
                            UtokKolemSebe(jednotky, lokacePole3, 1);
                            UtokKolemSebe(jednotky, lokacePole4, 1);
                        }
                        break;
                    case 22:
                        Pohyb(jednotky, lokaceX, lokaceY, 4);
                        break;
                    case 23:
                        Utok(jednotky, lokaceX, lokaceY, 1, 3);
                        break;
                    case 24:
                        Utok(jednotky, lokaceX, lokaceY, 2, 3);
                        break;
                    case 25:
                        //past na sousedním poli                        
                        if (PoleJePrazdne(jednotky, lokaceX, lokaceY) && Math.Abs(lokaceX - jednotky[0].radek) <= 1 && Math.Abs(lokaceY - jednotky[0].sloupec) <= 1 && ((Math.Abs(lokaceY - jednotky[0].sloupec)) + (Math.Abs(lokaceX - jednotky[0].radek)) <= 1))
                        {
                            for (int i = 0; i < neutralniObjekty.Length; i++)
                            {
                                NeutralniObjekty nO = neutralniObjekty[i];
                                if (nO is null)
                                {
                                    neutralniObjekty[i] = new NeutralniObjekty(lokaceX, lokaceY, 2);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Neplatné umístnění pasti - tah přeskočen!");
                        }
                        
                        break;

                }
                
            }
            else 
            {
                if(!(akceDva.Tag is null)) 
                {
                    switch (akceDva.Tag)
                    {
                        case 7:
                            Pohyb(jednotky, lokaceX, lokaceY, 1);
                            akceDva.Tag = null;
                            break;
                        case 13:
                            if (Math.Abs(lokaceX - ((Jednotka)target.Tag).radek) <= 1 && Math.Abs(lokaceY - ((Jednotka)target.Tag).sloupec) <= 1 && ((Math.Abs(lokaceY - ((Jednotka)target.Tag).sloupec)) + (Math.Abs(lokaceX - ((Jednotka)target.Tag).radek)) <= 1) && PoleJePrazdne(jednotky, lokaceX, lokaceY))
                            {
                                ((Jednotka)target.Tag).radek = lokaceX;
                                ((Jednotka)target.Tag).sloupec = lokaceY;
                            }
                            else
                            {
                                MessageBox.Show("Špatný pohyb - přeskočení vašeho tahu!");
                            }
                            akceDva.Tag = null;
                            target.Tag = null;
                            break;
                    }
                }
                else 
                {
                    MessageBox.Show("Zvolte kartu!","Nebyla zvolena karta! TAH PŘESKOČEN!");
                }
            }

            if (akceDva.Tag is null)
            {
                KonecNaNeutralnimObjektu(jednotky);

                

                var temp = jednotky[0];

                for (int i = 0; i < jednotky.Length; i++)
                {
                    if (jednotky[i + 1] is null)
                    {
                        jednotky[i] = temp;
                        break;
                    }
                    else
                    {
                        jednotky[i] = jednotky[i + 1];
                    }
                }



                int vymazeneJednotkyPocet = 0;
                for (int i = 0; i < jednotky.Length; i++)
                {
                    if (jednotky[i] is null)
                    {
                        break;
                    }
                    else
                    {
                        if (jednotky[i].hpSoucasne <= 0)
                        {
                            jednotky[i] = null;
                            vymazeneJednotkyPocet++;
                        }
                        if (!(jednotky[i] is null))
                        {
                            if (jednotky[i].hpSoucasne > jednotky[i].hpMax)
                            {
                                jednotky[i].hpSoucasne = jednotky[i].hpMax;
                            }
                        }
                    }
                }

                while (vymazeneJednotkyPocet > 0)
                {
                    if (vymazeneJednotkyPocet > 0)
                    {
                        for (int i = 0; i < (jednotky.Length - 1); i++)
                        {
                            if (jednotky[i] is null && vymazeneJednotkyPocet == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (jednotky[i] is null)
                                {
                                    jednotky[i] = jednotky[i + 1];
                                    jednotky[i + 1] = null;
                                    vymazeneJednotkyPocet = vymazeneJednotkyPocet - 1;
                                }
                            }
                        }
                    }
                }

                ZahodNullNaKonec(jednotky);

                List<Label> ll = ((List<Label>)preskocitButton.Tag);
                for (int i = ll.Count - 1; i >= 0; i--)
                {
                    ll[i].Visible = false;

                    ll.Remove(ll[i]);

                    preskocitButton.Tag = ll;

                }

                KontrolaVictoryKondice(jednotky);
                Akce.Tag = null;
                akceDva.Tag = null;
                target.Tag = null;
                VypisTextKaret(jednotky);
                Invalidate(invalidateChildren: true);
            }
        }
        
        private ListBox SeradListPriorit(ListBox lB,Jednotka[] jP) 
        {
            lB.Items.Clear();
            foreach (var v in jP)
            {
                if (v != null)
                {
                    lB.Items.Add(v);
                }
                else
                {
                    break;
                }

            }
            return lB;
        }

        private void kartaL_Click(object sender, EventArgs e)
        {
            string textKarty = sender.ToString();
            int indexTextu = textKarty.IndexOf("Text: ")+6;
            textKarty = textKarty.Substring(indexTextu);

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

            if (akceDva.Tag is null)
            {
                Akce.Tag = Array.IndexOf(vsechnyKarty, textKarty);
                if (Array.IndexOf(vsechnyKarty, textKarty) == 9)
                {
                    MessageBox.Show("Klikněte na libovolné pole pro aktivaci");
                }
            }
            

        }

        private void VypisTextKaret(Jednotka[] poleJednotek) 
        {
            switch (poleJednotek[0].indexDruhu)
            {
                case 0:
                    string[] karty = GeneratorKaret.GenerujKartyProRytire();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
                case 1:
                    karty = GeneratorKaret.GenerujKartyProKatapult();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
                case 2:
                    karty = GeneratorKaret.GenerujKartyProMaga();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
                case 3:
                    karty = GeneratorKaret.GenerujKartyProKneze();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
                case 4:
                    karty = GeneratorKaret.GenerujKartyProZlodeje();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
                case 5:
                    karty = GeneratorKaret.GenerujKartyProLukostrelce();
                    karta1L.Text = karty[0];
                    karta2L.Text = karty[1];
                    karta3L.Text = karty[2];
                    karta4L.Text = karty[3];
                    break;
            }
        }

        public void Utok(Jednotka[] jednotky, int lokaceX, int lokaceY, int dmg, int range) 
        {
            bool skip = false;
            for (int i = 0; i < jednotky.Length; i++)
            {
                if (jednotky[i] is null)
                {
                    skip = true;
                    break;
                }
                if ((jednotky[i].radek == lokaceX && jednotky[i].sloupec == lokaceY) && (Math.Abs(lokaceX - jednotky[0].radek) <= range && Math.Abs(lokaceY - jednotky[0].sloupec) <= range && ((Math.Abs(lokaceY - jednotky[0].sloupec)) + (Math.Abs(lokaceX - jednotky[0].radek)) <= range)))
                {
                    jednotky[i].hpSoucasne = jednotky[i].hpSoucasne - dmg;
                    break;
                }
            }
            if (skip)
            {
                MessageBox.Show("Netrefil!");
            }
        }
        public void UtokKolemSebe(Jednotka[] jednotky, int[] lokace, int dmg)
        {
            int lokaceX = lokace[0];
            int lokaceY = lokace[1];

            if (lokaceX>=0 && lokaceX<=7 && lokaceY >= 0 && lokaceY <= 7) 
            {
                for (int i = 0; i < jednotky.Length; i++)
                {
                    if (jednotky[i] is null)
                    {
                        break;
                    }
                    if ((jednotky[i].radek == lokaceX && jednotky[i].sloupec == lokaceY))
                    {
                        jednotky[i].hpSoucasne = jednotky[i].hpSoucasne - dmg;
                        break;
                    }
                } 
            }
        }

        public void Pohyb(Jednotka[] jednotky, int lokaceX, int lokaceY, int range) 
        {
            if (Math.Abs(lokaceX - jednotky[0].radek) <= range && Math.Abs(lokaceY - jednotky[0].sloupec) <= range && ((Math.Abs(lokaceY - jednotky[0].sloupec)) + (Math.Abs(lokaceX - jednotky[0].radek)) <= range) && PoleJePrazdne(jednotky, lokaceX, lokaceY))
            {
                jednotky[0].radek = lokaceX;
                jednotky[0].sloupec = lokaceY;
            }
            else
            {
                MessageBox.Show("Špatný pohyb - přeskočení vašeho tahu!");
            }
        }
        public void VyvolejJednotku(Jednotka[] jednotky, int lokaceX, int lokaceY, int indexDruhu) 
        {
            for (int i = 0; i < jednotky.Length; i++)
            {
                if (jednotky[i + 1] is null)
                {
                    jednotky[i + 1] = new Jednotka(lokaceX, lokaceY, indexDruhu, jednotky[0].vlastnik);
                    break;
                }
            }
        }
        public bool PoleJePrazdne(Jednotka[] jednotky, int lokaceX, int lokaceY) 
        {
            foreach(Jednotka j in jednotky) 
            {
                if(j is null) { break; }
                if(j.radek == lokaceX && j.sloupec == lokaceY) 
                {
                    return false;
                }
            }
            foreach(NeutralniObjekty nO in neutralniObjekty) 
            {
                if(nO is null) { break; }
                if(nO.radek == lokaceX && nO.sloupec == lokaceY && nO.indexDruhu == 1) 
                {
                    return false; 
                }
            }
            return true;
        }

        public void KonecNaNeutralnimObjektu(Jednotka[] jednotky) 
        {
            foreach(Jednotka j in jednotky) 
            {
                if(j is null) { break; }
                for(int i = 0; i<neutralniObjekty.Length; i++) 
                {
                    NeutralniObjekty nO = neutralniObjekty[i];
                    if(nO is null) { break; }
                    if(j.radek == nO.radek && j.sloupec == nO.sloupec) 
                    {
                        if(nO.indexDruhu == 0) 
                        {
                            if (j.vlastnik == 0) 
                            {
                                zlatoPlayer1.Text = (int.Parse(zlatoPlayer1.Text) + 1).ToString();
                                neutralniObjekty[i] = null;
                                if (nO.indexDruhu == 0 || nO.indexDruhu == 2)
                                {
                                    for (int x = i; x < (neutralniObjekty.Length - 1); x++)
                                    {
                                        if (neutralniObjekty[x] is null && !(neutralniObjekty[x + 1] is null))
                                        {
                                            neutralniObjekty[x] = neutralniObjekty[x + 1];
                                            neutralniObjekty[x + 1] = null;
                                        }
                                        else
                                        {
                                            if (neutralniObjekty[x] is null && neutralniObjekty[x + 1] is null)
                                            {
                                                i--;
                                                break;
                                            }
                                        }
                                    }
                                }

                            }
                            if(j.vlastnik == 1) 
                            {
                                zlatoPlayer2.Text = (int.Parse(zlatoPlayer2.Text) + 1).ToString();
                                neutralniObjekty[i] = null;
                                if (nO.indexDruhu == 0 || nO.indexDruhu == 2)
                                {
                                    for (int x = i; x < (neutralniObjekty.Length - 1); x++)
                                    {
                                        if (neutralniObjekty[x] is null && !(neutralniObjekty[x + 1] is null))
                                        {
                                            neutralniObjekty[x] = neutralniObjekty[x + 1];
                                            neutralniObjekty[x + 1] = null;
                                        }
                                        else
                                        {
                                            if (neutralniObjekty[x] is null && neutralniObjekty[x + 1] is null)
                                            {
                                                i--;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }
                        else 
                        {
                            j.hpSoucasne = 0;
                            MessageBox.Show("Byla spuštěna past!");
                            if (nO.indexDruhu == 2) {
                                neutralniObjekty[i] = null;
                                for (int x = i; x < (neutralniObjekty.Length - 1); x++)
                                {
                                    if (neutralniObjekty[x] is null && !(neutralniObjekty[x+1]is null))
                                    {
                                        neutralniObjekty[x] = neutralniObjekty[x + 1];
                                        neutralniObjekty[x + 1] = null;
                                    }
                                    else
                                    {
                                        if (neutralniObjekty[x] is null && neutralniObjekty[x + 1] is null)
                                        {
                                            i--;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void preskocitButton_Click(object sender, EventArgs e)
        {
            Akce.Tag = null;
            akceDva.Tag = null;
            target.Tag = null;

            Jednotka[] jednotky = (Jednotka[])hraciPole.Tag;

            var temp = jednotky[0];

            for (int i = 0; i < jednotky.Length; i++)
            {
                if (jednotky[i + 1] is null)
                {
                    jednotky[i] = temp;
                    break;
                }
                else
                {
                    jednotky[i] = jednotky[i + 1];
                }
            }


            List<Label> ll = ((List<Label>)preskocitButton.Tag);
            for (int i = ll.Count - 1; i >= 0; i--)
            {
                ll[i].Visible = false;

                ll.Remove(ll[i]);

                preskocitButton.Tag = ll;

            }
            Akce.Tag = null;

            VypisTextKaret(jednotky);
            Invalidate(invalidateChildren: true);

        }
        private void ZahodNullNaKonec(Jednotka[] jednotky) 
        {
            for(int i = 0; i< (jednotky.Length-1); i++) 
            {
                if (jednotky[i] is null && jednotky[i + 1] is null) { break; } 
                else 
                {
                    if(jednotky[i] is null && !(jednotky[i+1] is null)) 
                    {
                        jednotky[i] = jednotky[i + 1];
                        jednotky[i + 1] = null;
                    }
                }

            }
        }
        private void KontrolaVictoryKondice(Jednotka[] jednotky) 
        {
            bool hracJednaMaJednotky = false;
            bool hracDvaMaJednotky = false;
            bool zabranaZakladnaHraceJedna = false;
            bool zabranaZakladnaHraceDva = false;
            for (int i = 0; i< jednotky.Length; i++) 
            {
                if(jednotky[i] is null) 
                { 
                    break; 
                } 
                else 
                {
                    if(jednotky[i].vlastnik == 0) 
                    {
                        hracJednaMaJednotky = true;
                    }
                    else 
                    {
                        hracDvaMaJednotky = true;
                    }
                    if (jednotky[i].radek == 0 && jednotky[i].sloupec == 0 && jednotky[i].vlastnik == 0) 
                    {
                        zabranaZakladnaHraceDva = true;
                    }
                    if (jednotky[i].radek == 7 && jednotky[i].sloupec == 7 && jednotky[i].vlastnik == 1)
                    {
                        zabranaZakladnaHraceJedna = true;
                    }
                }
            }
            if (hracJednaMaJednotky == false && hracDvaMaJednotky == false)
            {
                MessageBox.Show("Oba týmy nemají jednotky", "Remíza!");
                Form5 formProJmeno = new Form5(-1);
                this.Hide();
            }
            else
            {
                if (hracJednaMaJednotky == false)
                {
                    MessageBox.Show("Jednotky hráče 1 byly eliminovány", "Vítězství hráče 2!");
                    Form5 formProJmeno = new Form5(1);
                    formProJmeno.Show();
                    this.Hide();
                }
                if (hracDvaMaJednotky == false)
                {
                    MessageBox.Show("Jednotky hráče 2 byly eliminovány", "Vítězství hráče 1!");
                    Form5 formProJmeno = new Form5(0);
                    formProJmeno.Show();
                    this.Hide();
                }
            }
            if (zabranaZakladnaHraceJedna) 
            {
                MessageBox.Show("Základna hráče 1 byla zabrána", "Vítězství hráče 2!");
                Form5 formProJmeno = new Form5(1);
                formProJmeno.Show();
                this.Hide();
            }
            if (zabranaZakladnaHraceDva)
            {
                MessageBox.Show("Základna hráče 2 byla zabrána", "Vítězství hráče 1!");
                Form5 formProJmeno = new Form5(0);
                formProJmeno.Show();
                this.Hide();
            }
        }
        private void FormHra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            List<string> jednotkyString = new List<string>();
            List<string> neutralniString = new List<string>();
            //jednotka bude ukládána jakožto: souřadniceX souřadniceY druhIndex vlastník hpSoučasné 
            foreach(Jednotka j in (Jednotka[])hraciPole.Tag) 
            {
                if(j is null) { break; }
                jednotkyString.Add(j.radek + " " + j.sloupec + " " + j.indexDruhu + " " + j.vlastnik + " " + j.hpSoucasne);

            }
            //neutrální objekty budou uloženy jakožto: souřadniceX souřadniceY indexDruhu
            foreach(NeutralniObjekty nO in neutralniObjekty) 
            {
                if(nO is null) { break; }
                neutralniString.Add(nO.radek + " " + nO.sloupec + " " + nO.indexDruhu) ;
            }
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

            int[] poleZlata = {int.Parse(zlatoPlayer1.Text), int.Parse(zlatoPlayer2.Text) };
            int[] poleKaret = {
            Array.IndexOf(vsechnyKarty, karta1L.Text),
            Array.IndexOf(vsechnyKarty, karta2L.Text),
            Array.IndexOf(vsechnyKarty, karta3L.Text),
            Array.IndexOf(vsechnyKarty, karta4L.Text),
            };
            Form4 form = new Form4(jednotkyString, neutralniString, poleZlata,poleKaret);
            form.Show();
        }

        private void staty_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }
    }
}
