using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using MysqlTienda;

namespace MysqlTienda
{
    public partial class Form2 : Form
    {
        /*
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
       
        /*
        public void abrirConeccion()
        {
            try
            {
                if (conectar.State == ConnectionState.Closed)
                {
                    conectar.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "abriendo coneccion");
            }

        }
        public void cerrarConeccion()
        {
            try
            {
                if (conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "cerrando coneccion");
            }
        }
        */
        public double total=0;
        public Form2()
        {
            InitializeComponent();            
            this.TopMost = true;
        }
        public Form2(string texto)
        {
            try
            {
                total = Convert.ToDouble(texto);
                InitializeComponent();
                this.TopMost = true;
                labelTotal.Text = "El total es:" + texto;
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            labelPago.Text = "efectivo";
            /*
            
            */
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            labelPago.Text = "datafono";
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            labelPago.Text = "credito";
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            labelPago.Text = "apartado";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            labelPago.Text = "qr";
        }
        public Boolean bien_escrito(String email, string expresionRegular)
        {

            if (Regex.IsMatch(email, expresionRegular))
            {
                if (Regex.Replace(email, expresionRegular, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void TextboxCambio_OnValueChanged(object sender, EventArgs e)
        {
           
            
        }

        private void TextboxPago_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool verificarCedula = bien_escrito(TextboxPago.Text, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
                if (verificarCedula == true)
                {
                    labelPagoCon.Text = "pago con";
                    TextboxCambio.Text = Convert.ToString((Convert.ToDouble(TextboxPago.Text)-total));
                }
                else
                {
                    labelPagoCon.Text = "Pago con(verifique que este bien escrito)";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }


            
        }
    }
}
