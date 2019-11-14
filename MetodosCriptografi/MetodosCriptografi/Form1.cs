using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosCriptografi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int obtenerInverso(int a, int m)
        {
            int c1 = 1;
            int c2 = ((m / a) * -1);
            // coeficiente de a y b respectivamente   
            int t1 = 0;
            int t2 = 1;
            // coeficientes penultima corrida
            int r = (m % a);
            // residuo, asignamos 1 como condicion de entrada 
            int c;
            int x = a;
            int y = r;
            while ((r != 0))
            {
                c = (x / y);
                // cociente
                r = (x % y);
                // residuo
                // guardamos valores temporales de los coeficientes
                // multiplicamos los coeficiente por -1*cociente de la division
                c1 = (c1 * (c * -1));
                c2 = (c2 * (c * -1));
                // sumamos la corrida anterior
                c1 = (c1 + t1);
                c2 = (c2 + t2);
                // actualizamos corrida anterior
                t1 = (((c1 - t1) / c) * -1);
                t2 = (((c2 - t2) / c) * -1);
                x = y;
                y = r;
            }
            if (t2 < 0)
            {
                t2 = t2 + m;
            }

            if ((x == 1))
            {
               // MessageBox.Show(("" + t2));
            }
            else
            {
                //MessageBox.Show("No hay inverso");
            }
            return t2;




        }
        private void button1_Click(object sender, EventArgs e)
        {
            int decimador = Convert.ToInt16(textBox1.Text);
            if (decimador==3 || decimador == 6 || decimador == 9)
            {
                MessageBox.Show("cambie el decimador");
            }
            else
            {
                int desplazamiento = Convert.ToInt16(textBox2.Text);
                textBox4.Text = "";
                string[] palabraNormal = new string[100];
                int[] numeros = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
                String[] letras = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                String[] palabracifrada = new string[100];
                //Quitamos las mayusculas
                string palabraAcifrar = textBox3.Text.ToLower();
                //Guardando la palabra en una lista para despues decodificarlar
                for (int i = 0; i < palabraAcifrar.Length; ++i)
                {   
                    palabraNormal[i] = Convert.ToString(palabraAcifrar[i]);
                }
                //CIFRADOR
                int cont = 0;
                for (int x = 0; x < 100; ++x)
                {
                    for (int y = 0; y < 27; ++y)
                    {
                        if (palabraNormal[x] == letras[y])
                        {
                            int operacion = (y * decimador) + (desplazamiento % 27);
                            if (operacion >= 26)
                            {
                                operacion = operacion % 27;
                            }
                            palabracifrada[cont] = Convert.ToString(letras[operacion]);

                            textBox4.Text = textBox4.Text + Convert.ToString(letras[operacion]);
                        }
                    }
                }

            }

            


            


        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
            int decimador = Convert.ToInt16(textBox1.Text);
            int desplazamiento = Convert.ToInt16(textBox2.Text);
            if (decimador == 3 || decimador == 6 || decimador == 9)
            {
                MessageBox.Show("Cambie el decimador");
            }
            else
            {
                textBox4.Text = "";
                string[] palabraNormal = new string[100];
                int[] numeros = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
                String[] letras = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                String[] palabracifrada = new string[100];
                int cont = 0;
                string palabraAcifrar = textBox3.Text.ToLower();
                for (int i = 0; i < palabraAcifrar.Length; ++i)
                {
                    palabraNormal[i] = Convert.ToString(palabraAcifrar[i]);
                }
                
                for (int x = 0; x < 100; ++x)
                {
                    for (int y = 0; y < 27; y++)
                    {
                        if (palabraNormal[x] == letras[y])
                        {
                            
                            int operacion = ( y - desplazamiento)*obtenerInverso(decimador,27);
                            
                            if ( operacion > 26 )
                            {
                                operacion = operacion % 27;
                            }
                            else if (operacion > -26 && operacion<0)
                            {
                                operacion = operacion + 27;
                            }
                            else if (operacion < -26)
                            {
                                operacion = 27-(Math.Abs(operacion) % 27);
                            }
                            
                     
                            palabracifrada[cont] = Convert.ToString(letras[operacion]);

                            textBox4.Text = textBox4.Text + Convert.ToString(letras[operacion]);
                        }
                    }
                }

            }





        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
