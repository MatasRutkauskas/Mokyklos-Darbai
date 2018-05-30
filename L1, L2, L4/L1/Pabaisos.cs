using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Pabaisos
    {
        const int max = 100;
        public string miskas { get; set; }
        Pabaisa[] pb;
        public int n { get; set; }

        public Pabaisos()
        {
            n = 0;
            pb = new Pabaisa[max];
        }

        public Pabaisa Imti(int i)
        {
            return pb[i];
        }

        public void Deti(Pabaisa p)
        {
            pb[n++] = p;
        }

        public void swap(int xp, int yp)
        {
            Pabaisa temp = pb[xp];
            pb[xp] = pb[yp];
            pb[yp] = temp;
        }

        public void Rikiuoti()
        {
            int i, j;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (pb[j].ragai < pb[j + 1].ragai)
                    {
                        swap(j, j + 1);
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }

        public void Pasalinti(int indx)
        {
            n = n - 1;
            for (int i = indx; i < n; i++)
            {
                pb[i].pavadinimas = pb[i + 1].pavadinimas;
                pb[i].ragai = pb[i + 1].ragai;
                pb[i].uodegos = pb[i + 1].uodegos;
            }
        }
    }
}
