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
    public partial class Cifrado_Vigenere : Form
    {
        char[] mensaje;
        char[] clave;

        public Cifrado_Vigenere()
        {
            InitializeComponent();
        }

        private void button_Cifrar_Click(object sender, EventArgs e)
        {
            textBox_texto_cifrado.Text = "";
            Vigenere(textBox_texto_claro.Text, textBox_clave.Text);//llamado a la funcion Vigenere
        }        
        public void Vigenere(string msg, string clave)
        {
            this.mensaje = msg.ToCharArray(); //conversion de string a array
            char[] claveTemp = clave.ToCharArray();
            this.clave = new char[mensaje.Length];
            int cont = 0;
            for (int i = 0; i < mensaje.Length; i++)//For mete la clave multiples veces en 1 arreglo
            {
                this.clave[i] = claveTemp[cont];
                cont++;
                if (cont == claveTemp.Length)
                    cont = 0;
            }
            //la clave ya se guardo en un arreglo de igual tamaño que del mensaje            
            cifrar(); //ciframos el texto
        }

        public void cifrar() //Genera cifrado
        {
            
            char[] cifrado = new char[mensaje.Length];
            char[] alfabeto = new char[27] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int y = 0; y < mensaje.Length; y++)
            {
                bool vandera = true;
                int z = 0;
                int valor_M = 0;
                int valor_C = 0;
                //while para mensaje//
                while (vandera)
                {

                    if (z < 27)
                    {
                        if (Convert.ToChar(mensaje.GetValue(y)) == alfabeto[z])
                        {
                            valor_M = z; //valor de la letra del mensaje
                            vandera = false;
                        }
                        else
                        {
                            z++;
                        }
                    }
                }
                //whle para clave//
                z = 0;
                vandera = true;
                while (vandera)
                {

                    if (z < 27)
                    {
                        if (Convert.ToChar(clave.GetValue(y)) == alfabeto[z])
                        {
                            valor_C = z; //valor para letra de la clave
                            vandera = false;
                        }
                        else
                        {
                            z++;
                        }
                    }
                }
                //cifrando...//
                int valor_cifra = (valor_M + valor_C) % 27; //operacion de cifrado
                cifrado[y] = alfabeto[valor_cifra]; //cifrado = a la letra del alfabeto segun el valor_cifra
            }
            for(int x=0; x < mensaje.Length; x++)  //imprimiendo en textbox_cifrado
            {
                textBox_texto_cifrado.Text += cifrado[x];
            }            
        }

      

    }
}
