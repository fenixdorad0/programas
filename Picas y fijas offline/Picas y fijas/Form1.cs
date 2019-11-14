using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using MySql.Data.MySqlClient;



namespace Picas_y_fijas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.MaxLength=4;            
            textNumero.MaxLength = 4;

        }

        /*
        BaseDeDatos bd = new BaseDeDatos();
        MySqlConnection conection = new MySqlConnection();
        conection.ConnectionString = "Server=Servidor;Database=Nombre_de_la_base_de_datos; Uid=Nombre_de_usuario;Pwd=contraseña;";
        conection.open();
        */
        string numeroD;
        string numeroR;
        public int numeroMio;
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            int picas = 0;
            int fijas = 0;
            numeroR = Convert.ToString(textBox1.Text);
            var chars2 = numeroR.ToCharArray();
            Console.WriteLine("Original string: {0}", numeroR);
            Console.WriteLine("Character array:");
            for (int cont2 = 0; cont2 < chars2.Length; cont2++)
            {
                Console.WriteLine("   {0}: {1}", cont2, chars2[cont2]);
            }
            //mi clave a array

            //numeroR= Convert.ToInt16(textBox1.Text);
            String s = Convert.ToString(numeroMio);
            var chars = s.ToCharArray();
            Console.WriteLine("Original string: {0}", s);
            Console.WriteLine("Character array:");
            for (int cont1 = 0; cont1 < chars.Length; cont1++)
            {
                Console.WriteLine("   {0}: {1}", cont1, chars[cont1]);
            }

            for (int x=0;x < 4; x++)
            {
                for (int y=0; y < 4; y++)
                {
                    if (chars[x]== chars2[y])
                    {
                        MessageBox.Show("coincidencia" + chars[x] + "  " + chars2[y]);
                        if (x == y)
                        {
                            fijas++;                           
                        }
                        else
                        {
                            picas++;
                        }
                            
                    }
                }
            }
            MessageBox.Show("pícas"+picas+"fijas"+fijas);
            //--------------------------------------------------------------
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void miNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            numeroMio = Convert.ToInt16(textNumero.Text);
            MessageBox.Show("numero guardado con exito");
            panel2.Visible = true;

        }
    }
}

