using System;

namespace SUper_GrA
{
    internal class ZwyklaGraFun : GraDzcs, IGra

    {
        public string NazwaTrybu
        {
            get
            {
                return "Zwykła gra";
            }
        }

        public void Start()
        {
            WybórPoziomuZwyklejGry();
        }
        public static bool TrybZakładuWłączony { get; set; } = true;
        public static int Zakład { get; set; }
        public static void WybórPoziomuZwyklejGry()
        {
            Console.Clear();
            int OdpPoz = Funkcje.PytInt(Funkcje.JakiJęzyk("DifficultyLevels"));
            switch (OdpPoz)
            {
                case 1:
                    Funkcje.AktualnyPoziom = "Latwy";
                    Funkcje.LiczbaPoziomu = 11;
                    Funkcje.CyfraKomputera = Funkcje.GeneratorLiczby();
                    TrybZakładu();
                    break;
                case 2:
                    Funkcje.AktualnyPoziom = "Sredni";
                    Funkcje.LiczbaPoziomu = 101;
                    Funkcje.CyfraKomputera = Funkcje.GeneratorLiczby();
                    TrybZakładu();

                    break;
                case 3:
                    Funkcje.AktualnyPoziom = "Trudny";
                    Funkcje.LiczbaPoziomu = 501;
                    Funkcje.CyfraKomputera = Funkcje.GeneratorLiczby();
                    TrybZakładu();

                    break;
                case 5:
                    Console.WriteLine(Funkcje.JakiJęzyk("EggAchivment"));
                    //trzeba zrobić tak aby były też osiągnięcia// jednak nie Jbć pomiarowe
                    break;
                case 4:
                    Funkcje.AktualnyPoziom = "Custom";
                    Funkcje.LiczbaPoziomu = Funkcje.PytInt(Funkcje.JakiJęzyk("Range"));

                    Funkcje.CyfraKomputera = Funkcje.GeneratorLiczby();
                    TrybZakładu();

                    break;

                default:
                    Console.WriteLine(Funkcje.JakiJęzyk("BadOption"));
                    WybórPoziomuZwyklejGry();
                    break;
            }
        }
        private static void TrybZakładu()
        {
            Funkcje.proba = 0;
            if (TrybZakładuWłączony == true)
            {
                Zakład = Funkcje.PytInt(Funkcje.JakiJęzyk("MaxTry"));
                Funkcje.CzasGry.Start();
                Funkcje.AktualnyTrybGry = "Normal";

                ZwykłaGraZakładu();

            }
            else
            {
                Console.WriteLine(Funkcje.JakiJęzyk("NormalGame"));
                Funkcje.CzasGry.Start();
                Funkcje.AktualnyTrybGry = "Normal";

                ZwyklaGra();
            }
        }
        private static void ZwyklaGra()
        {
            int CyfraGracza = Funkcje.PytInt(Funkcje.JakiJęzyk("ChooseNumber"));
            if (CyfraGracza < Funkcje.CyfraKomputera)
            {
                Funkcje.proba++;
                Console.WriteLine(Funkcje.ZaMało() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsNormalNoBet")));
                ZwyklaGra();
            }
            else if (CyfraGracza == Funkcje.CyfraKomputera)
            {
                Funkcje.CzasGry.Stop();
                Console.WriteLine(Funkcje.WstawZmienne(Funkcje.JakiJęzyk("GoodAnsNormal")));
                Funkcje.ZapiszWynik();
                Funkcje.Czekajka();// funkcja do zapusywania wyniku

            }
            else if (CyfraGracza > Funkcje.CyfraKomputera)
            {
                Funkcje.proba++;
                Console.WriteLine(Funkcje.ZaDużo() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsNormal")));
                ZwyklaGra();
            }
        }
        private static void ZwykłaGraZakładu()
        {

            if (Funkcje.proba >= Zakład)
            {
                Console.WriteLine(Funkcje.WstawZmienne(Funkcje.JakiJęzyk("LooseBet")));
                Funkcje.Menu();
            }
            else
            {
                int CyfraGracza = Funkcje.PytInt(Funkcje.JakiJęzyk("ChooseNumber"));
                if (CyfraGracza < Funkcje.CyfraKomputera)
                {
                    Funkcje.proba++;
                    Console.WriteLine(Funkcje.ZaMało() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsNormalBet")));
                    ZwykłaGraZakładu();
                }
                else if (CyfraGracza == Funkcje.CyfraKomputera)
                {
                    new GraDzcs().Wygrana();
                }
                else if (CyfraGracza > Funkcje.CyfraKomputera)
                {
                    Funkcje.proba++;
                    Console.WriteLine(Funkcje.ZaDużo() + Funkcje.WstawZmienne(Funkcje.JakiJęzyk("BadAnsNormalBet")));
                    ZwykłaGraZakładu();
                }
            }
        }

    }
}
