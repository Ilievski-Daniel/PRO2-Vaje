// 1.Naloga:

// Ustvari razred Izdelek, ki naj ima naslednje javne lastnosti: naziv, cena,
// zaloga. Naziv je tipa string, cena in zaloga pa sta celoštevilčna podatka.

// Ustvari ustrezne konstuktorje in implementiraj naslednje kontrole:
// naziv ne sme biti večji od 100 znakov;
// cena ne sme biti 0 ali manjša od 0;
// zaloga na sme biti manjša od 0.

// V glavnem programu ustvari polje velikosti 10 objektov iz tega razreda in preveri
// kateri izdelki imajo zalogo večjo od 5 (uporabi zanko foreach).

using System;

namespace Naloga1
{

    class Izdelek
    {
        private string naziv;
        private int cena;
        private int zaloga;

        public Izdelek()
        {
            naziv = "N/A";
            cena = 1000;
            zaloga = 1;
        }

        public Izdelek(string naziv, int cena, int zaloga)
        {
            this.naziv = naziv;
            this.cena = cena;
            this.zaloga = zaloga;
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                if (value.Length < 100)
                    naziv = value;
                else
                    throw new Exception("Naziv ne sme biti večji od 100 znakov!");
            }
        }

        public int Cena
        {
            get
            {
                return cena;
            }
            set
            {
                if (value > 0 )
                    cena = value;
                else
                    throw new Exception("Cena ne sme biti 0 ali manjša od 0!");
            }
        }

        public int Zaloga
        {
            get
            {
                return zaloga;
            }
            set
            {
                if (value >= 0)
                    zaloga = value;
                else
                    throw new Exception("Zaloga na sme biti manjša od 0!");
            }
        }
    }

    class Naloga1
    {
        static void Main(string[] args)
        {
            Izdelek[] poljeIzdelkov = new Izdelek[10];

            for (int i = 0; i < poljeIzdelkov.Length; i++)
            {
                Console.Write("Naziv: ");
                string naziv = Console.ReadLine();
                Console.Write("Cena: ");
                int cena = int.Parse(Console.ReadLine());
                Console.Write("Zaloga: ");
                int zaloga = int.Parse(Console.ReadLine());
                poljeIzdelkov[i] = new Izdelek(naziv, cena, zaloga);
            }

            foreach (Izdelek i in poljeIzdelkov)
            {
                if (i.Zaloga > 5 )
                    Console.WriteLine("{0} - Smo našli da ima večjo zalogo ob 5!", i.Naziv);
            }

            Console.ReadKey();
        }
    }
}
