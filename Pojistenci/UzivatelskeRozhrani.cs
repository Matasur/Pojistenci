using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojistenci
{
    public class UzivatelskeRozhrani
    {
        private InsuredDatabase databaze = new InsuredDatabase();

        /// Metoda spuštění hlavního programu
        public void Spustit()
        {
            bool pokracovat = true;
            while (pokracovat)
            {
                /// Nabídka možností pro uživatele
                Console.WriteLine("\nVyberte akci:");
                Console.WriteLine("1. Přidat záznam");
                Console.WriteLine("2. Vyhledat záznam podle jména a příjmení");
                Console.WriteLine("3. Vypsat všechny pojištěné osoby");
                Console.WriteLine("4. Konec");

                /// Volba a ověření platnosti
                string vstup = Console.ReadLine();
                int volba;

                if (int.TryParse(vstup, out volba))
                {
                    switch (volba)
                    {
                        case 1:
                            PridejZaznam(); // Přidání nového záznamu
                            break;
                        case 2:
                            VyhledejZaznam(); // Vyhledání záznamu podle jména a příjmení
                            break;
                        case 3:
                            VypisVsechnyZaznamy(); // Výpis všech pojištěných osob
                            break;
                        case 4:
                            pokracovat = false; // Konec programu
                            break;
                        default:
                            Console.WriteLine("Neplatná volba, zkuste to znovu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Neplatná volba, zkuste to znovu.");
                }
            }
        }

        /// Metoda pro přidání nového záznamu
        private void PridejZaznam()
        {
            /// Získání a validace vstupů od uživatele
            Console.WriteLine("Zadejte jméno:");
            string jmeno = ZadejSlovo().Trim();
            Console.WriteLine("Zadejte příjmení:");
            string prijmeni = ZadejSlovo().Trim();
            Console.WriteLine("Zadejte věk:");
            string vek = ZadejCislo();
            Console.WriteLine("Zadejte telefonní číslo:");
            string telefonniCislo = ZadejCislo();

            /// Vytvoření nové pojištěné osoby a přidání do databáze
            Pojistenec osoba = new Pojistenec(jmeno, prijmeni, int.Parse(vek), telefonniCislo);
            databaze.PridejZaznam(osoba);
            Console.WriteLine("Záznam byl úspěšně přidán.");
        }

        /// Vyhledání záznamu podle jména a příjmení
        private void VyhledejZaznam()
        {
            /// Získání a validace vstupů od uživatele ořezání textu od mezer
            Console.WriteLine("Zadejte jméno:");
            string jmeno = ZadejSlovo().Trim();
            Console.WriteLine("Zadejte příjmení:");
            string prijmeni = ZadejSlovo().Trim();

            /// Vyhledání záznamu v databázi
            List<Pojistenec> vysledky = databaze.VyhledejZaznam(jmeno, prijmeni);
            if (vysledky.Count > 0)
            {
                /// Výpis nalezených záznamů
                for (int i = 0; i < vysledky.Count; i++)
                {
                    Console.WriteLine(vysledky[i]);
                }
            }
            else
            {
                Console.WriteLine("Žádné záznamy nenalezeny.");
            }
        }

        /// Výpis všech pojištěných osob
        private void VypisVsechnyZaznamy()
        {
            // Získání všech záznamů z databáze
            IList<Pojistenec> zaznamy = databaze.VypisVsechnyZaznamy();
            if (zaznamy.Count > 0)
            {
                // Výpis všech záznamů
                for (int i = 0; i < zaznamy.Count; i++)
                {
                    Console.WriteLine(zaznamy[i]);
                }
            }
            else
            {
                Console.WriteLine("Žádné záznamy nejsou k dispozici.");
            }
        }

        /// validace neplatného nebo prázdného vstupu
        private string ZadejSlovo()
        {
            string vstup = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(vstup))
            {
                Console.WriteLine("Vstup nesmí být prázdný. Zadejte prosím znovu.");
                vstup = Console.ReadLine();
            }
            return vstup;
        }

        /// ošetření čísla věku
        private string ZadejCislo()
        {
            string vstup = Console.ReadLine().Trim();
            int kontrola = int.Parse(vstup);
            if (string.IsNullOrWhiteSpace(vstup))
            {
                Console.WriteLine("Vstup není validní. Zadejte prosím znovu.");
                
            }

            else if (0 < kontrola && kontrola > 120);
            {
                Console.WriteLine("Vstup není validní. Zadejte prosím znovu.");
                vstup = Console.ReadLine();
            }
            return vstup;
        }

        /// ošetřit tel cislo
        //private string TelCislo()
        //{
        //    string vstup = Console.ReadLine().Trim();
        //    int i = vstup.Length;
            
        //    if (i == 9 || i == 14)
        //    {
        //        return vstup;
        //    }
        //    else 
        //    { 
        //    Console.WriteLine("Vstup není validní. Zadejte prosím znovu.");
        //    vstup = Console.ReadLine();
        //    }
        //}
    }
}
