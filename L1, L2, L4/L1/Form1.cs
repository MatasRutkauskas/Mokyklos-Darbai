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

namespace L1
{
    public partial class Form1 : Form
    {
        const string fd1 = "..\\..\\Duom1.txt";
        const string fd2 = "..\\..\\Duom2.txt";
        const string fr = "..\\..\\Rezultatai.txt";

        Pabaisos P1 = new Pabaisos();
        Pabaisos P2 = new Pabaisos();
        Pabaisos A = new Pabaisos();

        public Form1()
        {
            InitializeComponent();
            Skaiciuoti.Enabled = false;
            Pasalinti.Enabled = false;
            Ivesti.Enabled = true;
            Uzdaryti.Enabled = true;

            if (File.Exists(fr))
            {
                File.Delete(fr);
            }
            
        }

        static void Skaityti(string fd, Pabaisos P)
        {
            string misk;
            string stud;

            string pavadinimas;
            int ragai;
            int uodegos;

            using (StreamReader reader = new StreamReader(fd, Encoding.GetEncoding(1257)))
            {
                string line;
                string[] parts;

                line = reader.ReadLine();
                stud = line;

                line = reader.ReadLine();
                misk = line;
                P.miskas = misk;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    pavadinimas = parts[0];
                    ragai = int.Parse(parts[1]);
                    uodegos = int.Parse(parts[2]);
                    P.Deti(new Pabaisa(pavadinimas, ragai, uodegos));
                }
            }
        }

        static void KiekisMiske(Pabaisos P, ref int sumarag, ref int sumauod)
        {
            sumarag = 0;
            sumauod = 0;
            for (int i = 0; i < P.n; i++)
            {
                sumarag += P.Imti(i).ragai;
                sumauod += P.Imti(i).uodegos;
            }
            
        }

        static int MazUodeguota(Pabaisos P)
        {
            int min = 9999;
            int indx = -1;
            for (int i = 0; i < P.n; i++)
            {
                if (P.Imti(i).uodegos < min)
                {
                    min = P.Imti(i).uodegos;
                    indx = i;
                }
            }
            return indx;
        }

        static void SudarytiMas(Pabaisos P, Pabaisos A)
        {
            for (int i = 0; i < P.n; i++)
            {
                if (P.Imti(i).ragai > P.Imti(i).uodegos)
                {
                    Pabaisa naujas = new Pabaisa(P.Imti(i).pavadinimas, P.Imti(i).ragai, P.Imti(i).uodegos);
                    A.Deti(naujas);
                }
            }
        }

        static void Salinti(Pabaisos P, char c)
        {
            for (int i = 0; i < P.n; i++)
            {
                string pav = P.Imti(i).pavadinimas;

                if (pav[0] == c)
                {
                    P.Pasalinti(i);
                }
            }
        }

        static void Spausdinti2(string fr, Pabaisos P, string antraste, string pavadinimas)
        {
            FileStream fs = new FileStream(fr, FileMode.Append);
            using (StreamWriter rr = new StreamWriter(fs))
            {
                rr.WriteLine(antraste + "\n");
                rr.WriteLine("|-------------------------|");
                rr.WriteLine("|{0, -25}|", pavadinimas);
                rr.WriteLine("|-----------|-------------|---------------|");
                rr.WriteLine("|Pavadinimas|Ragų skaičius|Uodegų skaičius|");
                rr.WriteLine("|-----------|-------------|---------------|");

                for (int i = 0; i < P.n; i++)
                {

                    rr.WriteLine("|{0,11}|{1,13}|{2,15}|", P.Imti(i).pavadinimas, P.Imti(i).ragai, P.Imti(i).uodegos);
                    rr.WriteLine("|-----------|-------------|---------------|");
                }
                rr.WriteLine();
            }
        }

        static void Spausdinti(string fr, Pabaisos P1, Pabaisos P2)
        {
            FileStream fs = new FileStream(fr, FileMode.Append);
            using (StreamWriter rr = new StreamWriter(fs))
            {
                int sumragu = 0;
                int sumuodeg = 0;
                int indx;

                KiekisMiske(P1, ref sumragu, ref sumuodeg);
                rr.WriteLine("Miške: {0} yra {1} ragų ir {2} uodegų", P1.miskas, sumragu, sumuodeg);
                rr.WriteLine();

                KiekisMiske(P2, ref sumragu, ref sumuodeg);
                rr.WriteLine("Miške: {0} yra {1} ragų ir {2} uodegų", P2.miskas, sumragu, sumuodeg);
                rr.WriteLine();

                indx = MazUodeguota(P1);

                if (indx != -1)
                {
                    rr.WriteLine("Mažiausiai uodeguota pabaisa miške {0}\n turi {1} ragų", P1.miskas, P1.Imti(indx).ragai);
                }
                else
                {
                    rr.WriteLine("Mažiausiai uodeguotos pabaisos miške {0} nėra", P1.miskas);
                }

                rr.WriteLine();
                indx = MazUodeguota(P2);

                if (indx != -1)
                {
                    rr.WriteLine("Mažiausiai uodeguota pabaisa miške {0}\n turi {1} ragų", P2.miskas, P2.Imti(indx).ragai);
                }
                else
                {
                    rr.WriteLine("Mažiausiai uodeguotos pabaisos miške {0} nėra", P2.miskas);
                }
            }
        }

        private void Ivesti_Click(object sender, EventArgs e)
        {
            prad1.LoadFile(fd1, RichTextBoxStreamType.PlainText);
            prad2.LoadFile(fd2, RichTextBoxStreamType.PlainText);
            Skaityti(fd1, P1);
            Skaityti(fd2, P2);

            Skaiciuoti.Enabled = true;
        }

        private void Skaiciuoti_Click(object sender, EventArgs e)
        {
            SudarytiMas(P1, A);
            SudarytiMas(P2, A);
            Spausdinti2(fr, P1, "Pradiniai duomenys1: ", P1.miskas);
            Spausdinti2(fr, P2, "Pradiniai duomenys2: ", P2.miskas);
            Spausdinti2(fr, A, "Turi daugiau ragų nei uodegų", "Sudarytas rinkinys");
            A.Rikiuoti();
            Spausdinti2(fr, A, "Turi daugiau ragų nei uodegų", "Surikiuotas rinkinys");
            Spausdinti(fr, P1, P2);

            rezultatai.Text += File.ReadAllText(fr);

            Pasalinti.Enabled = true; 
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Pasalinti_Click(object sender, EventArgs e)
        {
            string ch = textBox1.Text;
            Salinti(A, ch[0]);

            Spausdinti2(fr, A, "Turi daugiau ragų nei uodegų", "Rinkinys su pašalinimu");
            rezultatai.Text = "";
            rezultatai.Text += File.ReadAllText(fr);
        }
    }
}
