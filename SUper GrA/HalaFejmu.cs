using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SUper_GrA
{
    internal class HalaFejmu : Funkcje
    {
        public static int JakaHala { get; set; }
        public static int ZakładHala { get; set; }

        public static void WybórHali()
        {
            Console.Clear();
            JakaHala = PytInt(JakiJęzyk("WitchHall"));
            switch (JakaHala)
            {
                case 1:
                    
                    CzyZakładHala();
                    //pokaże topke zwykłej gry z czasem i nazwami graczy
                    break;
                case 2:
                    JakiPoziomHali();
                    //pokaze topke SUPER OG GRA PLUS BIGGA SLAYYY z czasem i nazwami graczy
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    WybórHali();
                    break;
            }
        }
        public static void JakiPoziomHali()
        {
            Console.Clear();

            int odpPoz = PytInt(JakiJęzyk("DifficultyLevels"));

            string poziom;

            switch (odpPoz)
            {
                case 1:
                    poziom = "Latwy";
                    break;

                case 2:
                    poziom = "Sredni";
                    break;

                case 3:
                    poziom = "Trudny";
                    break;

                case 4:
                    poziom = "Custom";
                    break;

                default:
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    JakiPoziomHali();
                    return;
            }

            if (JakaHala == 1)
            {
                bool czyZaklad = ZakładHala == 1;
                PokazTopke("Normal", czyZaklad, poziom);
            }
            else if (JakaHala == 2)
            {
                PokazTopke("Super OG Gra Plus", false, poziom);
            }
        }
        public static List<Wynik> WczytajWyniki()
        {
            string plik = "HalaFejmu.json";

            if (!File.Exists(plik))
            {
                return new List<Wynik>();
            }

            string json = File.ReadAllText(plik);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Wynik>();
            }

            try
            {
                return JsonSerializer.Deserialize<List<Wynik>>(json)
                       ?? new List<Wynik>();
            }
            catch
            {
                return new List<Wynik>();
            }
        }
        public static void PokazTopke(string trybGry, bool czyZaklad, string poziom)
        {
            List<Wynik> wyniki = WczytajWyniki();

            List<Wynik> topka = wyniki
                .Where(w =>
                    w.TrybGry == trybGry &&
                    w.CzyZaklad == czyZaklad &&
                    w.Poziom == poziom)
                .OrderBy(w => w.Proby)
                .ThenBy(w => w.CzasSekundy)
                .Take(5)
                .ToList();

            Console.Clear();

            Console.WriteLine($"=== TOP 5: {trybGry} | {poziom} | Zakład: {czyZaklad} ===\n");

            if (topka.Count == 0)
            {
                Console.WriteLine("Brak wyników dla tej kategorii.");
                Czekajka();
                return;
            }

            int miejsce = 1;

            foreach (Wynik wynik in topka)
            {
                Console.WriteLine(
                    $"{miejsce}. {wynik.NazwaGracza} | Próby: {wynik.Proby} | Czas: {wynik.CzasSekundy}s"
                );

                miejsce++;
            }

            Czekajka();
        }
        public static void CzyZakładHala()
        {
            Console.Clear();
            ZakładHala = PytInt(JakiJęzyk("HallOfFameBetOrNormal"));
            switch (ZakładHala)
            {
                case 1:
                    
                    JakiPoziomHali();
                    break;
                case 2:
                    

                    JakiPoziomHali();
                    break;
                default:
                    Console.WriteLine(JakiJęzyk("BadOption"));
                     CzyZakładHala();break;
            }
        }
    }
}