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
            
        }

        private void iniciar(string baseDatos)
        {
            try
            {
                string selectQuery = "select * FROM pyf.tablero";
                //v"select * FROM pyf.tablero where factura="+textFactura.Text+" and ciudad='"+label9.Text+"'" ;
                conectar.Close();
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
            /*
            try
            {

                string insertarCodigo = "INSERT INTO tienda.ventas(id,codigo,producto,referencia,tamano,cantidad,precio,total,fecha,hora,ciudad,factura) VALUES ('"
                    + "" + "', '"
                    + textInsertarCodigo.Text + "', '"
                    + textProducto.Text + "','"
                    + textReferencia.Text + "','"
                    + textTamano.Text + "','"
                    + DateTime.Now.ToString("dd/MM/yy") + "','"
                    + DateTime.Now.ToString("hh:mm tt") + "','"
                    + label9.Text + "','"
                    + textFactura.Text + "')";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Dato insertado");
                }
                else
                {
                    //MessageBox.Show("Dato insertado");
                }
                iniciar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conectar.Close();
            */
        }


        private void buscarFactura (int numero, String select)
        {
         /*  
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */

        }

    

        private void finalizar_Click_1(object sender, EventArgs e)
        {
            buscarFactura(1, "SELECT * FROM tienda.ventas order by factura desc limit 1");
            iniciar("");
            
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

        

        private void textCodigo_TextChanged_1(object sender, EventArgs e)
        {
         
        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            
        }


        private void buniBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader mdr;
                string select = "SELECT * FROM pyf.usuario where usuario='"+buniTextUsuario.text + "' and pass='"+buniTextPass.text+"'" ;
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    MessageBox.Show("Login exitoso");
                    bunifuProgressBar1.Value = 100;
                    label9.Text = buniTextUsuario.text;
                    this.Size = new Size(1076, 692);
                    
                    buniMaxMin.Enabled = true;
                    buscarFactura(0, "SELECT * FROM pyf.tablero");
                    //SELECT * FROM pyf.tablero order by juego desc limit 1
                    iniciar("");                    
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
            buscarFactura(0, "SELECT * FROM pyf.tablero");
            iniciar("");
       
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

       
    }
    
}
