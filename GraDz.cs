using System;

internal public class GraDz
{
	public void Wygrana()
	{
        CzasGry.Stop();
        Console.WriteLine(WstawZmienne(JakiJęzyk("GoodAnsNormal")));
        ZapiszWynik();

        Czekajka(); // funkcja do zapusywania wyniku
        Menu();
    }
}
