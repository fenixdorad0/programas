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

namespace MysqlTienda
{

    public partial class Form1 : Form
    {
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
        public int yainicio=0;
        public Form1()
        {
            InitializeComponent();
        }
        public void abrirConeccion()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            
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
                MessageBox.Show(ex.Message+"ejecutando query");
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

        private void iniciarTablaVentas(string baseDatos)
        {
            try
            {
                cerrarConeccion();               
                string selectQuery = "select codigo,referencia,producto,tamano, cantidad, precio,total FROM easyerp.detalle_facturacov where factura =" +textFactura.Text+" and almacen='"+comboBox1.Text+"'"; 
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                bunifuCustomDataGrid1.DataSource = table;
                cerrarConeccion();
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message+"iniciando");
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
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad+1, total =precio*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='"+comboBox1.Text+"'";
                    //string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET `cantidad` = '3', `total` = '30000' WHERE `detalle_facturacov`.`factura` = 3 AND `detalle_facturacov`.`codigo` = 3";
                    //MessageBox.Show("wtf");
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    
                if (command.ExecuteNonQuery() == 1)
                {
                    iniciarTablaVentas("");
                    //  MessageBox.Show("Dato actualiza suma");
                }
                else
                {
                    cerrarConeccion();
                    //MessageBox.Show("se ejecuto el ingresodel producto");
                    string insertarCodigo2 = "INSERT INTO easyerp.detalle_facturacov(`factura`, `almacen`, `codigo`, `referencia`, `producto`, `tamano`, `cantidad`, `precio`, `iva`, `SubtotalSinIva`, `SubtotalConIva`, `total`) VALUES ('"
                        //INSERT INTO `detalle_facturacov` (`factura`, `almacen`, `codigo`, `referencia`, `producto`, `tamano`, `cantidad`, `precio`, `iva`, `SubtotalSinIva`, `SubtotalConIva`, `total`) VALUES('3', 'girardot', '1', 'sabana', 'alteza garantizada', 'doble', '1', '2', NULL, NULL, NULL, '2');
                        + textFactura.Text + "', '" //factura
                        + comboBox1.Text + "', '" //almacen falta por arreglar
                        + textInsertarCodigo.Text + "', '" //codigo                    
                        + textReferencia.Text + "','"
                        + textProducto.Text + "','" //
                        + textTamano.Text + "','"
                        + textCantidad.Text + "','"
                        + textPrecio.Text + "','"
                        + "0" + "','" //iva
                        + "0" + "','" // sub total sin iva
                        + "0" + "','" //sub total con iva
                        + textTotal.Text + "')";

                    conectar.Open();
                    MySqlCommand command2 = new MySqlCommand(insertarCodigo2, conectar);


                    if (command2.ExecuteNonQuery() == 1)
                    {
                        iniciarTablaVentas("");
                        textInsertarCodigo.Text = "";
                        //MessageBox.Show("Dato insertado");
                        cerrarConeccion();
                    }
                    else
                    {
                        MessageBox.Show("Dato NO insertado");
                        cerrarConeccion();

                    }
                    cerrarConeccion();
                    iniciarTablaVentas("");

                }
                }
                catch (Exception error)
                {
                    cerrarConeccion();
                    MessageBox.Show(error.Message + "update o sumando");
                }

                textInsertarCodigo.Text = "";

                //MessageBox.Show(ex.Message+"es aquii");
            

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
                cmd.CommandText = "select sum(total) from easyerp.detalle_facturacov where factura=" + textFactura.Text +" and almacen='"+comboBox1.Text+"'";
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



        private void buscarFactura ()
        {
            //CON ESTE CODIGO CAPTURO EL NUMERO DE FACTURA y lo cambio
            try
            {
                int numero = 1;
                String select = "SELECT MAX(nf) as nf FROM easyerp.factura_movimiento where almacen_nombre ='" + comboBox1.Text + "' order by nf";
                cerrarConeccion();
                MySqlDataReader mdr;
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {

                    textFactura.Text = Convert.ToString(Convert.ToInt16(mdr.GetString("nf")) + numero);
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
                String mensaje = Convert.ToString(ex.Message);
                int valor = mensaje.LastIndexOf("valor Null");
                if (valor >= 0)
                {
                    textFactura.Text = "1";
                }
                else
                {
                    MessageBox.Show(ex.Message + "buscando factura");
                }
                
                
                cerrarConeccion();
            }


        }

    

        private void finalizar_Click_1(object sender, EventArgs e)
        {

            //SELECT * FROM `factura_movimiento` WHERE almacen_nombre ='girardot' and nf ='1'
            try
            {
                 string insertarCodigo = "UPDATE easyerp.factura_movimiento SET deuda = deuda WHERE nf ="+ textFactura.Text + " and almacen_nombre='" + comboBox1.Text + "'";               
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    iniciarTablaVentas("");
                    //  MessageBox.Show("Dato actualiza suma");
                }
                else
                {
                    cerrarConeccion();
                    MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));
                    //MessageBox.Show("se ejecuto el ingresodel producto");
                    string insertarCodigo2 = "INSERT INTO easyerp.factura_movimiento(`nf`, `fecha`, `total`, `deuda`, `cliente_provedor_cc`, `pago_dividido_id`, `tipo_factura_nombre`, `usuario_cc`, `almacen_nombre`) VALUES ('"
                        + textFactura.Text + "', '" //factura
                        + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" //fecha
                        + textSumaTotal.Text + "', '" //total                    
                        + "0" + "','" // deuda
                        + "1" + "','" // CC cliente o del provedor
                        + "1" + "','"  // tipo de pago efecturado
                        + "venta" + "','" //tipo de factura o movimiento
                        + labelCedula.Text + "','" //cedula del vendedor
                        + comboBox1.Text + "')"; //almacen               
                    conectar.Open();
                    MySqlCommand command2 = new MySqlCommand(insertarCodigo2, conectar);


                    if (command2.ExecuteNonQuery() == 1)
                    {
                        textInsertarCodigo.Text = "";
                        MessageBox.Show("factura guardada ");
                    }
                    else
                    {
                        MessageBox.Show("factura NO guardada");
                    }
                    cerrarConeccion();
                    iniciarTablaVentas("");
                    
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }


            textSumaTotal.Text = "";
            buscarFactura();
            iniciarTablaVentas("");

            
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
                string select = "SELECT * FROM easyerp.producto where codigo =" + int.Parse(textInsertarCodigo.Text);
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();               

                if (mdr.Read())
                {
                    textCodigo.Text= mdr.GetString("codigo");
                    textReferencia.Text = mdr.GetString("referencia");
                    textProducto.Text = mdr.GetString("nombre");
                    textTamano.Text = mdr.GetString("tamano_nombre");
                    textCantidad.Text = "1";
                    textPrecio.Text = mdr.GetString("precioDetal");
                    textTotal.Text = Convert.ToString( Convert.ToDecimal(textPrecio.Text)*Convert.ToDecimal(textCantidad.Text));
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
               
            }

            if (prueba == true)
            {
                insertarCodigo();
            }
        }

        private void textCodigo_TextChanged_1(object sender, EventArgs e)
        {
            codigoCambia();
        }


        private void buniBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader mdr;
                string select = "SELECT* FROM easyerp.usuario WHERE `usuario`.`id` ='" + buniTextUsuario.text + "' and contrasena ='" + buniTextPass.text+"'" ;
                
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    labelCedula.Text = mdr.GetString("cc");
                    labelVendedor.Text = mdr.GetString("nombre");
                    MessageBox.Show("Login exitoso");
                    bunifuProgressBar1.Value = 100;
                    labelAlmacen.Text = buniTextUsuario.text;
                    this.Size = new Size(1339, 637);
                    textInsertarCodigo.Enabled = true;
                    buniMaxMin.Enabled = true;
                    cerrarConeccion();
                    cargarCiudades();
                    buscarFactura();
                    //buscarFactura(0, "SELECT * FROM easyerp.detalle_facturacov order by factura_movimiento_nf where id = LAST_INSERT_ID");
                    iniciarTablaVentas("");
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


            yainicio = 1;
        }

        private void cargarCiudades()
        {
            
            
            using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
            {
                c.Open();

                var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc="+labelCedula.Text+"";
                using (MySqlCommand cmd = new MySqlCommand(sql, c))
                {
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    comboBox1.ValueMember = "cc";
                    comboBox1.DisplayMember = "almacen_fabrica_nombre";
                    comboBox1.DataSource = dt;
                }
            }
           
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaUsuario();

        }

        private void cargarDatosTablaUsuario()
        {
            try
            {
                //Cargando los datos
                //id,codigo,referencia,producto,tamaño,cantidad,precio,total
                //textId.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
                textCodigo.Text = textProducto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
                textReferencia.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
                textProducto.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
                textTamano.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
                textCantidad.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
                textPrecio.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
                textTotal.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
           
        }

        private void bunifuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Convert.ToInt32(textCantidad.Text) > 1)
                {
                    
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad-1, total =precio*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBox1.Text + "'";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        iniciarTablaVentas("");
                        limpitarTextosVentas();

                    }
                    else {}
                    

                }
                else if (Convert.ToInt32(textCantidad.Text) <= 1)
                {
                    
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBox1.Text + "'";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        iniciarTablaVentas("");
                        limpitarTextosVentas();
                    }
                    else { }
                    
                    //DELETE FROM `detalle_facturacov` WHERE factura='1' and almacen='girardot'
                }
                else
                {

                }

                
            }
            catch (Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("La cadena");
                if (valor >= 0)
                {
                    
                }
                else
                {
                    MessageBox.Show(error.Message + "update o restando");
                }
                cerrarConeccion();
                
            }




            /*
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Enabled = false;
            }
            */
        }

        private void limpitarTextosVentas()
        {
            textId.Text = "";
            textCodigo.Text = "";
            textReferencia.Text = "";
            textProducto.Text = "";
            textTamano.Text = "";
            textCantidad.Text = "";
            textPrecio.Text = "";
            textTotal.Text = "";
        }

        private void buniActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET precio =" +textPrecio.Text+", total =precio*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBox1.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    iniciarTablaVentas("");
                    limpitarTextosVentas();

                }
                else { }
                sumaTotal();
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }

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

        private void buniRegistro_Click(object sender, EventArgs e)
        {

        }

        private void textSumaTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            labelAlmacen.Text = comboBox1.Text;
            if (yainicio == 1)
            {    
                
                buscarFactura();
                iniciarTablaVentas("");
                sumaTotal();
            }
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void labelVendedor_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool todoEstaBien = comprobarDatosUsuario();
                if ( todoEstaBien == true){
                    cerrarConeccion();
                    string insertarCodigo = "INSERT INTO easyerp.usuario (`cc`, `id`, `contrasena`, `correo`, `nombre`) VALUES (" +
                        "'" +
                        TextboxCedula.text + "', '" +
                        TextboxUsuario.text + "', '" +
                        TextboxCedula.text + "', '" +
                        TextboxContrasena.text + "', '" +
                        TextboxNombre.text + "')";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    if (command.ExecuteNonQuery() == 1) {     /* essageBox.Show("encontre la factura"); */ } else { /* MessageBox.Show("no encontre la factura"); */}
                    cerrarConeccion();
                    iniciarTablaUsuarios();
                }
                else
                {

                }
               
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
           
            

        }

        private bool comprobarDatosUsuario()
        {
            //con el @ se quita el problema de salida desconocida
            bool verificarEmail = bien_escrito(TextboxCorreo.text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (verificarEmail == true) { LabelUCorreo.Text = "correo"; } else { LabelUCorreo.Text = "correo (verifique que este bien escrito)"; };

            bool verificarNombre = bien_escrito(TextboxNombre.text, "[a-zA-ZñÑ\\s]{2,50}");
            if (verificarNombre == true) { LabelUNombre.Text = "nombre"; } else { LabelUNombre.Text = "nombre (verifique que este bien escrito)"; };

            bool verificarCedula = bien_escrito(TextboxCedula.text, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
            if (verificarCedula == true) { LabelUCedula.Text = "cédula"; } else { LabelUCedula.Text = "cédula(verifique que este bien escrito)"; };

            if (verificarCedula == true && verificarNombre == true && verificarEmail == true)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private Boolean bien_escrito(String email, string expresionRegular)
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

        private void bunifuTextbox12_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void TextboxNombre_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonUsuarioCargar_Click(object sender, EventArgs e)
        {
            iniciarTablaUsuarios();
        }

        private void iniciarTablaUsuarios()
        {
            try
            {
                cerrarConeccion();
                //string selectQuery = "select * FROM easyerp.detalle_facturacov where factura_movimiento_nf="+textFactura.Text;
                string selectQuery = "SELECT * FROM easyerp.usuario ORDER BY `cc` DESC";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                bunifuCustomDataGrid2.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "iniciando");
            }
        }

        private void TextboxContrasena_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void TextboxCorreo_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBox1.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    
                    iniciarTablaVentas("");
                }
                else { }
                cerrarConeccion();

            }
            catch(Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("La cadena");
                if (valor >= 0)
                {

                }
                else
                {
                    MessageBox.Show(error.Message + "en eliminando");
                }
                cerrarConeccion();
               
            }
            sumaTotal();
        }
    }
    
}
