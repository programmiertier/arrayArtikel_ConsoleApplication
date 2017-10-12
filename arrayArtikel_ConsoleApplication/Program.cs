using System;
using System.Text;
using static System.Console;
using static System.ConsoleColor;

namespace arrayArtikel_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            int maxWidth = LargestWindowWidth;
            int maxHeight = LargestWindowHeight;
            int topLine = 0;
            SetWindowSize(maxWidth / 2, maxHeight / 2);
            BackgroundColor = ConsoleColor.Black;
            Clear();
            string dateString = $"Heute: {DateTime.Now.ToLongDateString()}";
            string timeString = $" {DateTime.Now.ToString("hh:mm:ss")}";
            int lengthDateTimeNow = dateString.Length;
            int lengthTimeNow = timeString.Length;
            string[,] artikel =
            new string[5, 2] {
                {"Gummibärchen","2,75"},
                {"Mineralwasser","1,65"},
                {"Kaffee","12,00"},
                {"Schoki 400gr","3,53"},
                {"Äpfel 2kg","1,99"}
            };
            SetCursorPosition(maxWidth / 2 - lengthDateTimeNow, topLine);
            ForegroundColor = ConsoleColor.Red;
            WriteLine(dateString);
            ForegroundColor = ConsoleColor.Green;
            SetCursorPosition(maxWidth / 2 - lengthDateTimeNow - 2, topLine + 1);
            WriteLine("Uhrzeit:");
            SetCursorPosition(maxWidth / 2 - lengthTimeNow, topLine + 1);
            WriteLine(timeString);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(2, 9);
            WriteLine("{0,-30}Preis", "Bezeichnung");
            for (int produkt = 0; produkt < artikel.GetLength(0); produkt++)
            {
                SetCursorPosition(2, produkt + 10);
                ForegroundColor = (ConsoleColor)(produkt + 10);
                for (int preis = 0; preis < artikel.GetLength(1); preis++)
                {
                    Write("{0,-30}", artikel[produkt, preis]);
                }
            }

            int spalte = 40;
            int zeile = 10;
            double[] position = new double[5];
            string[] anzahl = new string[5];
            ConsoleKeyInfo meinKey;
            do
            {
                SetCursorPosition(spalte, zeile);
                meinKey = ReadKey(true);
                switch (meinKey.Key.ToString())
                {
                    case "LeftArrow": spalte = (spalte <= 40) ? 40 : spalte - 1; break;
                    case "RightArrow": spalte = (spalte >= 45) ? 45 : spalte + 1; break;
                    case "UpArrow": zeile = (zeile <= 10) ? 10 : zeile - 1; break;
                    case "DownArrow": zeile = (zeile >= 14) ? 14 : zeile + 1; spalte = 40; break;
                    case "D0":   // Die Ziffertasten auf der Tastatur (nicht das nummerpad)
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9":
                        Write(meinKey.KeyChar); spalte++;
                        anzahl[zeile - 10] = meinKey.KeyChar.ToString();
                        position[zeile - 10] = Convert.ToInt32(anzahl[zeile - 10]) * Convert.ToDouble(artikel[zeile - 10, 1]);

                        break;
                    default:; break;
                }
            } while (meinKey.Key != ConsoleKey.Enter);

            spalte = 47; zeile = 10;    // neue Position für Cursor
            for(int positionierung = 0; positionierung < 5; positionierung++)
            {
                SetCursorPosition(spalte, zeile++);
                WriteLine("{0,8:C}", position[positionierung]);
            }
            ReadLine();
        }
    }
}
