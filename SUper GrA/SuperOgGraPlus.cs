using System;

namespace SUper_GrA
{
    internal class SuperOgGraPlus : Funkcje, IGra
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
            AktualnyTrybGry = "Super OG Gra Plus";
            proba = 0;
            NowaLiczba();
            int OdpPoz = PytInt(JakiJęzyk("DifficultyLevels"));
            switch (OdpPoz)
            {
                case 1:
                    IloscProbDoPrzelosowania = 8;
                    AktualnyPoziom = "Latwy";
                    CzasGry.Start();
                    SuperOgGra();
                    break;
                case 2:
                    IloscProbDoPrzelosowania = 7;
                    AktualnyPoziom = "Sredni";
                    CzasGry.Start();
                    SuperOgGra();
                    break;
                case 3:
                    IloscProbDoPrzelosowania = 6;
                    AktualnyPoziom = "Trudny";
                    CzasGry.Start();
                    SuperOgGra();
                    break;
                case 4:
                    IloscProbDoPrzelosowania = PytInt(JakiJęzyk("MaxFckUps"));
                    AktualnyPoziom = "Custom";
                    CzasGry.Start();
                    SuperOgGra();
                    break;
                default:
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    WybórPoziomuSuperOgGra();
                    break;
            }
        }
        private static void NowaLiczba()
        {
            LiczbaPoziomu = 101;
            CyfraKomputera = GeneratorLiczby();
        }
        private static void SuperOgGra()
        {
            AktualnyTrybGry = "Super OG Gra Plus";

            ZwyklaGraFun.TrybZakładuWłączony = false;//trzeba zmienić bo to gówienko jedne nie zapisuje poprawnie

            if (proba >= IloscProbDoPrzelosowania)
            {
                Console.WriteLine(JakiJęzyk("Reroll"));
                NowaLiczba();
                proba = 0;
                IloscPrzelosowan++;
                Czekajka();
                SuperOgGra();
            }
            else
            {
                int CyfraGracza = PytInt(JakiJęzyk("ChooseNumber"));
                if (CyfraGracza < CyfraKomputera)
                {
                    proba++;
                    Console.WriteLine(ZaMało() + WstawZmienne(JakiJęzyk("BadAnsOG")));
                    SuperOgGra();
                }
                else if (CyfraGracza == CyfraKomputera)
                {
                    CzasGry.Stop();
                    Console.WriteLine(WstawZmienne(JakiJęzyk("GoodAnsOG")));
                    ZapiszWynik();
                    Czekajka();// funkcja do zapusywania wyniku
                }
                else if (CyfraGracza > CyfraKomputera)
                {
                    proba++;
                    Console.WriteLine(ZaDużo() + WstawZmienne(JakiJęzyk("BadAnsOG")));
                    SuperOgGra();
                }
            }
        }
    }
}
