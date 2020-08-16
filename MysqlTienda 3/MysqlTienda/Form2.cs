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
using MySqlX.XDevAPI.Common;

namespace MysqlTienda
{
    public partial class Form2 : Form
    {
      
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
        public bool datafono = true, efectivo =true, credito=true, qr=true, apartado = true;
        

        public string factura = "";
        public string ciudad = "";
        public double total = 0;

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




       

        //private Form1 formulario1;
        public Form2(/*Form1 formulario2*/)
        {
            InitializeComponent();
            //formulario1 = formulario2;
            this.TopMost = true;
            TextboxEfectivo.Text = "0";
            TextboxDatafono.Text = "0";
            TextboxCredito.Text = "0";

        }
        public Form2(string texto, string factura1, string ciudad1)
        {
            
            total = Convert.ToDouble(texto);
            try
            {
                factura = factura1;
                ciudad = ciudad1;
                InitializeComponent();
                this.TopMost = true;
                labelTotal.Text = "El total es:" + texto;
                labelFactura2.Text = "Factura #" + factura; 
                labelCiudad.Text = "Ciudad: " + ciudad1;
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            labelPago.Text = "efectivo";
            TextboxEfectivo.Visible = true;
            TextboxEfectivo.Enabled = true;
            /*
            
            */
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
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
           
        }

        private void TextboxDatafono_OnValueChanged(object sender, EventArgs e)
        {
            //double valorDatafonozz
            datafono = verificarTexto(TextboxDatafono.Text);
            if (datafono == false) { TextboxDatafono.Text = "0"; };
            if (Convert.ToDouble(TextboxDatafono.Text) > total){TextboxDatafono.Text = "0";}
            sumarTotal();

        }

        private void TextboxEfectivo_OnValueChanged(object sender, EventArgs e)
        {
            
            efectivo = verificarTexto(TextboxEfectivo.Text); 
            if (efectivo == false) { TextboxEfectivo.Text = "0";};
            sumarTotal();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            labelPago.Text = "cotizacion";
            

        }

        private void TextboxCredito_OnValueChanged(object sender, EventArgs e)
        {
            credito = verificarTexto(TextboxCredito.Text);
            if (credito == false) { TextboxCredito.Text = "0"; };
            if (Convert.ToDouble(TextboxCredito.Text) > total)
            {
                TextboxCredito.Text = "0";
            }
            sumarTotal();
        }

        private void TextboxQR_OnValueChanged(object sender, EventArgs e)
        {
            
            sumarTotal();
        }

        private void TextboxApartado_OnValueChanged(object sender, EventArgs e)
        {
            apartado = verificarTexto(TextboxApartado.Text);
            
            if (apartado == true)
            {
                TextboxDatafono.Text = "0";
                TextboxCredito.Text = "0";
                TextboxEfectivo.Text = "0";
            }
            else
            { TextboxApartado.Text = "0"; };

            if (Convert.ToDouble(TextboxApartado.Text) > total)
            {
                TextboxApartado.Text = "0";
            }
            sumarTotal();
        }

     
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            double resultadoEfectivo = Convert.ToDouble(TextboxEfectivo.Text) - ((Convert.ToDouble(TextboxPago.Text) - total));

            try
            {
                

                if (datafono == true && efectivo == true && credito == true && qr == true && apartado == true)
                {
                    //Form1 formulario1 = new Form1();

                   

                    if (labelPago.Text == "cotizacion")
                    {
                        //
                        MessageBox.Show("cotización realizada");
                        insertarDatos("DELETE FROM easyerp.factura_movimiento WHERE nf='"+factura+"' and almacen_nombre='"+ciudad+"'");
                        insertarDatos("DELETE FROM easyerp.detalle_facturacov WHERE factura='" + factura + "' and almacen='" + ciudad + "'");
                        //formulario1.respuestaFormulario = "cotizacion";
                    }
                    else
                    {
                        //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        insertarDatos("INSERT INTO easyerp.metodo_pago_detallado (`ID`, `nf`, `efectivo`, `datafono`, `credito`, `apartado`, `cotizacion`, `ciudad`, `total`, `vueltas`, `pagoCon`, `fecha`) VALUES (NULL, '" + factura + "', '" + Convert.ToString(resultadoEfectivo) + "', '" + TextboxDatafono.Text + "', '" + TextboxCredito.Text + "', '" + TextboxApartado.Text + "', 'true', '" + ciudad + "', '" + Convert.ToString(total) + "', '" + (Convert.ToString(Convert.ToDouble(TextboxPago.Text) - total)) + "', '" + TextboxPago.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                        //formulario1.respuestaFormulario = "venta";

                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("algun dato esta mal");
                }
               
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }

        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void TextboxCambio_OnValueChanged(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
      
            /*
            MessageBox.Show(ciudad+ "  "+ Convert.ToString(factura));
            insertarDatos("DELETE FROM easyerp.factura_movimiento WHERE nf='" + factura + "' and almacen_nombre='" + ciudad + "'");
            */

            MessageBox.Show(Convert.ToString(total)+" devueltas"+ Convert.ToString(Convert.ToDouble(TextboxPago.Text) - total));

        }

        public void insertarDatos(String insertarCodigo)
        {
            try
            {
                cerrarConeccion();
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1) 
                { 
                   MessageBox.Show("Venta realizada con exito");
                    
                }
                else 
                { /* MessageBox.Show("no encontre la factura"); */}
                cerrarConeccion();
            }
            catch (Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("Duplicate");
                if (valor >= 0) { MessageBox.Show("Ya existe un registro igual"); }
                else
                {
                    MessageBox.Show(error.Message + "insertar Datos");
                }
            }
           
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
                    MessageBox.Show("enserio");
                }
            }
            catch
            {
                return false;
                MessageBox.Show("enserio");

            }
        }

        private void sumarTotal()
        {
            try
            {
                if (datafono == true & efectivo == true & credito == true & qr == true & apartado == true)
                {
                    TextboxPago.Text = Convert.ToString(
                        Convert.ToDouble(TextboxDatafono.Text) +
                        Convert.ToDouble(TextboxEfectivo.Text) +
                        Convert.ToDouble(TextboxCredito.Text) +
                        Convert.ToDouble(TextboxApartado.Text)
                        );
                }
            }
            catch
            {

            }
           
           
        }

    }
}
