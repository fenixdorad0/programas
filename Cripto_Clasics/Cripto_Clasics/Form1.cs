using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cripto_Clasics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_cesar_Click(object sender, EventArgs e)
        {
            Cesar C = new Cesar();
            C.ShowDialog();            
        }

        private void button_Afin_Click(object sender, EventArgs e)
        {
            Afin A = new Afin();
            A.ShowDialog();
        }

        private void button_vigenere_Click(object sender, EventArgs e)
        {
            Cifrado_Vigenere v = new Cifrado_Vigenere();
            v.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
