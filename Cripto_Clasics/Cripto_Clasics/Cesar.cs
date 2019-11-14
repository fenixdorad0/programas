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
    public partial class Cesar : Form
    {
        public Cesar()
        {
            InitializeComponent();
        }

        private void button_Cifrar_Click(object sender, EventArgs e)
        {
            textBox_texto_cifrado.Text = "";
            try
            {
                string[] alfabeto = new string[27] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                Array texto = textBox_texto_claro.Text.ToArray();
                //texto = Console.ReadLine().ToArray();
                int desplazamiento = Convert.ToInt16(textBox_Desplazamiento.Text);
                for (int y = 0; y < texto.Length; y++)
                {
                    bool vandera = true;
                    int z = 0;
                    while (vandera)
                    {

                        if (z < 27)
                        {
                            if (Convert.ToString(texto.GetValue(y)) == alfabeto[z])
                            {
                                Console.WriteLine("Cifrado " + texto.GetValue(y) + " " + alfabeto[z] + "pos= " + y);
                                object cifra = Convert.ToChar(alfabeto[((z + desplazamiento) % 27)]);
                                //Console.WriteLine(cesar[y]);
                                texto.SetValue(cifra, y);
                                Console.WriteLine(texto.GetValue(y));
                                vandera = false;
                            }
                            else
                            {
                                z++;
                            }
                        }
                    }
                }
                //imprmiendo cifrado//
                Console.WriteLine("texto cifrado");
                for (int y = 0; y < texto.Length; y++)
                {
                    textBox_texto_cifrado.Text += texto.GetValue(y).ToString();
                    //Console.Write(texto.GetValue(y) + " ");
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Convert.ToString(Error));
            }
        }

        private void button_Descifrar_Click(object sender, EventArgs e)
        {
            textBox_texto_cifrado.Text = "";    
            try
            {
                string[] alfabeto = new string[27] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                Array texto = textBox_texto_claro.Text.ToArray();
                //texto = Console.ReadLine().ToArray();
                int desplazamiento = Convert.ToInt16(textBox_Desplazamiento.Text);
                for (int y = 0; y < texto.Length; y++)
                {
                    bool vandera = true;
                    int z = 0;
                    while (vandera)
                    {

                        if (z < 27)
                        {                            
                            if (Convert.ToString(texto.GetValue(y)) == alfabeto[z])
                            {
                                Console.WriteLine("Descifrado " + texto.GetValue(y) + " " + alfabeto[z] + "pos= " + y);
                                int descifrado = (z - desplazamiento);
                                if (descifrado < 0)
                                {
                                    //descifrado *= -1;
                                    descifrado = descifrado + 27; //inverso aditivo
                                    object cifra = Convert.ToChar(alfabeto[(descifrado % 27)]);
                                    texto.SetValue(cifra, y);
                                }
                                else
                                {
                                    object cifra = Convert.ToChar(alfabeto[descifrado % 27]);
                                    texto.SetValue(cifra, y);
                                }                                
                                //Console.WriteLine(cesar[y]);                                
                                Console.WriteLine(texto.GetValue(y));
                                vandera = false;
                            }
                            else
                            {
                                z++;
                            }
                        }
                    }
                }
                //imprmiendo descifrado//
                for (int y = 0; y < texto.Length; y++)
                {
                    textBox_texto_cifrado.Text += texto.GetValue(y).ToString();
                }
            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.ToString());
            }
            
        }        
    }
}
