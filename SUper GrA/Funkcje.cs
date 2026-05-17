using System;
using System.Diagnostics.Eventing.Reader;//podstawowe funkcje

namespace SUper_GrA
{
    internal class Funkcje
    {
        public static char Jezyk { get; set; }
        public static int LiczbaPoziomu { get; set; }
        public static int CyfraKomputera { get; set; }
        public static int proba {  get; set; }

        private static int PytInt(string Pyt)
        {//zbieranie odpowiedzi na pytanie i zmiana stringa na inta bo inaczej krzyczy że to string
            Console.WriteLine(Pyt);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return 0;
            return int.TryParse(input, out int val) ? val : 0;
        }
        private static string PytStr(string Pyt)
        {//zbieranie odpowiedzi od użytkownika
            Console.WriteLine(Pyt);
            String OdpStr = Console.ReadLine();
            return OdpStr;
        }
        private static char PytChar(string Pyt)
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
        public static void Czekajka() { PytVoid("naciśnij klawisze r3 + l3 albo enter xD\a\n"); Console.Clear(); }//czekanie plusz czyszczenie



        public static void EkranStartowy()
        {//funkcja startowa która będzie wywoływana na początku programu
            Console.WriteLine("Witaj w grze SUper GrA!\a\n\n");
            Czekajka();// śmiesznie by było gdyby faktycznie potrzeba było pada do gry xD

            Console.Clear();
        }
        public static void PytOJez()
        {
            char Jezyk = PytChar("Wybierz język młody padawanie \a \n\n Polski [ p ] \n\n English [ e ] \n\n Espaniol [ s ] \n");//wybór języka
            switch (Jezyk)
            {
                case 'p':
                    Console.WriteLine("Wybrałeś język polski\n\n");
                    Czekajka();
                    break;
                case 'e':
                    Console.WriteLine("You have chosen English language\n\n");
                    Czekajka();
                    break;
                case 's':
                    Console.WriteLine("Has elegido el idioma español\n\n");//powiedzmy że to jest hiszpański 
                    Czekajka();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nie ma takiego języka, wybierz ponownie\n\n");
                    PytOJez();
                    break;
            }
        }

        public static void Menu()
        {//funkcja menu, która będzie wywoływana po ekranie startowym
            Console.WriteLine("Menu główne \a\n\n Nowa gra [ 1 ]\a\nTabela Wynikuf xD [ 2 ]\a\n Ustawienia [ 3 ]\a\n Wyjście [ 4 ]\a\n");
            int OdpMenu = PytInt("Wybierz opcję: ");
            switch (OdpMenu)
            {
                case 1:
                    JakaGra();
                    Menu();
                    break;
                case 2:
                    Console.WriteLine("Tabela Wyników");
                    Menu();
                    break;
                case 3:
                    Console.WriteLine("Zmiana Jezyka");
                    Menu();
                    break;
                case 4:
                    Console.WriteLine("Wyjście");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nie ma takiej opcji");
                    Menu();
                    break;
            }
        }
        public static void JakaGra()
        {
            Console.Clear();
            Console.WriteLine("Wybierz wariant: ");
            int OdpJakaGra = PytInt("Gra zwykła [ 1 ] czy SUPER OG GRA PLUS BIGGA SLAYYY [ 2 ]");
            switch (OdpJakaGra)
            {
                case 1:
                    WybórPoziomu();
                    break;
                case 2:
                    WybórPoziomu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nie ma takiej opcji");
                    JakaGra();
                    break;
            }

        }
        public static void WybórPoziomu()
        {
            Console.WriteLine("Poziomy Trudnosci: \n\aLatwy [ 1 ] \n\aSredni [ 2 ] \n\aTrudny [ 3 ] \n\a Custom ?.? [ 5 ]  ");
            int OdpPoz = PytInt("Dobrze się zastanów co wybierzesz ;P\n\n");
            switch (OdpPoz)
            {
                case 1:
                    LiczbaPoziomu = 11;
                    CyfraKomputera = GeneratorLiczby();
                    ZwyklaGra();
                    break;
                case 2:
                    LiczbaPoziomu = 101;
                    CyfraKomputera = GeneratorLiczby();
                    ZwyklaGra();

                    break;
                case 3:
                    LiczbaPoziomu = 501;
                    CyfraKomputera = GeneratorLiczby(); 
                    ZwyklaGra();

                    break;
                case 4:
                    Console.WriteLine("\nZdobyto Osiągnięcie: Ciekawe jajo ?.? ");//trzeba zrobić tak aby były też osiągnięcia 
                    break;
                case 5:
                    LiczbaPoziomu = PytInt("Wybierz zakres do jakiego będziesz chciał zgadywać liczbę");

                    CyfraKomputera = GeneratorLiczby();
                    ZwyklaGra();

                    break;

                default:
                    Console.WriteLine("Nie ma takiej opcji");
                    WybórPoziomu();
                    break;
            }
        }

        public static int GeneratorLiczby()
        {
            Random LiczbaLosowana = new Random();
            return LiczbaLosowana.Next(1, LiczbaPoziomu);
        }
        public static void ZwyklaGra()
        {
            proba = 0;
            ZgadywanieCyfry();


        }
        public static void ZgadywanieCyfry()
        {
            int CyfraGracza = PytInt("Podaj Cyfre: \n ");
            if (CyfraGracza < CyfraKomputera)
            {
                proba++;
                Console.WriteLine($"Za Malo \n To jest twoja {proba} próba\n");
                ZgadywanieCyfry();
            }
            else if (CyfraGracza == CyfraKomputera)
            { // funkcja do gratulowania i zapusywania wyniku
            }
            else if (CyfraGracza > CyfraKomputera)
            {
                proba++;
                Console.WriteLine($"Za Duzo \n To jest twoja {proba} próba\n");
                ZgadywanieCyfry();
            }
        }
    }
}


// Funkcje pomocnicze do programu, żeby nie zaśmiecać głównego kodu, a także żeby można było łatwo zmieniać sposób zadawania pytań i zbierania odpowiedzi

// błędy które trzeba będzie ogarnąć:
/* // naprawione //  linijka 28 i 33 - problem z konwersją stringa na char, trzeba będzie zrobić blok na inne odpowiedzi niż te które są przewidziane, bo inaczej program będzie się crashował
  // linijka 141 dorobić mechanizm osiągnięc 
 // linijka 180 funkcja do gratulowania i zapisywania w tabeli
 
 */