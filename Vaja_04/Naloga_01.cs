using System;

namespace PRO2_Vaja04b
{
    public partial class Form1 : Form
    {
        int rezultat;
        int st1;
        int st2;
        string operacija;
        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ((Button)sender).Text;
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            rezultat = 0;
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            st1 = int.Parse(textBox1.Text);
            operacija = ((Button)sender).Text;
            textBox1.Text = "";
            MessageBox.Show(st1.ToString());
        }

        private void buttonequal_Click(object sender, EventArgs e)
        {
            st2 = int.Parse(textBox1.Text);
            switch (operacija)
            {
                case "+": rezultat = st1 + st2; break;
                case "/": rezultat = st1 / st2; break;
                case "-": rezultat = st1 - st2; break;
                case "*": rezultat = st1 * st2; break;
            }
            textBox1.Text = rezultat.ToString();
        }

        private void buttonfactor_Click(object sender, EventArgs e)
        {
            int i, f = 1;

            if (int.Parse(textBox1.Text) == 0)
                textBox1.Text = "1";

            for (i = 1; i <= int.Parse(textBox1.Text); i++)
            {
                f = f * i;
            }
            rezultat = f;
            textBox1.Text = rezultat.ToString();
        }
    }
}
