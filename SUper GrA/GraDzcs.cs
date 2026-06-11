
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SUper_GrA
{
    internal class GraDzcs
    {
        public void Wygrana() {
            Funkcje.CzasGry.Stop();
            Console.WriteLine(Funkcje.WstawZmienne(Funkcje.JakiJęzyk("GoodAnsNormal")));
            Funkcje.ZapiszWynik();
            Funkcje.Czekajka(); // funkcja do zapusywania wyniku
            Funkcje.Menu();
        }
    }
}