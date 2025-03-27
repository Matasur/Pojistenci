namespace Pojistenci
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Vytvoření instance třídy UzivatelskeRozhrani
            UzivatelskeRozhrani rozhrani = new UzivatelskeRozhrani();

            /// Spuštění hlavního programu prostřednictvím metody Spustit
            rozhrani.Spustit();
        }
    }
}
