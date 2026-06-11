using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SUper_GrA
{
    internal class Wynik//trzeba był dodać nowa clase bo przez dziedziczenie się wszystko krzaczy i błędy wysrywa
    {
        public string NazwaGracza { get; set; }
        public string TrybGry { get; set; }
        public string Poziom { get; set; }
        public bool CzyZaklad { get; set; }
        public int Proby { get; set; }
        public int CzasSekundy { get; set; }

    }
}