using System;

namespace SUper_GrA
{
    internal class ZwyklaGraFun : Funkcje, IGra

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
            int OdpPoz = PytInt(JakiJęzyk("DifficultyLevels"));
            switch (OdpPoz)
            {
                case 1:
                    AktualnyPoziom = "Latwy";
                    LiczbaPoziomu = 11;
                    CyfraKomputera = GeneratorLiczby();
                    TrybZakładu();
                    break;
                case 2:
                    AktualnyPoziom = "Sredni";
                    LiczbaPoziomu = 101;
                    CyfraKomputera = GeneratorLiczby();
                    TrybZakładu();

                    break;
                case 3:
                    AktualnyPoziom = "Trudny";
                    LiczbaPoziomu = 501;
                    CyfraKomputera = GeneratorLiczby();
                    TrybZakładu();

                    break;
                case 5:
                    Console.WriteLine(JakiJęzyk("EggAchivment"));//trzeba zrobić tak aby były też osiągnięcia 
                    break;
                case 4:
                    AktualnyPoziom = "Custom";
                    LiczbaPoziomu = PytInt(JakiJęzyk("Range"));

                    CyfraKomputera = GeneratorLiczby();
                    TrybZakładu();

                    break;

                default:
                    Console.WriteLine(JakiJęzyk("BadOption"));
                    WybórPoziomuZwyklejGry();
                    break;
            }
        }
        private static void TrybZakładu()
        {
            proba = 0;
            if (TrybZakładuWłączony == true)
            {
                Zakład = PytInt(JakiJęzyk("MaxTry"));
                CzasGry.Start();
                AktualnyTrybGry = "Normal";

                ZwykłaGraZakładu();

            }
            else
            {
                Console.WriteLine(JakiJęzyk("NormalGame"));
                CzasGry.Start();
                AktualnyTrybGry = "Normal";

                ZwyklaGra();
            }
        }
        private static void ZwyklaGra()
        {
            int CyfraGracza = PytInt(JakiJęzyk("ChooseNumber"));
            if (CyfraGracza < CyfraKomputera)
            {
                proba++;
                Console.WriteLine(ZaMało() + WstawZmienne(JakiJęzyk("BadAnsNormalNoBet")));
                ZwyklaGra();
            }
            else if (CyfraGracza == CyfraKomputera)
            {
                CzasGry.Stop();
                Console.WriteLine(WstawZmienne(JakiJęzyk("GoodAnsNormal")));
                ZapiszWynik();
                Czekajka();// funkcja do zapusywania wyniku

            }
            else if (CyfraGracza > CyfraKomputera)
            {
                proba++;
                Console.WriteLine(ZaDużo() + WstawZmienne(JakiJęzyk("BadAnsNormal")));
                ZwyklaGra();
            }
        }
        private static void ZwykłaGraZakładu()
        {

            if (proba >= Zakład)
            {
                Console.WriteLine(WstawZmienne(JakiJęzyk("LooseBet")));
                Menu();
            }
            else
            {
                int CyfraGracza = PytInt(JakiJęzyk("ChooseNumber"));
                if (CyfraGracza < CyfraKomputera)
                {
                    proba++;
                    Console.WriteLine(ZaMało() + WstawZmienne(JakiJęzyk("BadAnsNormalBet")));
                    ZwykłaGraZakładu();
                }
                else if (CyfraGracza == CyfraKomputera)
                {
                    CzasGry.Stop();
                    Console.WriteLine(WstawZmienne(JakiJęzyk("GoodAnsNormal")));
                    ZapiszWynik();
                    Czekajka(); // funkcja do zapusywania wyniku
                }
                else if (CyfraGracza > CyfraKomputera)
                {
                    proba++;
                    Console.WriteLine(ZaDużo() + WstawZmienne(JakiJęzyk("BadAnsNormalBet")));
                    ZwykłaGraZakładu();
                }
            }
        }

    }
}
