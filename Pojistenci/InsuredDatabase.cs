using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojistenci
{
    public class InsuredDatabase
    {
        private IList<Pojistenec> zaznamyPojistencu = new List<Pojistenec>();

        /// Přidání nového záznamu do databáze
        public void PridejZaznam(Pojistenec osoba)
        {
            zaznamyPojistencu.Add(osoba);
        }

        /// Vyhledání záznamu podle jména a příjmení
        public List<Pojistenec> VyhledejZaznam(string jmeno, string prijmeni)
        {
            List<Pojistenec> vysledky = new List<Pojistenec>();

            /// Prohledání všech záznamů v databázi
            for (int i = 0; i < zaznamyPojistencu.Count; i++)
            {
                Pojistenec osoba = zaznamyPojistencu[i];
                /// Porovnání jména a příjmení převedené na malá písmena
                if (osoba.Jmeno.ToLower() == jmeno.ToLower() && osoba.Prijmeni.ToLower() == prijmeni.ToLower())
                {
                    vysledky.Add(osoba); // Přidání nalezeného záznamu do výsledků
                }
            }

            return vysledky;
        }

        /// Výpis všech záznamů v databázi
        public IList<Pojistenec> VypisVsechnyZaznamy()
        {
            return zaznamyPojistencu.AsReadOnly();
        }
    }
}
