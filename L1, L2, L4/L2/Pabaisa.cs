using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    class Pabaisa
    {
        public string pavadinimas { get; set; }
        public int ragai { get; set; }
        public int uodegos { get; set; }

        public Pabaisa(string pavadinimas, int ragai, int uodegos)
        {
            this.pavadinimas = pavadinimas;
            this.ragai = ragai;
            this.uodegos = uodegos;
        }
    }
}
