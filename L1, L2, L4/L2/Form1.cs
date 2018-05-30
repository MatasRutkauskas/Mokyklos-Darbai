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

namespace L2
{
    public partial class Form1 : Form
    {
        const string fr = "...\\...\\Rezultatai.txt";
        const string fd1 = "...\\...\\Duom1.txt";
        const string fd2 = "...\\...\\Duom2.txt";
        const string fd3 = "...\\...\\Duom3.txt";

        List<Pabaisa> Pabaisos1;
        List<Pabaisa> Pabaisos2;
        List<Pabaisa> Pabaisos3;
        List<Pabaisa> Surinktas;

        string miskas1, miskas2, miskas3;
        string stud1, stud2, stud3;

        public Form1()
        {
            InitializeComponent();
            spausdintiToolStripMenuItem.Enabled = false;
            pasirinktiAntrąToolStripMenuItem.Enabled = false;
            pasirinktiTrečiąToolStripMenuItem.Enabled = false;
            salintiToolStripMenuItem.Enabled = false;
            papildytiRinkiniToolStripMenuItem.Enabled = false;
            sudarytiRinkiniToolStripMenuItem.Enabled = false;
        }

        static List<Pabaisa> SkaitytiList(string fd, out string studvard, out string mpav)
        {
            List<Pabaisa> Pabaisos = new List<Pabaisa>();

            using (StreamReader srautas = new StreamReader(fd, Encoding.GetEncoding(1257)))
            {
                string eilute;

                studvard = srautas.ReadLine();

                mpav = srautas.ReadLine();

                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string pavadinimas = eilDalis[0];
                    int ragai = int.Parse(eilDalis[1]);
                    int uodegos =int.Parse(eilDalis[2]);
                    Pabaisa pabaisa = new Pabaisa(pavadinimas, ragai, uodegos);
                    Pabaisos.Add(pabaisa);
                }
            }
            return Pabaisos;
        }

        static void SpausdintiList(string fr, List<Pabaisa> P, string antraste, string pavadinimas)
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

                for (int i = 0; i < P.Count; i++)
                {

                    rr.WriteLine("|{0,11}|{1,13}|{2,15}|", P[i].pavadinimas, P[i].ragai, P[i].uodegos);
                    rr.WriteLine("|-----------|-------------|---------------|");
                }
                rr.WriteLine();
            }
        }

        static void Spausdinti(string fr, List<Pabaisa> P1, List<Pabaisa> P2, string miskas1, string miskas2)
        {
            FileStream fs = new FileStream(fr, FileMode.Append);
            using (StreamWriter rr = new StreamWriter(fs))
            {
                int sumragu = 0;
                int sumuodeg = 0;
                int indx;

                KiekisMiske(P1, ref sumragu, ref sumuodeg);
                rr.WriteLine("Miške: {0} yra {1} ragų ir {2} uodegų", miskas1, sumragu, sumuodeg);
                rr.WriteLine();

                KiekisMiske(P2, ref sumragu, ref sumuodeg);
                rr.WriteLine("Miške: {0} yra {1} ragų ir {2} uodegų", miskas2, sumragu, sumuodeg);
                rr.WriteLine();

                indx = MazUodeguota(P1);

                if (indx != -1)
                {
                    rr.WriteLine("Mažiausiai uodeguota pabaisa miške {0}\n turi {1} ragų", miskas1, P1[indx].ragai);
                }
                else
                {
                    rr.WriteLine("Mažiausiai uodeguotos pabaisos miške {0} nėra", miskas1);
                }

                rr.WriteLine();
                indx = MazUodeguota(P2);

                if (indx != -1)
                {
                    rr.WriteLine("Mažiausiai uodeguota pabaisa miške {0}\n turi {1} ragų", miskas2, P2[indx].ragai);
                }
                else
                {
                    rr.WriteLine("Mažiausiai uodeguotos pabaisos miške {0} nėra", miskas2);
                }
            }
        }

        static void KiekisMiske(List<Pabaisa> Pabaisos, ref int sumarag, ref int sumauod)
        {
            sumarag = 0;
            sumauod = 0;
            for (int i = 0; i < Pabaisos.Count; i++)
            {
                sumarag += Pabaisos[i].ragai;
                sumauod += Pabaisos[i].uodegos;
            }
        }

        static int MazUodeguota(List<Pabaisa> Pabaisos)
        {
            int min = 9999;
            int indx = -1;
            for (int i = 0; i < Pabaisos.Count; i++)
            {
                if (Pabaisos[i].uodegos < min)
                {
                    min = Pabaisos[i].uodegos;
                    indx = i;
                }
            }
            return indx;
        }

        static void Formuoti(List<Pabaisa> Pabaisos, List<Pabaisa> Pabaisos2)
        {
            for (int i = 0; i < Pabaisos.Count; i++)
            {
                if (Pabaisos[i].ragai > Pabaisos[i].uodegos)
                {
                    Pabaisa naujas = new Pabaisa(Pabaisos[i].pavadinimas, Pabaisos[i].ragai, Pabaisos[i].uodegos);
                    Pabaisos2.Add(naujas);
                }
            }
        }

        static void Rikiuoti(List<Pabaisa> Pabaisos)
        {
            Pabaisos.Sort(
                (x, y) => x.ragai.CompareTo(y.ragai)
            );
        }

        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            SpausdintiList(fr, Pabaisos1, "Pirmas miskas", miskas1);
            SpausdintiList(fr, Pabaisos2, "Antras miskas", miskas2);
            SpausdintiList(fr, Pabaisos3, "Trecias miskas", miskas3);
            Spausdinti(fr, Pabaisos1, Pabaisos2, miskas1, miskas2);
            richTextBox1.Text = File.ReadAllText(fr);
            sudarytiRinkiniToolStripMenuItem.Enabled = true;
        }

        private void sudarytiRinkiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formuoti(Pabaisos1, Surinktas);
            Formuoti(Pabaisos2, Surinktas);
            SpausdintiList(fr, Surinktas, "", "Surinktas rinkinys");
            Rikiuoti(Surinktas);
            SpausdintiList(fr, Surinktas, "", "Surikiuotas");
            richTextBox1.Text = File.ReadAllText(fr);
            papildytiRinkiniToolStripMenuItem.Enabled = true;
            salintiToolStripMenuItem.Enabled = true;
        }

        private void papildytiRinkiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Papildyti(Surinktas, Pabaisos3);
            SpausdintiList(fr, Surinktas, "", "Papildytas surinktas rinkinys");
            richTextBox1.Text = File.ReadAllText(fr);
            papildytiRinkiniToolStripMenuItem.Enabled = false;
        }

        private void salintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (str != "")
            {
                Salinti(Surinktas, str[0]);
                SpausdintiList(fr, Surinktas, "", "Su pasalinta pabaisa");
                richTextBox1.Text = File.ReadAllText(fr);
            }
        }

        private void pasirinktiPirmąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = openFileDialog1.FileName;
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                Pabaisos1 = SkaitytiList(fv, out stud1, out miskas1);
                // Meniu punktų nustatymai
                pasirinktiAntrąToolStripMenuItem.Enabled = true;
            }
        }

        private void pasirinktiAntrąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = openFileDialog1.FileName;
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                Pabaisos2 = SkaitytiList(fv, out stud2, out miskas2);
                // Meniu punktų nustatymai
                pasirinktiTrečiąToolStripMenuItem.Enabled = true;
            }
        }

        private void pasirinktiTrečiąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = openFileDialog1.FileName;
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                Pabaisos3 = SkaitytiList(fv, out stud3, out miskas3);
                // Meniu punktų nustatymai
                spausdintiToolStripMenuItem.Enabled = true;
            }
        }

        static void Papildyti(List<Pabaisa> Surinktas, List<Pabaisa> Pabaisos)
        {    
            for (int j = 0; j < Pabaisos.Count; j++)
            {
                if (Pabaisos[j].uodegos > UodVidurkis(Surinktas))
                {
                    Prideti(Surinktas, Pabaisos[j]);
                }
            }  
        }

        static void Prideti(List<Pabaisa> Surinktas, Pabaisa pb)
        {
            int k = 0;

            while (k < Surinktas.Count && pb.ragai <= Surinktas[k].ragai)
            {
                k++;
            }

            Surinktas.Insert(k, pb);
        }

        static double UodVidurkis(List<Pabaisa> Pabaisos)
        {
            double vidurkis = 0;
            double suma = 0;

            for (int i = 0; i < Pabaisos.Count; i++)
            {
                suma = suma + Pabaisos[i].uodegos;
            }

            vidurkis = suma / Pabaisos.Count;
            return vidurkis;
        }

        static void Salinti(List<Pabaisa> P, char c)
        {
            for (int i = 0; i < P.Count; i++)
            {
                string pav = P[i].pavadinimas;

                if (char.ToLower(pav[0]) == char.ToLower(c))
                {
                    P.RemoveAt(i);
                }
            }
        }
    }
}
