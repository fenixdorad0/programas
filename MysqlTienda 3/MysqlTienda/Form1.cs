using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlTienda
{

    public partial class Form1 : Form
    {
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
        public Form1()
        {
            InitializeComponent();
        }
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }
        public void ejecutarQuery(String query)
        {
            try
            {
                abrirConeccion();
                command = new MySqlCommand(query,conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query ejecutada correctamente");
                }
                else
                {
                    MessageBox.Show("Query NO ejecutada correctamente");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cerrarConeccion();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buniMaxMin.Enabled = false;
            this.Size = new Size(240, 637);
            textInsertarCodigo.Enabled = false;

        }

        private void iniciar(string baseDatos)
        {
            try
            {
                //string selectQuery = "select * FROM easyerp.detalle_facturacov where factura_movimiento_nf="+textFactura.Text;
                string selectQuery = "select * FROM easyerp.detalle_facturacov where factura_movimiento_nf=1";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Servidor sin conección");
            }
        }

        //insertar
        private void button1_Click(object sender, EventArgs e)
        {
            insertarCodigo();
        }

        private void insertarCodigo()
        {
            try
            {

                string insertarCodigo = "INSERT INTO tienda.ventas(id,codigo,producto,referencia,tamano,cantidad,precio,total,fecha,hora,ciudad,factura) VALUES ('"
                    + "" + "', '"
                    + textInsertarCodigo.Text + "', '"
                    + textProducto.Text + "','"
                    + textReferencia.Text + "','"
                    + textTamano.Text + "','"
                    + textCantidad.Text + "','"
                    + textPrecio.Text + "','"
                    + Convert.ToDouble(textCantidad.Text)* Convert.ToDouble(textPrecio.Text) + "','"
                    + DateTime.Now.ToString("dd/MM/yy") + "','"
                    + DateTime.Now.ToString("hh:mm tt") + "','"
                    + label9.Text + "','"
                    + textFactura.Text + "')";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Dato insertado");
                }
                else
                {
                    MessageBox.Show("Dato NO insertado");
                }
                iniciar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conectar.Close();
        }

        private void limpiarTextbox()
        {
            textInsertarCodigo.Text = null;
            textReferencia.Text = null;
            textProducto.Text = null;
            textCantidad.Text = null;
            textPrecio.Text = null;
            textTotal.Text = null;
            textTamano.Text = null;
        }
      
        private void modificar_Click(object sender, EventArgs e)
        {
            sumaTotal();

        }

        private void sumaTotal()
        {
            // acá optenemos el total de la factura
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //cmd.CommandText = "select sum(cantidad) from tienda.ventas where factura=" + textFactura.Text;
                cmd.CommandText = "select sum(total) from easyerp.detalle_facturacov where factura_movimiento_nf=" + textFactura.Text +"";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conectar;
                conectar.Open();
                textSumaTotal.Text = Convert.ToString(cmd.ExecuteScalar());
                conectar.Close();
            }
            catch
            {

            }

        }



        private void buscarFactura (int numero, String select)
        {
            //CON ESTE CODIGO CAPTURO EL NUMERO DE FACTURA
            try
            {
                MySqlDataReader mdr;
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    textFactura.Text = Convert.ToString(Convert.ToInt16(mdr.GetString("factura_movimiento_nf")) + numero);
                }
                else
                {
                    MessageBox.Show("no encontrado");
                }
                cerrarConeccion();

                //MessageBox.Show("en construccion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    

        private void finalizar_Click_1(object sender, EventArgs e)
        {
            buscarFactura(1, "SELECT * FROM easyerp.detalle_facturacov order by factura_movimiento_nf desc limit 1");
            iniciar("");
            sumaTotal();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void incementarProgeso()
        {
            
            bunifuGauge1.Value += 5;
            if (bunifuGauge1.Value == 100)
            {
                bunifuGauge1.Value = 0;
            }
        }

        private void codigoCambia()
        {
            sumaTotal();
            bool prueba = false;
            try
            {

                MySqlDataReader mdr;
                string select = "SELECT * FROM tienda.inventario where codigo =" + int.Parse(textInsertarCodigo.Text);

                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    textReferencia.Text = mdr.GetString("referencia");
                    textProducto.Text = mdr.GetString("producto");
                    textTamano.Text = mdr.GetString("tamano");
                    textCantidad.Text = mdr.GetString("cantidad");
                    textPrecio.Text = "1";
                    prueba = true;
                    incementarProgeso();


                }
                else
                {
                    //MessageBox.Show("no encontrado");
                    prueba = false;
                }
                cerrarConeccion();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            if (prueba == true)
            {
                insertarCodigo();
                limpiarTextbox();

            }
            else
            {

            }
        }

        private void textCodigo_TextChanged_1(object sender, EventArgs e)
        {
            codigoCambia();
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            
        }


        private void buniBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader mdr;
                string select = "SELECT* FROM easyerp.usuario WHERE `usuario`.`id` ='" + buniTextUsuario.text + "' and contrasna ='" + buniTextPass.text+"'" ;
                
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    MessageBox.Show("Login exitoso");
                    bunifuProgressBar1.Value = 100;
                    label9.Text = buniTextUsuario.text;
                    this.Size = new Size(1339, 637);
                    textInsertarCodigo.Enabled = true;
                    buniMaxMin.Enabled = true;
                    // "WHERE id = LAST_INSERT_ID""
                    cerrarConeccion();
                    buscarFactura(0, "SELECT * FROM easyerp.detalle_facturacov order by factura_movimiento_nf limit 1");
                    //buscarFactura(0, "SELECT * FROM easyerp.detalle_facturacov order by factura_movimiento_nf where id = LAST_INSERT_ID");
                    iniciar("");
                    sumaTotal();
                }
                else
                {
                    MessageBox.Show("no se ha encontrado usuario");
                }
                cerrarConeccion();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message + "o no hay conección con el servidor");
            }
            /*
            buscarFactura(0, "SELECT * easyerp.detalle_facturacov order by factura_movimiento_nf limit 1");
           
            iniciar("");
            codigoCambia();
             */
        }


        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //falta por arrelgar
            textId.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            textCodigo.Text = textProducto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            textProducto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            textReferencia.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            textTamano.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            textCantidad.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            textPrecio.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
        }

        private void bunifuEliminar_Click(object sender, EventArgs e)
        {
            /*
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Enabled = false;
            }
            */
        }

        private void buniActualizar_Click(object sender, EventArgs e)
        {

            //command.CommandText = "UPDATE Student(LastName, FirstName, Address, City) VALUES (@ln, @fn, @add, @cit) WHERE LastName='" + lastName + "' AND FirstName='" + firstName + "'";

        }


     
        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;
        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point df = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(df));
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if ( this.Size == new Size(240, 637))
            {
                this.Size = new Size(1339, 637);
            }
            else
            {
                this.Size = new Size(240, 637);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insertar_Click(object sender, EventArgs e)
        {

        }

        private void textFactura_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
