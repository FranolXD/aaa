using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using static SUper_GrA.HalaFejmu;
using static SUper_GrA.SuperOgGraPlus;
using static SUper_GrA.ZwyklaGraFun;

namespace SUper_GrA
{
    internal class Funkcje
    {
     
        public static string jsonJPolski = File.ReadAllText("JPolski.json");
        public static string jsonJAngielski = File.ReadAllText("JAngielski.json");
        public static string jsonJHiszpański = File.ReadAllText("JHiszpański.json");
        public static Jexyczek JPolski = JsonSerializer.Deserialize<Jexyczek>(jsonJPolski) ?? new Jexyczek();
        public static Jexyczek JAngielski = JsonSerializer.Deserialize<Jexyczek>(jsonJAngielski) ?? new Jexyczek();
        public static Jexyczek JHiszpański = JsonSerializer.Deserialize<Jexyczek>(jsonJHiszpański) ?? new Jexyczek();
        public static string jsonHalaFejmu = File.ReadAllText("HalaFejmu.json");

        public static string WstawZmienne(string tekst)
        {
            return tekst

                // podstawowe
                .Replace("{proba}", proba.ToString())

                // czas gry
                .Replace(
                    "{CzasGry.Elapsed.Seconds}",
                    CzasGry.Elapsed.Seconds.ToString()
                )

                // zakład
                .Replace(
                    "{Zakład - proba}",
                    (Zakład - proba).ToString()
                )

                // SUPER OG GRA PLUS
                .Replace(
                    "{IloscProbDoPrzelosowania - proba}",
                    (IloscProbDoPrzelosowania - proba).ToString()
                )

                .Replace(
                    "{IloscPrzelosowan}",
                    IloscPrzelosowan.ToString()
                )

                .Replace(
                    "{proba + IloscPrzelosowan * IloscProbDoPrzelosowania}",
                    (
                        proba +
                        IloscPrzelosowan *
                        IloscProbDoPrzelosowania
                    ).ToString()
                );
        }

        public static string Jezyk { get; set; } = "JPolski";
        public static string NazwaGracza { get; set; }
        public static int LiczbaPoziomu { get; set; }
        public static int CyfraKomputera { get; set; }
        public static string Osiągnięcia { get; set; }
        public static int proba { get; set; }
        public static Stopwatch CzasGry = Stopwatch.StartNew();
        public static string AktualnyTrybGry { get; set; }
        public static string AktualnyPoziom { get; set; }

        

        public static int PytInt(string Pyt)
        {//zbieranie odpowiedzi na pytanie i zmiana stringa na inta bo inaczej krzyczy że to string
            Console.WriteLine(Pyt);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return 0;
            return int.TryParse(input, out int val) ? val : 0;
        }
        public static string PytStr(string Pyt)
        {//zbieranie odpowiedzi od użytkownika
            Console.WriteLine(Pyt);
            String OdpStr = Console.ReadLine();
            return OdpStr;
        }
        public static char PytChar(string Pyt)
        {//zbieranie odpowiedzi od użytkownika i zmiana stringa na char bo ma problem znowu
            Console.WriteLine(Pyt);
            string input = Console.ReadLine();
            char OdpChar = string.IsNullOrEmpty(input) ? '\0' : input[0];
            return OdpChar;
        }
        public static void PytVoid(string Pyt)
        {//można użyć do pytań które cpp dostałyby getchar na końcu
            Console.WriteLine(Pyt);
            Console.ReadLine();
        }
        public static void Czekajka()
        {
            PytVoid(JakiJęzyk("Wait"));
            Console.Clear();
        }//czekanie plusz czyszczenie



        public static void EkranStartowy()
        {//funkcja startowa która będzie wywoływana na początku programu
            Console.WriteLine(JakiJęzyk("Welcome"));
            Czekajka();// śmiesznie by było gdyby faktycznie potrzeba było pada do gry xD

            Console.Clear();
        }
        public static void PytOJez()
        {
            char OdpJez = PytChar("Wybierz język młody padawanie \a \n\n Polski [ p ] \n\n English [ e ] \n\n Espaniol [ s ] \n");//wybór języka
            switch (OdpJez)
            {
                case 'p':
                    Console.WriteLine("Wybrałeś język polski\n\n");
                    Jezyk = "JPolski";
                    Czekajka();
                    break;
                case 'e':
                    Console.WriteLine("You have chosen English language\n\n");
                    Jezyk = "JAngielski";
                    Czekajka();
                    break;
                case 's':
                    Console.WriteLine("Has elegido el idioma español\n\n");//powiedzmy że to jest hiszpański 
                    Jezyk = "JHiszpański";
                    Czekajka();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    PytOJez();
                    break;
            }
        }
        public static void PytONazwe()
        {
            string fileGracze = "NazwaGracza.json";

            NazwaGracza = PytStr(JakiJęzyk("AskName"));

            List<Gracze> gracze = new List<Gracze>();

            if (File.Exists(fileGracze))
            {
                string jsonGracze = File.ReadAllText(fileGracze);

                if (!string.IsNullOrWhiteSpace(jsonGracze))
                {
                    try
                    {
                        gracze = JsonSerializer.Deserialize<List<Gracze>>(jsonGracze)
                                 ?? new List<Gracze>();
                    }
                    catch
                    {
                        gracze = new List<Gracze>();
                    }
                }
            }

            bool exists = gracze.Any(p =>
                p.Nazwa != null &&
                p.Nazwa.Equals(NazwaGracza, StringComparison.OrdinalIgnoreCase));// tu jest 200iq bo to będzie ignorować czy to duża czy mala litera

            if (exists)
            {
                Console.WriteLine($"Witaj ponownie {NazwaGracza}!");
            }
            else
            {
                Console.WriteLine($"Witaj {NazwaGracza}!");

                gracze.Add(new Gracze//tutaj dodaje gracza do jsona 
                {
                    Nazwa = NazwaGracza
                });

                string json = JsonSerializer.Serialize(gracze, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(fileGracze, json);// a to zapisuje jsona z graczem do pliku
            }

            Czekajka();
        }
        public static void Menu()
        {
            Console.Clear();
            //funkcja menu, która będzie wywoływana po ekranie startowym
            int OdpMenu = PytInt(JakiJęzyk("MainMenu"));
            switch (OdpMenu)
            {
                case 1:
                    JakaGra();
                    Menu();
                    break;
                case 2:
                    WybórHali();
                    Menu();
                    break;
                case 3:
                    Ustawienia();
                    Menu();
                    break;
                case 4:
                    Console.WriteLine(JakiJęzyk("Exit"));
                    Environment.Exit(0);
                    break;
              
                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    Menu();
                    break;
            }
        }
        public static void JakaGra()
        {
            IGra wybranaGra;

            Console.Clear();
            Console.WriteLine(JakiJęzyk("ChooseVariant"));
            int OdpJakaGra = PytInt(JakiJęzyk("ChooseGame"));
            switch (OdpJakaGra)
            {
                case 1:
                    wybranaGra = new ZwyklaGraFun();
                    wybranaGra.Start();
                    break;
                case 2:
                    wybranaGra = new SuperOgGraPlus();
                    wybranaGra.Start();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    JakaGra();
                    break;
               
            }
        }


        public static int GeneratorLiczby()
        {
            Random LiczbaLosowana = new Random();
            return LiczbaLosowana.Next(1, LiczbaPoziomu);
        }
        public static void Ustawienia()
        {
            Console.Clear();
            int OdpUstawienia = PytInt(JakiJęzyk("SetQuestion"));
            switch (OdpUstawienia)
            {
                case 1:
                    if (TrybZakładuWłączony == true)
                    {
                        Console.WriteLine(JakiJęzyk("BetOn"));
                    }
                    else
                    {
                        Console.WriteLine(JakiJęzyk("BetOf"));
                    }
                    ZmianaZakładu();
                    break;
                case 2:
                    Console.Clear();
                    PytOJez();
                    break;
                case 3:
                    CzyszczenieHaliFejmu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    Ustawienia();
                    break;
            }


        }
        public static void ZmianaZakładu()
        {
            char OdpZakl = PytChar(JakiJęzyk("ChangeBet"));
            switch (OdpZakl)
            {
                case 't':
                    TrybZakładuWłączony = !TrybZakładuWłączony;
                    Console.WriteLine(JakiJęzyk("BetChanged"));
                    break;
                case 'n':
                    Console.WriteLine(JakiJęzyk("BetUnchanged"));
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    ZmianaZakładu();
                    break;
            }
        }
        public static string JakiJęzyk(string Komenda)
        {
            Jexyczek aktualny;

            switch (Jezyk)
            {
                case "JPolski":
                    aktualny = JPolski;
                    break;

                case "JAngielski":
                    aktualny = JAngielski;
                    break;

                case "JHiszpański":
                    aktualny = JHiszpański;
                    break;

                default:
                    return JakiJęzyk("BadOption");
            }

            var property = aktualny.GetType().GetProperty(Komenda);

            if (property == null)
            {
                return $"BRAK TEKSTU W KLASIE Jexyczek: {Komenda}";
            }

            var value = property.GetValue(aktualny);

            if (value == null)
            {
                return $"BRAK TEKSTU W JSON: {Komenda}";
            }

            return value.ToString();
        }
        public static List<string> JakaLista(string nazwaListy)
        {
            switch (Jezyk)
            {
                case "JPolski":
                    return (List<string>)JPolski.GetType().GetProperty(nazwaListy).GetValue(JPolski);

                case "JAngielski":
                    return (List<string>)JAngielski.GetType().GetProperty(nazwaListy).GetValue(JAngielski);

                case "JHiszpański":
                    return (List<string>)JHiszpański.GetType().GetProperty(nazwaListy).GetValue(JHiszpański);

                default:
                    return new List<string>();
            }
        }



        public static int GeneratorLiczbyOpd()
        {
            Random NrOdp = new Random();
            return NrOdp.Next(0, 5);
        }

        public static string ZaDużo()
        {
            int ktoraOdp = GeneratorLiczbyOpd();

            List<string> odpowiedzi = JakaLista("TooMuch");

            return odpowiedzi[ktoraOdp];
        }

        public static string ZaMało()
        {
            int ktoraOdp = GeneratorLiczbyOpd();

            List<string> odpowiedzi = JakaLista("TooLittle");

            return odpowiedzi[ktoraOdp];
        }
        public static void ZapisGracza(string nazwaGracza)
        {
            string jsonNazwaGracza = JsonSerializer.Serialize(nazwaGracza);
            File.WriteAllText("NazwaGracza.json", jsonNazwaGracza);
        }
        public static void ZapisOsiągnięcia(string osiągnięcia)
        {
            string jsonOsiągnięcia = JsonSerializer.Serialize(osiągnięcia);
            File.WriteAllText("Osiągnięcia.json", jsonOsiągnięcia);

        }
        public static void ZapiszWynik()
        {
            string plik = "HalaFejmu.json";

            List<Wynik> wyniki = new List<Wynik>();

            if (File.Exists(plik))
            {
                string json = File.ReadAllText(plik);

                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        wyniki = JsonSerializer.Deserialize<List<Wynik>>(json)
                                 ?? new List<Wynik>();
                    }
                    catch
                    {
                        wyniki = new List<Wynik>();
                    }
                }
            }

            Wynik nowyWynik = new Wynik
            {
                NazwaGracza = NazwaGracza,
                TrybGry = AktualnyTrybGry,
                Poziom = AktualnyPoziom,
                CzyZaklad = TrybZakładuWłączony,
                Proby = proba,
                CzasSekundy = CzasGry.Elapsed.Seconds
            };

            wyniki.Add(nowyWynik);

            string nowyJson = JsonSerializer.Serialize(
                wyniki,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(plik, nowyJson);
        }
        private static void CzyszczenieHaliFejmu()
        {
            string SafePass = PytStr(JakiJęzyk("ClrHallQue"));
            if (SafePass == "KONDI_CWL")
            {
                string pustyJson = "[]";

                File.WriteAllText("HalaFejmu.json", pustyJson);

                Console.WriteLine(JakiJęzyk("ClrhallGood"));

                Czekajka();

            }
            else
            {
                Console.WriteLine(JakiJęzyk("ClrHallBad"));
                Environment.Exit(0);
                return;
            }
        }
        }
    }


// Funkcje pomocnicze do programu, żeby nie zaśmiecać głównego kodu, a także żeby można było łatwo zmieniać sposób zadawania pytań i zbierania odpowiedzi

// błędy które trzeba będzie ogarnąć:
/* brak błędów, bo wszystko jest idealne, a nawet jeśli coś jest nie tak, to wina urzytkownika, który nie umie grać w grę polegającą na zgadywaniu liczb, a nie na wpisywaniu tekstu, ale i tak będzie to jego wina, bo przecież wszystko jest idealne
 */