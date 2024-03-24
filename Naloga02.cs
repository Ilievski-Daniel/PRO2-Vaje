// 2.Naloga:
// Ustvari razred Knjiga, ki ima naslednje javne lastnosti: naslov, avtor in leto izdaje.
// Vse tri lastnosti naj bodo tipa string.
// Ustvari vse vrste konstruktorjev.

// Napiši metodo ToString(), ki je primerna za izpis stanja objekta.

// V glavnem programu ustvari polje 10 objektov tipa Knjiga, v zanki preberi iz konzole podatke
// o 10 knjigah ter jih shrani v elemente polja.

// Z uporabo zanke foreach najdi in izpiši najstarejšo knjigo (glede na leto izdaje).

using System;

namespace Naloga1
{

    class Knjiga
    {
        public string naslov;
        public string avtor;
        public string leto;

        public Knjiga()
        {
            naslov = "N/A";
            avtor = "N/A";
            leto = "2000";
        }

        public Knjiga(string naslov, string avtor, string leto)
        {
            this.naslov = naslov;
            this.avtor = avtor;
            this.leto = leto;
        }

        public Knjiga(Knjiga k)
        {
            this.naslov = k.naslov;
            this.avtor = k.avtor;
            this.leto = k.leto;
        }

        public void Izpisi()
        {
            Console.WriteLine("Naslov: {0} Avtor: {1} Leto: {2}", naslov, avtor, leto);
        }
    }

    class Naloga2
    {
        static void Main(string[] args)
        {
            Knjiga[] poljeKnjigah = new Knjiga[2];

            for (int i = 0; i < poljeKnjigah.Length; i++)
            {
                Console.Write("Naslov: ");
                string naslov = Console.ReadLine();
                Console.Write("Avtor: ");
                string avtor = Console.ReadLine();
                Console.Write("Leto: ");
                string leto = Console.ReadLine();
                poljeKnjigah[i] = new Knjiga(naslov, avtor, leto);
            }

            Knjiga najstarejsa = poljeKnjigah[0];
            foreach (Knjiga k in poljeKnjigah)
            {
                if (int.Parse(k.leto) > int.Parse(najstarejsa.leto))
                    najstarejsa = k;
            }

            Console.WriteLine("Najstarejša knjiga je:");
            najstarejsa.Izpisi();
            Console.ReadKey();
        }
    }
}