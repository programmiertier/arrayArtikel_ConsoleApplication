using System;
using static System.Console;

namespace arrayArtikel_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] artikel = new string[4, 2]
            {
                {"Produkt 1","100" },
                {"Produkt 2","102.2" },
                {"Produkt 3","105.1" },
                {"Produkt 4", "106.1" }
            };
            for(int produkt = 0; produkt < 4; produkt++)
            {
                for(int preis = 0; preis < 2; preis++)
                {
                    Write(artikel[produkt, preis] + "\t");
                }
                Write("\n");
            }
            ReadLine();
        }
    }
}
