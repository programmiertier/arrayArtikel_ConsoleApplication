using System;
using static System.Console;
using static System.ConsoleColor;

namespace arrayArtikel_ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            int zeile = 12;
            int spalte = 35;

            SetCursorPosition(2, 9);
            ForegroundColor = Green;
            WriteLine("Bezeichnung\tEinzelpreis\tAnzahl\tPreis\tZwischensumme\tGesamtpreis");
            string[,] artikel = new string[4, 2]
            {
                {"Produkt 1", "100.03" },
                {"Produkt 2", "200.20" },
                {"Produkt 3", "200.10" },
                {"Produkt 4", "300.10" }
            };

            SetCursorPosition(2, CursorTop + 2);
            for (int produkt = 0; produkt < artikel.GetLength(0); produkt++)
            {
                SetCursorPosition(2, CursorTop);
                for (int preis = 0; preis < artikel.GetLength(1); preis++)
                {

                    Write(artikel[produkt, preis] + "\t");
                }
                Write("\n");
            }

            SetCursorPosition(CursorLeft, CursorTop + 2);
            int zaehl = 0;
            foreach (string produkt in artikel)
            {

                Write(produkt + "\t");
                zaehl++;

                if (zaehl % 2 == 0)
                {
                    WriteLine();
                }
            }


            Write("X");

            ConsoleKeyInfo meinkey;

            do
            {
                
                meinkey = Console.ReadKey();
                switch (meinkey.Key.ToString())
                {
                    case "LeftArrow": SetCursorPosition(spalte--, zeile); break;
                    case "RightArrow": SetCursorPosition(spalte++, zeile); break;
                    case "UpArrow": SetCursorPosition(spalte, zeile--); break;
                    case "DownArrow": SetCursorPosition(spalte, zeile++); break;
                    case "D0":
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9": WriteLine(meinkey.KeyChar); zeile++;break;
                    default: break;
                }
                SetCursorPosition(spalte, zeile);
                
                // WriteLine(spalte + "," + zeile);

                // WriteLine(meinkey.Key.ToString());
            }
            while (meinkey.Key != ConsoleKey.Escape);
            ReadLine();
        }
    }
}
