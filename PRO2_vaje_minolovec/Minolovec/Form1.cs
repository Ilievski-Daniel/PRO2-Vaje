using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minolovec
{
    class MojGumb : Button
    {
        private bool jeMina = false, jeOdkrita = false, jeOznacena = false;
        private int stMin = 0, x, y;

        public bool JeMina
        {
            set { jeMina = value; }
            get { return jeMina; }
        }
        public bool JeOdkrita
        {
            set { jeOdkrita = value; }
            get { return jeOdkrita; }
        }
        public bool JeOznacena
        {
            set { jeOznacena = value; }
            get { return jeOznacena; }
        }
        public int StMin
        {
            set { stMin = value; }
            get { return stMin; }
        }
        public int X
        {
            set { x = value; }
            get { return x; }
        }
        public int Y
        {
            set { y = value; }
            get { return y; }
        }
    }
    public partial class frmMinolovec : Form
    {
        MojGumb[,] gumbi = new MojGumb[10, 10];
        int SteviloMin = 10;
        public frmMinolovec()
        {
            InitializeComponent();

            for (int i = 0; i < gumbi.GetLength(0); i++)
                for (int j = 0; j < gumbi.GetLength(1); j++)
                {
                    gumbi[i, j] = new MojGumb();
                    gumbi[i, j].Parent = this;
                    //gumbi[i, j].Text = i.ToString() + j.ToString();
                    gumbi[i, j].Width = 35;
                    gumbi[i, j].Height = 35;
                    gumbi[i, j].Location = new Point(35*j+15, 35*i+15);
                    gumbi[i, j].X = i;
                    gumbi[i, j].Y = j;
                    gumbi[i, j].JeOznacena = false;
                    gumbi[i, j].MouseUp += new MouseEventHandler(this.MouseUp);
                }
            generirajMine();
        }
        void MouseUp(object obj, EventArgs ea)
        {
            MouseEventArgs me = (MouseEventArgs)ea;
            MojGumb mg = (MojGumb)obj;

            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (mg.JeMina)
                {
                    MessageBox.Show("Stopil si na mino. Konec igre!");
                }
                else
                {
                    razkrijMine(mg.X, mg.Y);
                }
            }
            else
            {
                gumbi[mg.X, mg.Y].JeOznacena = true;
                gumbi[mg.X, mg.Y].Text = "O";
                preveriZmago();
            }
        }
        void razkrijMine(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                if (gumbi[x, y].StMin > 0 || gumbi[x, y].JeOdkrita)
                {
                    gumbi[x, y].Text = gumbi[x, y].StMin.ToString();
                    return;
                }
                else
                {
                    gumbi[x, y].Text = gumbi[x, y].StMin.ToString();
                    gumbi[x, y].JeOdkrita = true;
                }
                razkrijMine(x - 1, y);
                razkrijMine(x, y - 1);
                razkrijMine(x + 1, y);
                razkrijMine(x, y + 1);
            }
            else
                return;
        }
        void generirajMine()
        {
            // celotno matriko resetirat
            for (int i = 0; i < gumbi.GetLength(0); i++)
                for (int j = 0; j < gumbi.GetLength(1); j++)
                {
                    gumbi[i, j].JeOznacena = false;
                    gumbi[i, j].JeOdkrita = false;
                    gumbi[i, j].JeMina = false;
                }
            Random r = new Random();
            for (int i = 1; i <= SteviloMin; i++)
            {
                int x = r.Next(0, 10);
                int y = r.Next(0, 10);
                if (gumbi[x, y].JeMina)
                    i--;
                else
                { gumbi[x, y].JeMina = true; } //gumbi[x, y].Text = "M"; }
            }
            // štetje min v okolici enega gumba/polja
            for (int i = 0; i < gumbi.GetLength(0); i++)
                for (int j = 0; j < gumbi.GetLength(1); j++)
                {
                    gumbi[i, j].StMin = stejMine(i, j);
                    //if (gumbi[i, j].Text!="M")
                    //    gumbi[i, j].Text = gumbi[i, j].StMin.ToString();
                }
        }
        // stejMine steje mine v okolici enega polja
        int stejMine(int i, int j)
        {
            int stevec = 0;

            for (int x = -1; x<=1; x++)
                for (int y = -1; y<=1; y++)
                {
                    if (i + x >= 0 && j + y >= 0 && i + x < 10 && j + y < 10)
                        if (gumbi[i + x, j + y].JeMina)
                            stevec++;
                }
            return stevec;
        }

        void preveriZmago()
        {
            int stevec = 0;

            foreach (MojGumb mg in gumbi)
            {
                if (mg.JeOznacena && mg.JeMina)
                    stevec++;
            }
            if (stevec == SteviloMin)
                MessageBox.Show("Zmagal si!");
        }
    }
}
