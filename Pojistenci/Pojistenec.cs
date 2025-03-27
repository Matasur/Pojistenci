using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojistenci
{
    public class Pojistenec
    {
        /// Vlastnosti pro jméno, příjmení, věk a telefon
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public int Vek { get; private set; }
        public string TelefonniCislo { get; private set; }

        /// Pro inicializaci vlastností pojištěné osoby
        public Pojistenec(string jmeno, string prijmeni, int vek, string telefonniCislo)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefonniCislo = telefonniCislo;
        }

        /// Výpis informací o osobě
        public override string ToString()
        {
            return $"{Jmeno} {Prijmeni}, Věk: {Vek}, Tel: {TelefonniCislo}";
        }
    }
}
