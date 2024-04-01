// 1. Naloga:
// Ustvari razred CD, ki hrani osnovne podatke o Cdjih (implementirane kot javne lastnosti):
// naslov, avtor

// Iz tega razreda izpelji razred CDFilm in CDGlasba.
// Izpeljani razred CDGlasba naj ima še podatek o številu skladb,
// izpeljani razred CDFilm pa še podatek o formatu filma (npr. divx, dvd, ...).

// Za vse tri razrede napišite metodo ToString(), ki bo izpisala trenutno stanje objekta.
// Ustvarite vse tri vrste konstruktorjev.
// V glavnem programu kreirajte vsaj po en objekt iz vsakega razreda.

using System;

namespace Naloga1
{

    class CD
    {
        public string naslov;
        public string avtor;
        
        public CD()
        {
            this.naslov = "N/A";
            this.avtor = "N/A";
        }
        public CD(string naslov, string avtor)
        {
            this.naslov = naslov;
            this.avtor = avtor;
        }
        public CD(CD cd)
        {
            this.naslov = cd.naslov;
            this.avtor = cd.avtor;
        }
        
        public void ToString() {
            Console.WriteLine("Naslov: {0}, in Avtor: {1}", this.naslov, this.avtor);
        }
    }

    class CDFilm : CD
    {
        public string format;

        public CDFilm() : base() {
            this.format = "N/A";
        }
        public CDFilm(string naslov, string avtor, string format) : base(naslov, avtor) {
            this.format = format;
        }
        public CDFilm(CDFilm cdf) : base((CD) cdf) {
            this.format = cdf.format;
        }

        public void ToString(){
            Console.WriteLine("Naslov: {0}, Avtor: {1}, in Format: {2}", this.naslov, this.avtor, this.format);
        }
    }

    class CDGlasba : CD {
        public int stevilo_skladb;

        public CDGlasba() : base()
        {
            this.stevilo_skladb = 0;
        }

        public CDGlasba(string naslov, string avtor, int sk) : base(naslov, avtor) {
            this.stevilo_skladb = sk;
        }

        public CDGlasba(CDGlasba cdg) : base((CD) cdg) {
            this.stevilo_skladb = cdg.stevilo_skladb;
        }
        
        public void ToString() {
            Console.WriteLine("Naslov: {0}, Avtor: {1}, in Število Skladb: {2}", this.naslov, this.avtor, this.stevilo_skladb);
        }
    }
    
    class Naloga1
    {
        static void Main(string[] args)

        {
            Console.WriteLine("===== Class CD =====");
            CD a = new CD();
            a.ToString();
            CD b = new CD("Black death", "Jack The Ripper");
            b.ToString();
            CD c = new CD(b);
            c.ToString();
            
            Console.WriteLine("===== Class CDFilm =====");
            CDFilm fa = new CDFilm();
            fa.ToString();
            CDFilm fb = new CDFilm("Godzilla","Tom Beily","DVD");
            fb.ToString();
            CDFilm fc = new CDFilm(fb);
            fc.ToString();
            
            Console.WriteLine("===== Class CDGlasba =====");
            CDGlasba ga = new CDGlasba();
            ga.ToString();
            CDGlasba gb = new CDGlasba("Infinite","Eminem",11);
            gb.ToString();
            CDGlasba gc = new CDGlasba(gb);
            gc.ToString();
            
            Console.ReadKey();
        }
    }
}
