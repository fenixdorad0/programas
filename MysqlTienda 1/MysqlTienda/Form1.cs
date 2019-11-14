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
            buscarFactura(0, "SELECT * FROM tienda.ventas order by factura desc limit 1");
            iniciar("");
            sumaTotal();

        }

        private void iniciar(string baseDatos)
        {
            try
            {
                
                string selectQuery = "Select * FROM tienda.ventas where factura="+Convert.ToString( Convert.ToInt16(textFactura.Text));
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                dataGridView1.DataSource = table;
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
                    + textCodigo.Text + "', '"
                    + textProducto.Text + "','"
                    + textReferencia.Text + "','"
                    + textTamano.Text + "','"
                    + textCantidad.Text + "','"
                    + textPrecio.Text + "','"
                    + Convert.ToDouble(textCantidad.Text)* Convert.ToDouble(textPrecio.Text) + "','"
                    + DateTime.Now.ToString("dd/MM/yy") + "','"
                    + DateTime.Now.ToString("hh:mm tt") + "','"
                    + "Girardot" + "','"
                    + textFactura.Text + "')";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Dato insertado");
                }
                else
                {
                    //MessageBox.Show("Dato NO insertado");
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
            textCodigo.Text = null;
            textReferencia.Text = null;
            textProducto.Text = null;
            textCantidad.Text = null;
            textPrecio.Text = null;
            textTotal.Text = null;
            textTamano.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //falta por arrelgar
            textCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textReferencia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textProducto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textTamano.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textCantidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textPrecio.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            

        }
        

        private void modificar_Click(object sender, EventArgs e)
        {
            sumaTotal();

        }

        private void sumaTotal()
        {
            /*
            MySqlDataReader mdr;
            string sql = "select sum(cantidad) from tienda.ventas where factura" + textFactura.Text;
            abrirConeccion();
            mdr = command.ExecuteReader();

            if (mdr.Read())
            {
                //Console.WriteLine(mdr["cantidad"]);
                //textSumaTotal.Text = mdr.GetString("sum(cantidad)");}
                

            }
            else
            {
                //MessageBox.Show("no encontrado");

            }
            cerrarConeccion();
            */
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select sum(cantidad) from tienda.ventas where factura=" + textFactura.Text;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conectar;
            conectar.Open();            
            textSumaTotal.Text = Convert.ToString(cmd.ExecuteScalar());
            conectar.Close();

        }

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {
            sumaTotal();
            bool prueba = false;
            try
            {
                
                MySqlDataReader mdr;
                string select = "SELECT * FROM tienda.inventario where codigo =" + int.Parse(textCodigo.Text);
                
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

            if (prueba ==true)
            {
                insertarCodigo();
                limpiarTextbox();

            }
            else
            {
                
            }
            

        }
        

        private void buscarFactura (int numero, String select)
        {
            MySqlDataReader mdr;
            
            command = new MySqlCommand(select, conectar);
            abrirConeccion();
            mdr = command.ExecuteReader();

                     
            if (mdr.Read())
            {
                textFactura.Text = Convert.ToString(Convert.ToInt16(mdr.GetString("factura")) + numero);



            }
            else
            {
                MessageBox.Show("no encontrado");
            }
            cerrarConeccion();

            //MessageBox.Show("en construccion");
        }

    

        private void finalizar_Click_1(object sender, EventArgs e)
        {
            buscarFactura(1, "SELECT * FROM tienda.ventas order by factura desc limit 1");
            iniciar("");
            sumaTotal();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void insertar_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    
}
