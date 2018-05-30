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
        List<Pabaisa> Pabaisos1;
        List<Pabaisa> Pabaisos2;
        List<Pabaisa> Pabaisos3;
        List<Pabaisa> Surinktas;

        public Form1()
        {
            InitializeComponent();
        }

        static List<Pabaisa> SkaitytiList(string fd, out string studvard, out string mpav)
        {
            List<Pabaisa> Pabaisos = new List<Pabaisa>();

            using (StreamReader srautas = new StreamReader(fd, Encoding.GetEncoding(1257)))
            {
                string eilute;

                eilute = srautas.ReadLine();
                studvard = eilute;

                eilute = srautas.ReadLine();
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
            for (int i = 0; i < Surinktas.Count; i++)
            {
                if (pb.ragai > Surinktas[i].ragai)
                {
                    Surinktas.Insert(i, pb);
                }
            }
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

                if (pav[0] == c)
                {
                    P.RemoveAt(i);
                }
            }
        }
    }
}
