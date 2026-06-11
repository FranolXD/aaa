using System;

namespace SUper_GrA
{
    internal class SuperOgGraPlus : GraDzcs, IGra
    {
        public string NazwaTrybu
        {
            get
            {
                return "SUPER OG GRA PLUS BIGGA SLAYYY";
            }
        }

        public void Start()
        {
            WybórPoziomuSuperOgGra();
        }

        public static int IloscPrzelosowan { get; set; } = 0;
        public static int IloscProbDoPrzelosowania { get; set; }
        public static void WybórPoziomuSuperOgGra()
        {
            Funkcje.AktualnyTrybGry = "Super OG Gra Plus";
            Funkcje.proba = 0;
            NowaLiczba();
            int OdpPoz = Funkcje.PytInt(Funkcje.JakiJęzyk("DifficultyLevels"));
            switch (OdpPoz)
            {
                case 1:
                    IloscProbDoPrzelosowania = 6;
                    Funkcje.AktualnyPoziom = "Latwy";
                    Funkcje.CzasGry.Start();
                    SuperOgGra();
                    break;
                case 2:
                    IloscProbDoPrzelosowania = 7;
                    Funkcje.AktualnyPoziom = "Sredni";
                    Funkcje.CzasGry.Start();
                    SuperOgGra();
                    break;
                case 3:
                    IloscProbDoPrzelosowania = 8;
                    Funkcje.AktualnyPoziom = "Trudny";
                    Funkcje.CzasGry.Start();
                    SuperOgGra();
                    break;
                case 4:
                    IloscProbDoPrzelosowania = Funkcje.PytInt(Funkcje.JakiJęzyk("MaxFckUps"));
                    Funkcje.AktualnyPoziom = "Custom";
                    Funkcje.CzasGry.Start();
                    SuperOgGra();
                    break;
                default:
                    Console.WriteLine(Funkcje.JakiJęzyk("BadOption"));
                    WybórPoziomuSuperOgGra();
                    break;
            }
        }
        private static void NowaLiczba()
        {
            Funkcje.LiczbaPoziomu = 101;
            Funkcje.CyfraKomputera = Funkcje.GeneratorLiczby();
        }
        private static void SuperOgGra()
        {
            Funkcje.AktualnyTrybGry = "Super OG Gra Plus";

            ZwyklaGraFun.TrybZakładuWłączony = false;//trzeba zmienić bo to gówienko jedne nie zapisuje poprawnie

            if (Funkcje.proba >= IloscProbDoPrzelosowania)
            {
                Console.WriteLine(Funkcje.JakiJęzyk("Reroll"));
                NowaLiczba();
                Funkcje.proba = 0;
                IloscPrzelosowan++;
                Funkcje.Czekajka();
                SuperOgGra();
            }
            else
            {
                int CyfraGracza = Funkcje.PytInt(Funkcje.JakiJęzyk("ChooseNumber"));
                if (CyfraGracza < Funkcje.CyfraKomputera)
                {
                    Funkcje.proba++;
                    Console.WriteLine(Funkcje.ZaMało() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsOG")));
                    SuperOgGra();
                }
                else if (CyfraGracza == Funkcje.CyfraKomputera)
                {
                    new GraDzcs().Wygrana();
                }
                else if (CyfraGracza > Funkcje.CyfraKomputera)
                {
                    Funkcje.proba++;
                    Console.WriteLine(Funkcje.ZaDużo() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsOG")));
                    SuperOgGra();
                }
            }
        }
    }
}
