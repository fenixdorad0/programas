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
      
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
        public bool datafono = true, efectivo =true, credito=true, qr=true, apartado = true;
        public string factura = "";
       
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
        public void ejecutarQuery(String query)
        {
            try
            {
                abrirConeccion();
                command = new MySqlCommand(query, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query ejecutada correctamente");
                }
                else
                {
                    MessageBox.Show("Query NO ejecutada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ejecutando query");
            }
            finally
            {
                cerrarConeccion();
            }

        }




        public double total=0;

        //private Form1 formulario1;
        public Form2(/*Form1 formulario2*/)
        {
            InitializeComponent();
            //formulario1 = formulario2;
            this.TopMost = true;
            labelFactura2.Text = factura;
            
        }
        public Form2(string texto, string factura1)
        {
            total = Convert.ToDouble(texto);
            try
            {
                factura = factura1;
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
            TextboxEfectivo.Visible = true;
            TextboxEfectivo.Enabled = true;
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
            TextboxDatafono.Enabled = true;
            TextboxDatafono.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            labelPago.Text = "credito";
            TextboxCredito.Enabled = true;
            TextboxCredito.Visible = true;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            labelPago.Text = "apartado";
            TextboxApartado.Enabled = true;
            TextboxApartado.Visible = true;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            labelPago.Text = "qr";
            TextboxQR.Enabled = true;
            TextboxQR.Visible = true;
        }

        private void TextboxDatafono_OnValueChanged(object sender, EventArgs e)
        {
            datafono = verificarTexto(TextboxDatafono.Text);
            sumarTotal();

        }

        private void TextboxEfectivo_OnValueChanged(object sender, EventArgs e)
        {
            efectivo = verificarTexto(TextboxEfectivo.Text); 
            sumarTotal();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            labelPago.Text = "cotizacion";
            
        }

        private void TextboxCredito_OnValueChanged(object sender, EventArgs e)
        {
            credito = verificarTexto(TextboxCredito.Text);
            sumarTotal();
        }

        private void TextboxQR_OnValueChanged(object sender, EventArgs e)
        {
            qr = verificarTexto(TextboxQR.Text);
            sumarTotal();
        }

        private void TextboxApartado_OnValueChanged(object sender, EventArgs e)
        {
            apartado = verificarTexto(TextboxApartado.Text);
            sumarTotal();
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
                String texto = TextboxPago.Text;
                bool verificarTexto = bien_escrito(texto, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
                if (verificarTexto == true)
                {
                    
                    labelPagoCon.Text = "pago con";
                    TextboxCambio.Text = Convert.ToString((Convert.ToDouble(texto)-total));
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

        private bool verificarTexto(String texto)
        {
            try
            {

                bool verificarTexto = bien_escrito(texto, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
                if (verificarTexto == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
                MessageBox.Show(Convert.ToString(error));
            }
        }

        private void sumarTotal()
        {
           
            if (datafono == true & efectivo == true & credito == true & qr == true & apartado == true)
            {
                TextboxPago.Text = Convert.ToString(
                    Convert.ToDouble(TextboxDatafono.Text) +
                    Convert.ToDouble(TextboxEfectivo.Text) +
                    Convert.ToDouble(TextboxCredito.Text) +
                    Convert.ToDouble(TextboxQR.Text) +
                    Convert.ToDouble(TextboxApartado.Text)
                    );
            }
        }

    }
}
