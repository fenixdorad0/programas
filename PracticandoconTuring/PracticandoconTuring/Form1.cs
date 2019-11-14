using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticandoconTuring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void codigoBase()
        {
            //LNG LONGITUD 
            Random rnd = new Random();
            int valorRandome;
            String cadena = "";
            int lng = Convert.ToInt16(textLong.Text);
            for (int cont1 = 1; cont1 <= lng; cont1++)
            {
                valorRandome = (rnd.Next(0, 2));
                cadena = cadena + valorRandome;
            }
            MessageBox.Show(cadena);
        }

        private void button1a_Click(object sender, EventArgs e)
        {
            try
            {
                //LNG LONGITUD 
                Random rnd = new Random();
                int valorRandome;
                String cadena = "";
                int lng = Convert.ToInt16(textLong.Text);
                for (int cont1 = 1; cont1 <= lng; cont1++)
                {

                    if (cont1 >= lng - 1)
                    {
                        cadena = cadena + "0";
                    }
                    else
                    {
                        valorRandome = (rnd.Next(0, 2));
                        cadena = cadena + valorRandome;
                    }
                }
                MessageBox.Show(cadena);
            }
            catch
            {
                MessageBox.Show("inserte numeros enteros gracias =)");
            }
            
        }

        private void button1b_Click(object sender, EventArgs e)
        {
            try
            {
                //LNG LONGITUD 
                Random rnd = new Random();
                int valorRandome;
                String cadena = "";
                int lng = Convert.ToInt16(textLong.Text);
                bool bandera = true;
                for (int cont1 = 1; cont1 <= lng; cont1++)
                {
                    if (bandera == true)
                    {
                        cadena = cadena + "1";
                        bandera = false;
                    }
                    else
                    {
                        cadena = cadena + "0";
                        bandera = true;
                    }
                }
                MessageBox.Show(cadena);
            }
            catch
            {
                MessageBox.Show("inserte numeros enteros gracias =)");
            }
            
        }

        private void button1c_Click(object sender, EventArgs e)
        {
            try {
                //LNG LONGITUD 
                Random rnd = new Random();
                int valorRandome;
                String cadena = "";
                int lng = Convert.ToInt16(textLong.Text);
                int cantidadEvaluar = lng / 5;
                int contdeceros = 0;
                int contdeunos = 0; // o a 1 hmm its joke
                for (int cont1 = 1; cont1 <= lng; cont1++)
                {
                    valorRandome = (rnd.Next(0, 2));
                    if (valorRandome == 0)
                    {
                        contdeceros = contdeceros + 1;
                    }
                    else
                    {
                        contdeunos = contdeunos + 1;
                    }

                    if (contdeceros == 2)
                    {
                        cadena = cadena + "1";
                    }
                    else if (contdeunos == 3)
                    {
                        cadena = cadena + "0";
                    }
                    else
                    {
                        cadena = cadena + valorRandome;
                    }
                    if (contdeunos + contdeceros == 5)
                    {
                        contdeunos = 0;
                        contdeceros = 0;
                    }

                }
                MessageBox.Show(cadena);

            }
            catch
            {
                MessageBox.Show("inserte numeros enteros gracias =)");
            }
            
        }
    }
}
