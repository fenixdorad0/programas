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
        String a = "datasource=localhost;port=3306;username=root;password=;SslMode=none";
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");

        MySqlCommand command;
        public int yainicio = 0;
        public String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
        public string respuestaFormulario = "algo";
        // No se que write
        public double sumatotal=0;
        public Form1()
        {

            InitializeComponent();
            comboBoxCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTaxesProduct2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartamentProduct2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStoreProduct2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSizeProduct2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCedulaPermiAlmace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsuPerAlm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoriaEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGastoAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGastoCatagoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlmacenEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsuarioPermisos.DropDownStyle = ComboBoxStyle.DropDownList;



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
        public void Form1_Load(object sender, EventArgs e)
        {
            ///buniMaxMin.Enabled = false;
            //this.Size = new Size(240, 637);
            textInsertCode.Enabled = false;
        }
        public void iniciarTablaVentas(string baseDatos)
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "select codigo,referencia,producto,tamano, cantidad, precio,total FROM easyerp.detalle_facturacov where factura =" + textInvoiceNumber.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                labelMessageEnd.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "iniciando");
            }
        }

        //insertar
        public void button1_Click(object sender, EventArgs e)
        {
            insertarCodigo();
        }

        public void insertarCodigo()
        {
            try
            {
                cerrarConeccion();
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textQuantity.Text);
                string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad+1, total =precio*cantidad, costoTotal=costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textInvoiceNumber.Text + " AND `detalle_facturacov`.`codigo` = " + textCode.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    //labelCantidad.Text = Convert.ToString(Convert.ToInt32(labelCantidad.Text) + 1);

                    iniciarTablaVentas("");
                }
                else
                {
                    cerrarConeccion();
                    string insertarCodigo2 = "INSERT INTO easyerp.detalle_facturacov(`factura`,`fecha`, `almacen`, `codigo`, `referencia`, `producto`, `tamano`, `cantidad`, `precio`,`costo`, `iva`, `SubtotalSinIva`, `SubtotalConIva`, `total`, `costoTotal`, `id`) VALUES ('"
                    + textInvoiceNumber.Text + "', '" //factura
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + comboBoxCiudad.Text + "', '" //almacen falta por arreglar
                    + textInsertCode.Text + "', '" //codigo 
                    + textReference.Text + "','"
                    + textProduct.Text + "','" //                    
                    + textSize.Text + "','"
                    + textQuantity.Text + "','"
                    + textPrecio.Text + "','"
                    + textBoxCostoTotal.Text + "','"
                    + "0" + "','" //iva
                    + "0" + "','" // sub total sin iva
                    + "0" + "','" //sub total con iva
                    + textTotal.Text + "','"
                    + labelCostoTotal.Text + "','"
                    + id+ "')";
                    conectar.Open();
                    MySqlCommand command2 = new MySqlCommand(insertarCodigo2, conectar);
                    if (command2.ExecuteNonQuery() == 1)
                    {
                        iniciarTablaVentas("");
                        textInsertCode.Text = "";
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
                MessageBox.Show(error.Message + "update o sumando!");
            }
            textInsertCode.Text = "";
            conectar.Close();
        }
        public void limpiarTextbox()
        {
            textInsertCode.Text = null;
            textReference.Text = null;
            textProduct.Text = null;
            textQuantity.Text = null;
            textPrecio.Text = null;
            textTotal.Text = null;
            textSize.Text = null;
        }

        public void modificar_Click(object sender, EventArgs e)
        {
            sumaTotal();
        }

        public void sumaTotal()
        {
            // acá optenemos el total de la factura
            try
            {
                MySqlCommand cmd = new MySqlCommand();      
                cmd.CommandText = "select sum(total) from easyerp.detalle_facturacov where factura=" + textInvoiceNumber.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conectar;
                conectar.Open();
                textSumaTotal.Text = Convert.ToString(cmd.ExecuteScalar());
                conectar.Close();
                convertirDecimales();
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.CommandText = "select sum(costoTotal) from easyerp.detalle_facturacov where factura=" + textInvoiceNumber.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.Connection = conectar;
                conectar.Open();
                labelCostoTotalizado.Text = Convert.ToString(cmd2.ExecuteScalar());
                conectar.Close();
                labelUtilidad.Text = Convert.ToString(1 - (Convert.ToDouble(labelCostoTotalizado.Text) / Convert.ToDouble(textSumaTotal.Text)));
            }
            catch {cerrarConeccion();}
        }

        public void buscarFactura()
        {
            //Con este código se obtiene el número de la factura
            try
            {
                int numero = 1;
                String select = "SELECT MAX(nf) as nf FROM easyerp.factura_movimiento where almacen_nombre ='" + comboBoxCiudad.Text + "' order by nf";
                cerrarConeccion();
                MySqlDataReader mdr;
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    textInvoiceNumber.Text = Convert.ToString(Convert.ToInt16(mdr.GetString("nf")) + numero);
                }
                else
                {
                    MessageBox.Show("no encontrado");
                }
                cerrarConeccion();
            }
            catch (Exception ex)
            {
                String mensaje = Convert.ToString(ex.Message);
                int valor = mensaje.LastIndexOf("valor Null");
                if (valor >= 0)
                {
                    textInvoiceNumber.Text = "1";
                }
                else
                {
                    MessageBox.Show(ex.Message + "buscando factura");
                }
                cerrarConeccion();
            }
        }

        public void finalizar_Click_1(object sender, EventArgs e)
        {
           

        }

        public void facturaVendida()
        {

            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET vendido='si' WHERE `detalle_facturacov`.`factura` ='" + textInvoiceNumber.Text + "' and almacen='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                //if (command.ExecuteNonQuery() == 1){}else{}
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
                cerrarConeccion();
            }

        }

        public void finalizarCerrarFactura()
        {
            finalizarFactura();
            textInsertCode.Text = "";
            iniciarTablaVentas("");
            textSumaTotal.Text = "";
            buscarFactura();
            iniciarTablaVentas("");
            convertirDecimales();
        }

        public void finalizarFactura()
        {
            try
            {

                string insertarCodigo = "UPDATE easyerp.factura_movimiento SET deuda = deuda WHERE nf =" + textInvoiceNumber.Text + " and almacen_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1){/*  MessageBox.Show("Dato actualiza suma"); */}
                else
                {
                    cerrarConeccion();
                    //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));
                    //MessageBox.Show("se ejecuto el ingresodel producto");
                    string insertarCodigo2 = "INSERT INTO easyerp.factura_movimiento(`nf`, `fecha`, `total`,`costo`, `deuda`, `cliente_provedor_cc`, `pago_dividido_id`, `tipo_factura_nombre`, `usuario_cc`, `almacen_nombre`) VALUES ('"
                        + textInvoiceNumber.Text + "', '" //factura
                        + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" //fecha
                        + textSumaTotal.Text + "', '" //total    
                        + labelCostoTotalizado.Text + "','" // costo
                        + "0" + "','" // deuda
                        + "1" + "','" // CC cliente o del provedor
                        + "1" + "','"  // tipo de pago efecturado
                        + "venta" + "','" //tipo de factura o movimiento
                        + labeCard.Text + "','" //cedula del vendedor
                        + comboBoxCiudad.Text + "')"; //almacen               
                    convertirDecimales();
                    conectar.Open();
                    MySqlCommand command2 = new MySqlCommand(insertarCodigo2, conectar);


                    if (command2.ExecuteNonQuery() == 1)
                    {

                        //MessageBox.Show("factura guardada ");

                    }
                    else
                    {
                        MessageBox.Show("factura NO guardada");
                    }
                    cerrarConeccion();

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        public void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string id = "";
        public void codigoCambia()
        {
            sumaTotal();
            bool prueba = false;

            try
            {
                cerrarConeccion();
                MySqlDataReader mdr;
                string select = "SELECT * FROM easyerp.producto where codigo =" + int.Parse(textInsertCode.Text) + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    id = mdr.GetString("id");
                    textCode.Text = mdr.GetString("codigo");
                    textReference.Text = mdr.GetString("referencia");
                    textProduct.Text = mdr.GetString("nombre");
                    textSize.Text = mdr.GetString("tamano_nombre");
                    textQuantity.Text = "1";
                    textPrecio.Text = mdr.GetString("precioDetal");
                    textTotal.Text = Convert.ToString(Convert.ToDecimal(textPrecio.Text) * Convert.ToDecimal(textQuantity.Text));
                    labelCosto.Text = mdr.GetString("costo");
                    labelMayor.Text = mdr.GetString("percioMayor");
                    labelDetal.Text = mdr.GetString("precioDetal");
                    textBoxCostoTotal.Text = mdr.GetString("costo");
                    labelCostoTotal.Text = Convert.ToString(Convert.ToDecimal(labelCosto.Text) * Convert.ToDecimal(textQuantity.Text));
                    prueba = true;
                    restarInventario();
                }
                else
                {
                    //MessageBox.Show("no encontrado");
                    prueba = false;
                }
                cerrarConeccion();
            }
            catch
            {
                cerrarConeccion();
            }

            if (prueba == true)
            {
                insertarCodigo();
            }
        }
        public void restarInventario()
        {

            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad-1 WHERE `producto`.`codigo` =" + textCode.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {

                }
                else { }
                cerrarConeccion();


            }
            catch 
            {
                
            }


        }

        public void aumentarInventario1()
        {
            //al momento de restar 1 producto en la factura se suma este en 1
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad+1 WHERE `producto`.`codigo` =" + textCode.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("aumente el inventario");
                }
                else { }
                cerrarConeccion();


            }
            catch 
            {

            }
        }
        public void aumentarInventarioTodo()
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad+" + textQuantity.Text + " WHERE `producto`.`codigo` =" + textCode.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Producto eliminado de la factura");
                }
                else { }
                cerrarConeccion();


            }
            catch 
            {

            }
        }

        public void textCodigo_TextChanged_1(object sender, EventArgs e)
        {
            codigoCambia();
        }

        public void buniBtnLogin_Click_1(object sender, EventArgs e)
        {
           

        }

        public void logearse()
        {
            try
            {
                //labelInsertarCodigo.Visible = true;
                textInsertCode.Visible = true;
                MySqlDataReader mdr;
                string select = "SELECT* FROM easyerp.usuario WHERE `usuario`.`id` ='" + buniTextUser.Text + "' and contrasena ='" + buniTextPass.Text + "'";
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    labeCard.Text = mdr.GetString("cc");
                    labelSeller.Text = mdr.GetString("nombre");
                    MessageBox.Show("Login exitoso");
                    labelAlmacen.Text = buniTextUser.Text;
                    //this.Size = new Size(1339, 637);
                    textInsertCode.Enabled = true;
                    //buniMaxMin.Enabled = true;
                    cerrarConeccion();
                    cargarDatagridviews();
                    label15.Visible = true;
                    buscarFactura();
                    //buscarFactura(0, "SELECT * FROM easyerp.detalle_facturacov order by factura_movimiento_nf where id = LAST_INSERT_ID");
                    iniciarTablaVentas("");
                    sumaTotal();
                    cargarComboboxes();
                    colocarFormatoDecimalDataGrids();

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

        private void cargarDatagridviews()
        {
            cargarcomboBoxUsuarioPermisos();
            cargarPermisosUsuario();
            cargarCiudades();
            cargarCiudadesGastos();
            cargarCiudadesEntradas();
            cargarGastoDescipcion();
            cargarCategoriaEntrada();
        }

        private void colocarFormatoDecimalDataGrids()
        {
            try
            {
                labelMessageEnd.Columns[5].DefaultCellStyle.Format = "#,#";
                labelMessageEnd.Columns[6].DefaultCellStyle.Format = "#,#";
                DataGridProductos.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridProductos.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridProductos.Columns[6].DefaultCellStyle.Format = "#,#";
            }
            catch { }


        }
        private void cargarComboboxes()
        {
            cargarPermisosPorAlmacen();
            cargarCiudadesPermisosAlamacen();
            iniciarTablaUsuarios();
            CargarDepartamentosTabla();
            cargarTablaTamano();
            cargarPermisosPorUsuario();
            cargarProductosTabla();
            cargarAlmacenescombobox();
            cargarTamanoscombobox();
            cargarDepartamentosCombobox();

            cargarCLientesProvedores();
            cargarTablaAlmacenes();
        }

        public void cargarPermisosPorAlmacen()
        {
            try
            {
                
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT cc FROM easyerp.usuario";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxCedulaPermiAlmace.ValueMember = "cc";
                        comboBoxCedulaPermiAlmace.DisplayMember = "cc";
                        comboBoxCedulaPermiAlmace.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }
        public void cargarcomboBoxUsuarioPermisos()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                   
                    var sql = "SELECT usuario FROM easyerp.permisosusuarios";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxUsuarioPermisos.ValueMember = "usuario";
                        comboBoxUsuarioPermisos.DisplayMember = "usuario";
                        comboBoxUsuarioPermisos.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }
        public void cargarDepartamentosCombobox()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.departamento";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxDepartamentProduct2.ValueMember = "nombre";
                        comboBoxDepartamentProduct2.DisplayMember = "nombre";
                        comboBoxDepartamentProduct2.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }
        public void cargarTamanoscombobox()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.tamano";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxSizeProduct2.ValueMember = "nombre";
                        comboBoxSizeProduct2.DisplayMember = "nombre";
                        comboBoxSizeProduct2.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }
        public void cargarAlmacenescombobox()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.almacen_fabrica";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxStoreProduct2.ValueMember = "nombre";
                        comboBoxStoreProduct2.DisplayMember = "nombre";
                        comboBoxStoreProduct2.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        public void cargarCedulas()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labeCard.Text + "";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxTipoAlmacen.ValueMember = "cc";
                        comboBoxTipoAlmacen.DisplayMember = "almacen_fabrica_nombre";
                        comboBoxTipoAlmacen.DataSource = dt;
                    }
                }
            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo


        }
        public void cargarCiudades()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labeCard.Text + "";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxCiudad.ValueMember = "cc";
                        comboBoxCiudad.DisplayMember = "almacen_fabrica_nombre";
                        comboBoxCiudad.DataSource = dt;
                    }
                }
            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo


        }
        public void cargarGastoDescipcion()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre,descripcion,entradaOgasto FROM easyerp.tipo_gasto_entrada WHERE entradaOgasto = 'gasto'";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxGastoCatagoria.ValueMember = "nombre";
                        comboBoxGastoCatagoria.DisplayMember = "nombre";
                        comboBoxGastoCatagoria.DataSource = dt;
                    }
                }
            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo


        }
        public void cargarCategoriaEntrada()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre,descripcion,entradaOgasto FROM easyerp.tipo_gasto_entrada WHERE entradaOgasto = 'entrada'";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxCategoriaEntrada.ValueMember = "nombre";
                        comboBoxCategoriaEntrada.DisplayMember = "nombre";
                        comboBoxCategoriaEntrada.DataSource = dt;
                    }
                }
            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo


        }
        public void cargarCiudadesGastos()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labeCard.Text + "";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxGastoAlmacen.ValueMember = "cc";
                        comboBoxGastoAlmacen.DisplayMember = "almacen_fabrica_nombre";
                        comboBoxGastoAlmacen.DataSource = dt;
                    }
                }

            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo

        }
        public void cargarCiudadesEntradas()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labeCard.Text + "";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxAlmacenEntrada.ValueMember = "cc";
                        comboBoxAlmacenEntrada.DisplayMember = "almacen_fabrica_nombre";
                        comboBoxAlmacenEntrada.DataSource = dt;
                    }
                }
            }
            catch
            {

            }
            //carga las ciudades en un combo box importantisimo


        }

        public void cargarCiudadesPermisosAlamacen()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection(a))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.almacen_fabrica";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxUsuPerAlm.ValueMember = "nombre";
                        comboBoxUsuPerAlm.DisplayMember = "nombre";
                        comboBoxUsuPerAlm.DataSource = dt;
                    }
                }
            }
            catch
            {

            }


        }

        public void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaVentajas();


        }
        public void cargaTablaPermisosPorAlmacen()
        {

            try
            {
                
               
                comboBoxUsuPerAlm.Text = DataGridPermitsPerStore.CurrentRow.Cells[0].Value.ToString();
                comboBoxCedulaPermiAlmace.Text = DataGridPermitsPerStore.CurrentRow.Cells[1].Value.ToString();
                
            }
            catch
            {
                
         
                
            }

        }

        public void cargarDatosTablaUsuario()
        {

            try
            {
                //Cargando los datos cuando doy clic en datagridview                           
                TextboxCard.Text = DataGridUser.CurrentRow.Cells[0].Value.ToString();
                TextboxUsuario.Text = DataGridUser.CurrentRow.Cells[1].Value.ToString();
                TextboxContrasena.Text = DataGridUser.CurrentRow.Cells[2].Value.ToString();
                TextboxCorreo.Text = DataGridUser.CurrentRow.Cells[3].Value.ToString();
                TextboxNombre.Text = DataGridUser.CurrentRow.Cells[4].Value.ToString();
                comboBoxUsuarioPermisos.Text= DataGridUser.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }

        }

        public void cargarDatosTablaVentajas()
        {

            try
            {
                textCode.Text = textProduct.Text = labelMessageEnd.CurrentRow.Cells[0].Value.ToString();
                textReference.Text = labelMessageEnd.CurrentRow.Cells[1].Value.ToString();
                textProduct.Text = labelMessageEnd.CurrentRow.Cells[2].Value.ToString();
                textSize.Text = labelMessageEnd.CurrentRow.Cells[3].Value.ToString();
                textQuantity.Text = labelMessageEnd.CurrentRow.Cells[4].Value.ToString();
                textPrecio.Text = labelMessageEnd.CurrentRow.Cells[5].Value.ToString();
                textTotal.Text = labelMessageEnd.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }

        }

        public void bunifuEliminar_Click(object sender, EventArgs e)
        {
           
        }

        public void limpitarTextosVentas()
        {

            textCode.Text = "";
            textReference.Text = "";
            textProduct.Text = "";
            textSize.Text = "";
            textQuantity.Text = "";
            textPrecio.Text = "";
            textTotal.Text = "";
        }

        public void buniActualizar_Click(object sender, EventArgs e)
        {

            

        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;
        public void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        public void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        public void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point df = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(df));
            }
        }

        public void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            /*
            if ( this.Size == new Size(240, 637))
            {
                this.Size = new Size(1339, 637);
            }
            else
            {
                this.Size = new Size(240, 637);
            }
            */
        }

        public void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void comboBox1_TextChanged(object sender, EventArgs e)
        {
            labelAlmacen.Text = comboBoxCiudad.Text;
            if (yainicio == 1)
            {
                buscarFactura();
                iniciarTablaVentas("");
                sumaTotal();
                
            }
           


        }
        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void agregarUsuario()
        {
            try
            {
               
                cargarPermisosPorAlmacen();
                bool todoEstaBien = comprobarDatosUsuario();
                if (todoEstaBien == true)
                {
                    cerrarConeccion();
                    string insertarCodigo = "INSERT INTO easyerp.usuario (`cc`, `id`, `contrasena`, `correo`, `nombre`, `permisos`) VALUES (" +
                        "'" +
                        TextboxCard.Text + "', '" +
                        TextboxUsuario.Text + "', '" +
                        TextboxContrasena.Text + "', '" +
                        TextboxCorreo.Text + "', '" +
                        TextboxNombre.Text + "', '" +
                        comboBoxUsuarioPermisos.Text + "')";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    if (command.ExecuteNonQuery() == 1) {    /*  MessageBox.Show( "encontre la factura"); */ } else {/*  MessageBox.Show(   "no encontre la factura"); */ }
                    cerrarConeccion();
                    iniciarTablaUsuarios();
                }
                else
                {

                }

            }
            catch (Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("Duplicate");
                if (valor >= 0) { MessageBox.Show("Ya existe un usuario con esa cedula o usuario"); }
                else
                {
                    MessageBox.Show(error.Message + "Permisos por almacen cargando texbox");
                }

            }
        }

        public bool comprobarDatosUsuario()
        {
            //con el @ se quita el problema de salida desconocida
            bool verificarEmail = bien_escrito(TextboxCorreo.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (verificarEmail == true) { LabelUMail.Text = "correo"; } else { LabelUMail.Text = "correo (verifique que este bien escrito)"; };

            bool verificarNombre = bien_escrito(TextboxNombre.Text, "[a-zA-ZñÑ\\s]{2,50}");
            if (verificarNombre == true) { LabelUName.Text = "nombre"; } else { LabelUName.Text = "nombre (verifique que este bien escrito)"; };

            bool verificarCedula = bien_escrito(TextboxCard.Text, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
            if (verificarCedula == true) { LabelUCard.Text = "cédula"; } else { LabelUCard.Text = "cédula(verifique que este bien escrito)"; };

            if (verificarCedula == true && verificarNombre == true && verificarEmail == true)
            {
               
                buttonAddUser.Visible = true;
                buttonDeletUser.Visible = true;
                buttonModifyUser.Visible = true;
               
                return true;
            }
            else
            {
                buttonAddUser.Visible = false;
                buttonDeletUser.Visible = false;
                buttonModifyUser.Visible = false;
                return false;
            }
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

        public void bunifuTextbox12_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        public void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        public void TextboxNombre_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }


        public void ButtonUsuarioCargar_Click(object sender, EventArgs e)
        {
            
        }

        public void iniciarTablaUsuarios()
        {
            try
            {
                cargarPermisosPorAlmacen();
                cerrarConeccion();
                //string selectQuery = "select * FROM easyerp.detalle_facturacov where factura_movimiento_nf="+textFactura.Text;
                string selectQuery = "SELECT * FROM easyerp.usuario ORDER BY `cc` DESC";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridUser.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Error cuando se inicia la tabla de usuarios");
            }
        }

        public void iniciarTablaPermisosAlmacen()
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "SELECT * FROM easyerp.usuario_almacen";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridPermitsPerStore.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Error cuando se incia la tabla de permisos por almacen");
            }
        }

        public void TextboxContrasena_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        public void TextboxCorreo_OnTextChange(object sender, EventArgs e)
        {
            comprobarDatosUsuario();
        }

        public void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        public void bunifuCustomDataGrid2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaUsuario();
        }

        public void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaUsuario();
        }

        public void ButtonUsuarioEliminar_Click(object sender, EventArgs e)
        {

            

        }

        public void ButtonUsuarioModificar_Click(object sender, EventArgs e)
        {
           
        }

        public void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        public void ButtonAgregarPeAl_Click(object sender, EventArgs e)
        {
           

        }

        public void ButtonCargarPeAl_Click(object sender, EventArgs e)
        {
            iniciarTablaPermisosAlmacen();
        }

        public void ButtonCargarPeAl_Click_1(object sender, EventArgs e)
        {
            
        }

        public void funciona()
        {
            MessageBox.Show("hola");
        }
        public void cargarPermisosPorUsuario()
        {
            //
            try
            {
                cerrarConeccion();

                string selectQuery = "SELECT `almacen_fabrica_nombre` as 'nombre del almacen', `cc` 'cedula del usuario' FROM easyerp.usuario_almacen";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridPermitsPerStore.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "iniciando persisos de usario al cargar");
            }
        }


        public void bunifuCustomDataGrid4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaTablaPermisosPorAlmacen();
        }

        public void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        public void cargarProductosTabla()
        {
            try
            {
                cerrarConeccion();

                string selectQuery = "SELECT `id`, `codigo`, `nombre`, `referencia`, `precioDetal` as 'precio por detal', `percioMayor` as 'precio por mayor', `costo`, `cantidad`, `tieneIva`, `inventario_fecha` as 'fecha del inventario', `departamento_nombre` as 'departamento', `almacen_fabrica_nombre` as 'almacen', `tamano_nombre` as 'tamaño' FROM easyerp.producto ";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridProductos.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "cargando datos de productos");
            }
        }

        public void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            cargarTablaAlmacenes();
        }

        public void cargarTablaAlmacenes()
        {
            try
            {
                cerrarConeccion();

                string selectQuery = "SELECT `nombre`, `descripcion`, `tipo_almacen_nombre` as 'nombre del almacen' FROM easyerp.almacen_fabrica";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridAlmacen.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Data grid view almacen");
            }
        }

        public void ButtonEliminarPeAl_Click(object sender, EventArgs e)
        {
            
        }

        public void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            

        }

        public void ButtonEliminarAlmacen(object sender, EventArgs e)
        {
           
        }

        public void DataGridAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void DataGridAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaTablaPermisosPorAlmacen();
        }

        public void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
     
        }

        public void DataGridPermisosPorAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaTablaPermisosPorAlmacen();
        }

        public void cargarTablaDepartamentos(object sender, EventArgs e)
        {

        }



        public void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            cargarTablaDepartamentos();
        }

        public void cargarTablaDepartamentos()
        {

        }

        public void ButtonCargarDepartamento_Click(object sender, EventArgs e)
        {
            CargarDepartamentosTabla();
        }

        public void CargarDepartamentosTabla()
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "SELECT `nombre`, `descripcion` FROM easyerp.departamento";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridDepartamento.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "iniciando departamentos al cargar");
            }
        }

        public void cargarTamano_Click(object sender, EventArgs e)
        {
            cargarTablaTamano();
            cargarComboboxes();
        }

        public void cargarTablaTamano()
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "SELECT `nombre`, `descripcion` FROM easyerp.tamano";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridTamano.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "iniciando tamaños al cargar");
            }
        }

        public void cargarDepartamenosTabla_click(object sender, EventArgs e)
        {
            insertarDatos("INSERT INTO easyerp.departamento (`nombre`, `descripcion`) VALUES ('" + TextboxDepartamentoNombre.text + "','" + TextboxDescripcionDepartamento.text + "')");
            CargarDepartamentosTabla();
            cargarComboboxes();
        }

        public void insertarDatos(String insertarCodigo)
        {
            try
            {
                cerrarConeccion();
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1) {     /* essageBox.Show("encontre la factura"); */ } else { /* MessageBox.Show("no encontre la factura"); */}
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

        public void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            insertarDatos("INSERT INTO easyerp.tamano (`nombre`, `descripcion`) VALUES ('" + TextboxTamañoNombre.text + "','" + TextboxDescripcionTamano.text + "')");
            cargarTablaTamano();
            cargarComboboxes();
        }

        public void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            eliminarDatos("DELETE FROM easyerp.departamento WHERE nombre='" + TextboxDepartamentoNombre.text + "'");
            CargarDepartamentosTabla();
            cargarComboboxes();
        }

        public void eliminarDatos(String insertarCodigo)
        {
            cerrarConeccion();
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar esto'?", "Eliminar:'", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    if (command.ExecuteNonQuery() == 1) { } else { }
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    String mensaje = Convert.ToString(error.Message);
                    int valor = mensaje.LastIndexOf("La cadena");
                    if (valor >= 0)
                    { }
                    else
                    {
                        MessageBox.Show(error.Message + "en eliminando");
                    }
                    cerrarConeccion();

                }
            }

        }

        public void DataGridDepartamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            eliminarDatos("DELETE FROM easyerp.tamano WHERE nombre='" + TextboxTamañoNombre.text + "'");
            cargarTablaTamano();
            cargarComboboxes();
        }

        public void DataGridTamano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

            actualizarDatos("UPDATE easyerp.departamento SET `descripcion`= '" + TextboxDescripcionDepartamento.text + "' WHERE nombre = '" + TextboxDepartamentoNombre.text + "'");
            CargarDepartamentosTabla();
            cargarComboboxes();

        }

        public void actualizarDatos(String insertarCodigo)
        {
            try
            {
                cerrarConeccion();
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1) { } else { }
                cerrarConeccion();
            }
            catch
            {
                cerrarConeccion();
            }
            conectar.Close();
        }
       
        public void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            actualizarDatos("UPDATE easyerp.tamano SET `descripcion`= '" + TextboxDescripcionTamano.text + "' WHERE nombre = '" + TextboxTamañoNombre.text + "'");
            cargarTablaTamano();
            cargarComboboxes();
        }

      

        public void DataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarProductosconClick();
        }

        public void CargarProductosconClick()
        {
            try
            {
                labelProductoId.Text = DataGridProductos.CurrentRow.Cells[0].Value.ToString();
                TextboxCodeProduct2.text = DataGridProductos.CurrentRow.Cells[1].Value.ToString();
                TextboxNameProduct2.text = DataGridProductos.CurrentRow.Cells[2].Value.ToString();
                TextboxReferenceProduct2.text = DataGridProductos.CurrentRow.Cells[3].Value.ToString();
                TextboxRetailProduct2.text = DataGridProductos.CurrentRow.Cells[4].Value.ToString();
                TextboxWhosaleProduct2.text = DataGridProductos.CurrentRow.Cells[5].Value.ToString();
                TextboxCostsProduct2.text = DataGridProductos.CurrentRow.Cells[6].Value.ToString();
                TextboxQuantityProduct.text = DataGridProductos.CurrentRow.Cells[7].Value.ToString();
                comboBoxTaxesProduct2.Text = DataGridProductos.CurrentRow.Cells[8].Value.ToString();
                comboBoxDateProduct2.Text = DataGridProductos.CurrentRow.Cells[9].Value.ToString();
                comboBoxDepartamentProduct2.Text = DataGridProductos.CurrentRow.Cells[10].Value.ToString();
                comboBoxStoreProduct2.Text = DataGridProductos.CurrentRow.Cells[11].Value.ToString();
                comboBoxSizeProduct2.Text = DataGridProductos.CurrentRow.Cells[12].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        public void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
          



        }

        public void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
        }

        public void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
        }

        public void modificarDatos(string insertarCodigo)
        {
            try
            {
                cerrarConeccion();
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                }
                else { }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(Convert.ToString(error));
            }
        }

        public void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void bunifuFlatButton12_Click_1(object sender, EventArgs e)
        {
            string fechaA = dateTimePickerReporteA.Value.Date.ToString("yyyy-MM-dd");
            string fechaB = dateTimePickerReporteB.Value.Date.ToString("yyyy-MM-dd");
            labelReportesLocalProducto.Text = "Local de " + labelAlmacen.Text+ " reporte de ventas organizadas por productos";

            if (dateTimePickerReporteA.Value.Date <= dateTimePickerReporteB.Value.Date)
            {

                labelErrorReporte.Visible = false;

                try
                {
                    cerrarConeccion();
                    MySqlCommand cmd10 = new MySqlCommand();
                    cmd10.CommandText = "SELECT SUM(credito) FROM easyerp.metodo_pago_detallado WHERE ciudad='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd10.CommandType = System.Data.CommandType.Text;
                    cmd10.Connection = conectar;
                    conectar.Open();
                    labelVentasCreditoLocal.Text = "Las ventas por crédito fueron:" + (Convert.ToDouble(cmd10.ExecuteScalar())).ToString("C");
                    double credito = Convert.ToDouble(cmd10.ExecuteScalar());
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd11 = new MySqlCommand();
                    cmd11.CommandText = "SELECT SUM(efectivo) FROM easyerp.metodo_pago_detallado WHERE ciudad='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd11.CommandType = System.Data.CommandType.Text;
                    cmd11.Connection = conectar;
                    conectar.Open();
                    labelEfectivoLocal.Text = "Las ventas por efectivo fueron:" + (Convert.ToDouble(cmd11.ExecuteScalar())).ToString("C");
                    double efectivo = Convert.ToDouble(cmd11.ExecuteScalar());
                    conectar.Close();

                    //
                    cerrarConeccion();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT SUM(total) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and almacen_nombre='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;
                    conectar.Open();
                    labelReporte1.Text = "las ventas fueron:" + (Convert.ToDouble(cmd.ExecuteScalar())).ToString("C");
                    double ventas = Convert.ToDouble(cmd.ExecuteScalar());
                    conectar.Close();


                    cerrarConeccion();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = "SELECT SUM(costo) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and almacen_nombre='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.Connection = conectar;
                    conectar.Open();
                    double costo = Convert.ToDouble(cmd2.ExecuteScalar());
                    conectar.Close();

                    double ganancia = ventas - costo;

                    labelReporteGanancias.Text = "Las ganancias fueron: " + (ganancia).ToString("C") + System.Environment.NewLine + "El costo es de :" + costo.ToString("C") + System.Environment.NewLine + "Que representan una utilidad de: " + Convert.ToString(Math.Round(((ganancia / costo)) * 100, 2)) + "%";

                    cerrarConeccion();
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.CommandText = "SELECT SUM(total) FROM easyerp.gastoentrada WHERE gastoOentrada ='gasto' and almacen_nombre='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd3.CommandType = System.Data.CommandType.Text;
                    cmd3.Connection = conectar;
                    conectar.Open();
                    double gasto = Convert.ToDouble(cmd3.ExecuteScalar());
                    labelReporteLocalGastos.Text = "El total de los gastos es: " + gasto.ToString("C");
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd4 = new MySqlCommand();
                    cmd4.CommandText = "SELECT SUM(total) FROM easyerp.gastoentrada WHERE gastoOentrada ='entrada' and almacen_nombre='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd4.CommandType = System.Data.CommandType.Text;
                    cmd4.Connection = conectar;
                    conectar.Open();
                    double entrada = Convert.ToDouble(cmd4.ExecuteScalar());
                    labelReporteLocalEntradas.Text = "El total de las entradas fueron: " + entrada.ToString("C");
                    conectar.Close();



                }
                catch 
                {
                    //MessageBox.Show(Convert.ToString(error));
                }

                //aquiiiiii

                //";
                try
                {

                    cerrarConeccion();
                    //parametro vendido
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo ";
                    string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo ";

                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteProducto.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 1");
                }

                try
                {
                    cerrarConeccion();
                    //parametro vendido
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costoTotal',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto ";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto";
                    string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costoTotal',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto ";

                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteDepartamento.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 2");
                }

                ///venta por cajero
                ///
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT usuario_cc as 'cajero',almacen_nombre as 'almacen', sum(total) as 'total vendido' ,sum(costo) as 'costo total',(sum(total) - sum(costo)) as 'ganancia',((sum(total)-sum(costo))/ sum(costo)) as 'ganancia porcentual' from easyerp.factura_movimiento WHERE almacen_nombre = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by usuario_cc, almacen_nombre";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteVentaCajeros.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 3");
                }

                dataGridsFormatoLocal();
            }
            else
            {

                labelErrorReporte.Text = "Verifique que las fechas esten en el orden correcto";
                labelErrorReporte.Visible = true;

            }



        }

        private void dataGridsFormatoLocal()
        {
            try
            {
                DataGridReporteProducto.Columns[5].DefaultCellStyle.Format = "$#,#";
                DataGridReporteProducto.Columns[6].DefaultCellStyle.Format = "$#,#";
                DataGridReporteProducto.Columns[7].DefaultCellStyle.Format = "$#,#";
                DataGridReporteProducto.Columns[8].DefaultCellStyle.Format = "#.##%";
                DataGridReporteDepartamento.Columns[2].DefaultCellStyle.Format = "$#,#";
                DataGridReporteDepartamento.Columns[3].DefaultCellStyle.Format = "$#,#";
                DataGridReporteDepartamento.Columns[4].DefaultCellStyle.Format = "$#,#";
                DataGridReporteDepartamento.Columns[5].DefaultCellStyle.Format = "#.##%";
                DataGridReporteVentaCajeros.Columns[2].DefaultCellStyle.Format = "$#,#";
                DataGridReporteVentaCajeros.Columns[3].DefaultCellStyle.Format = "$#,#";
                DataGridReporteVentaCajeros.Columns[4].DefaultCellStyle.Format = "$#,#";
                DataGridReporteVentaCajeros.Columns[5].DefaultCellStyle.Format = "#.##%";
            }
            catch { }


        }

        public void textSumaTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void macro1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("creando macros shulas");
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("estoy buscandote beibi");
        }

        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            string fechaA = dateTimePickerReporte2A.Value.Date.ToString("yyyy-MM-dd");
            string fechaB = dateTimePickerReporte2B.Value.Date.ToString("yyyy-MM-dd");

            if (dateTimePickerReporte2A.Value.Date <= dateTimePickerReporte2B.Value.Date)
            {

                labelErrorReporte2.Visible = false;

                try
                {
                    cerrarConeccion();
                    MySqlCommand cmd10 = new MySqlCommand();
                    cmd10.CommandText = "SELECT SUM(credito) FROM easyerp.metodo_pago_detallado WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd10.CommandType = System.Data.CommandType.Text;
                    cmd10.Connection = conectar;
                    conectar.Open();
                    labelReporteCredito2.Text = "Las ventas por crédito fueron:" + (Convert.ToDouble(cmd10.ExecuteScalar())).ToString("C");
                    double credito = Convert.ToDouble(cmd10.ExecuteScalar());
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd11 = new MySqlCommand();
                    cmd11.CommandText = "SELECT SUM(efectivo) FROM easyerp.metodo_pago_detallado WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd11.CommandType = System.Data.CommandType.Text;
                    cmd11.Connection = conectar;
                    conectar.Open();
                    labelReporteEfectivo2.Text = "Las ventas por efectivo fueron:" + (Convert.ToDouble(cmd11.ExecuteScalar())).ToString("C");
                    double efectivo = Convert.ToDouble(cmd11.ExecuteScalar());
                    conectar.Close();
                    //
                    cerrarConeccion();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT SUM(total) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;
                    conectar.Open();
                    labelReporte2.Text = "Las ventas de todos los locales fueron " + (Convert.ToDouble(cmd.ExecuteScalar())).ToString("C");
                    double ventas = Convert.ToDouble(cmd.ExecuteScalar());
                    conectar.Close();


                    cerrarConeccion();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = "SELECT SUM(costo) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.Connection = conectar;
                    conectar.Open();
                    double costo = Convert.ToDouble(cmd2.ExecuteScalar());
                    conectar.Close();
                    double ganancia = ventas - costo;

                    labelReporteGanancias2.Text = "Las ganancias de todos los locales fueron:" + (ganancia).ToString("C") +System.Environment.NewLine + "El costo fue de :" + (costo).ToString("C") + System.Environment.NewLine + "Que representan una utilidad de: " + Convert.ToString(Math.Round((((ganancia) / costo)) * 100, 2)) + "%";

                    cerrarConeccion();
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.CommandText = "SELECT SUM(total) FROM easyerp.gastoentrada WHERE gastoOentrada ='gasto' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd3.CommandType = System.Data.CommandType.Text;
                    cmd3.Connection = conectar;
                    conectar.Open();
                    double gasto = Convert.ToDouble(cmd3.ExecuteScalar());
                    labelReporteGeneralGastos.Text = "El total de los gastos es: " + gasto.ToString("C");
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd4 = new MySqlCommand();
                    cmd4.CommandText = "SELECT SUM(total) FROM easyerp.gastoentrada WHERE gastoOentrada ='entrada' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd4.CommandType = System.Data.CommandType.Text;
                    cmd4.Connection = conectar;
                    conectar.Open();
                    double entrada = Convert.ToDouble(cmd4.ExecuteScalar());
                    labelReporteGeneralEntradas.Text = "El total de las entradas de dinero fueron: " + entrada.ToString("C");
                    conectar.Close();

                }
                catch { }

                //aquiiiiii

                //";
                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'ventas totales',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteProducto2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 4");
                }

                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT producto as 'departamento', sum(cantidad) as 'cantidad vendida' ,sum(total) as 'venta total',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(total - costoTotal) as 'ganancia',(1-(costoTotal / total)) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteDepartamento2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 5");
                }

                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT almacen,sum(total) as 'ventas totales',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by almacen ORDER BY `detalle_facturacov`.`almacen` ASC";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(total - costoTotal) as 'ganancia',(1-(costoTotal / total)) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteVentasAlmacen2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "data grid ventas por almacenes");
                }

                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT almacen,codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo, almacen ORDER BY `detalle_facturacov`.`almacen` ASC";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(total - costoTotal) as 'ganancia',(1-(costoTotal / total)) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteProductosAlmacen2.DataSource = table;
                    cerrarConeccion();
                }
                //// venta por cajero
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "data grid ventas por productos de cada almacenes");
                }
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT usuario_cc as 'cajero',almacen_nombre as 'almacen', sum(total) as 'total vendido' ,(sum(total) - sum(costo)) as 'ganancia',sum(costo) as 'costo',((sum(total)-sum(costo)) / sum(costo)) as 'ganancia porcentual' from easyerp.factura_movimiento WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by usuario_cc, almacen_nombre";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteVentaCajeros2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes 6");
                }

                //venta por departamento de cada almacen
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT almacen,producto as 'departamento', sum(cantidad) as 'cantidad vendida' ,sum(total) as 'venta total',(sum(total) - sum(costoTotal)) as 'ganancia',sum(costoTotal) as 'costo total',((sum(total)-sum(costoTotal)) /(sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto,almacen ORDER BY almacen DESC, `cantidad vendida` DESC";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteDepartamentoAlmacen2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrid reportes venta por departamento de cada almacen");
                }
                // chart ventas por día
                try
                {
                    int contador = 0;
                    cerrarConeccion();
                    abrirConeccion();
                    MySqlCommand cmd = conectar.CreateCommand();
                    cmd.CommandText = "SELECT fecha,SUM(total) as 'totalpordia' from easyerp.factura_movimiento GROUP BY day(fecha)";
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contador++;
                        //chart1.Series["ventas"].Label = (reader.GetDouble("totalpordia").ToString("C"));
                        chartVentasPorDiaReporte.Series["ventas"].Points.AddXY(contador, reader.GetDouble("totalpordia"));

                    }
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show("error en las graficas " + Convert.ToString(error));
                    cerrarConeccion();
                }
                try
                {
                    int contador = 0;
                    cerrarConeccion();
                    abrirConeccion();
                    MySqlCommand cmd = conectar.CreateCommand();
                    cmd.CommandText = "SELECT fecha,SUM(costo) as 'costo' from easyerp.factura_movimiento GROUP BY day(fecha)";
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contador++;
                        //chart1.Series["ventas"].Label = (reader.GetDouble("totalpordia").ToString("C"));
                        chartVentasPorDiaReporte.Series["costos"].Points.AddXY(contador, reader.GetDouble("costo"));

                    }
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show("error en las graficas " + Convert.ToString(error));
                    cerrarConeccion();
                }
                try
                {
                    int contador = 0;
                    cerrarConeccion();
                    abrirConeccion();
                    MySqlCommand cmd = conectar.CreateCommand();
                    cmd.CommandText = "SELECT fecha,(SUM(total)-SUM(costo)) as 'ganancia' from easyerp.factura_movimiento GROUP BY day(fecha)";
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contador++;
                        //chart1.Series["ventas"].Label = (reader.GetDouble("totalpordia").ToString("C"));
                        chartVentasPorDiaReporte.Series["ganancias"].Points.AddXY(contador, reader.GetDouble("ganancia"));

                    }
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show("error en las graficas " + Convert.ToString(error));
                    cerrarConeccion();
                }

                //ventas por dia filtrado pro almacenes
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT fecha,almacen_nombre as 'nombre del almacen',SUM(total) as 'total por día',SUM(costo) as 'costo',(sum(total)-sum(costo)) as 'ganancia',((sum(total)-sum(costo))/sum(costo)) as 'ganancia porcentual' from easyerp.factura_movimiento GROUP BY day(fecha),almacen_nombre";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteVentaDia2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "ventas por día reporte 2");
                }
                //Ventas por día 
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT fecha,SUM(total) as 'total por día',SUM(costo) as 'costo',(sum(total)-sum(costo)) as 'ganancia',((sum(total)-sum(costo))/sum(costo)) as 'ganancia porcentual' from easyerp.factura_movimiento GROUP BY day(fecha)";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteVentaDiaR2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "ventas por día reporte 2");
                }
                formatoDataGridReport2();
            }
            else
            {

                labelErrorReporte2.Text = "Verifique que las fechas esten en el orden correcto";
                labelErrorReporte2.Visible = true;
            }

        }

        private void formatoDataGridReport2()
        {
            try
            {
                DataGridReporteProducto2.Columns[5].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteProducto2.Columns[6].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteProducto2.Columns[7].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteProducto2.Columns[8].DefaultCellStyle.Format = "#.##%";
                DataGridReporteDepartamento2.Columns[2].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamento2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamento2.Columns[4].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamento2.Columns[5].DefaultCellStyle.Format = "#.##%";
                DataGridReporteVentasAlmacen2.Columns[1].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentasAlmacen2.Columns[2].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentasAlmacen2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentasAlmacen2.Columns[4].DefaultCellStyle.Format = "#.##%";                
                DataGridReporteProductosAlmacen2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[6].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteProductosAlmacen2.Columns[7].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteProductosAlmacen2.Columns[8].DefaultCellStyle.Format = "#.##%";
                DataGridReporteDepartamentoAlmacen2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamentoAlmacen2.Columns[4].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamentoAlmacen2.Columns[5].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteDepartamentoAlmacen2.Columns[6].DefaultCellStyle.Format = "#.##%";
                DataGridReporteVentaCajeros2.Columns[2].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaCajeros2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaCajeros2.Columns[4].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaCajeros2.Columns[5].DefaultCellStyle.Format = "#.##%";
                DataGridReporteVentaDia2.Columns[1].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDia2.Columns[2].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDia2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDia2.Columns[4].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDia2.Columns[5].DefaultCellStyle.Format = "#.##%";
                DataGridReporteVentaDiaR2.Columns[1].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDiaR2.Columns[2].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDiaR2.Columns[3].DefaultCellStyle.Format = "$ #,#";
                DataGridReporteVentaDiaR2.Columns[4].DefaultCellStyle.Format = "#.##%";
            }
            catch(Exception errro)
            {
                MessageBox.Show(Convert.ToString(errro));
            }

        }
        private void DataGridReporteVentasAlmacen2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void bunifuFlatButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string fechaA = dateTimePickerReporteA.Value.Date.ToString("yyyy-MM-dd");
                string fechaB = dateTimePickerReporteB.Value.Date.ToString("yyyy-MM-dd");

                MessageBox.Show(fechaA);
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        private void bunifuFlatButton12_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton12_Click_3(object sender, EventArgs e)
        {

        }

        private void dateTimePickerReporte2A_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerReporte2B_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //chart1.Series["ventas"].ChartType = ColumnStyle;
        }

        private void bunifuFlatButton22_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextboxGastosDescripcion_OnTextChange(object sender, EventArgs e)
        {
            /*
            try
            {
                LabelIdGastos.Text = DataGridGastos.CurrentRow.Cells[0].Value.ToString();
                TextboxDescripcionAlmacen.text = DataGridGastos.CurrentRow.Cells[1].Value.ToString();
                comboBoxTipoAlmacen.Text = DataGridGastos.CurrentRow.Cells[2].Value.ToString();
                LabelFechaGastos.Text = DataGridGastos.CurrentRow.Cells[3].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
            */
        }
        public void cargarTablaGastos(string gastoEntrada)
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "";
                if (gastoEntrada == "gasto")
                {
                    selectQuery = "SELECT id,total as 'total',fecha,descripcion,usuario_cc as 'cedula',almacen_nombre as 'almacen',categoria FROM easyerp.gastoentrada WHERE gastoOentrada ='" + gastoEntrada + "' and almacen_nombre='" + comboBoxGastoAlmacen.Text + "'";
                }
                else
                {
                    selectQuery = "SELECT id,total as 'total',fecha,descripcion,usuario_cc as 'cedula',almacen_nombre as 'almacen',categoria FROM easyerp.gastoentrada WHERE gastoOentrada ='" + gastoEntrada + "' and almacen_nombre='" + comboBoxAlmacenEntrada.Text + "'";
                }
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                if (gastoEntrada == "gasto") { DataGridGastos.DataSource = table; } else { DataGridEntrada.DataSource = table; }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Data grid view gastos");
            }
        }
        public void cargarTablaTipoGastos(string entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "SELECT nombre,descripcion FROM easyerp.tipo_gasto_entrada WHERE entradaOgasto ='" + entradaGasto + "'";

                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                if (entradaGasto == "gasto") { DataGridTipoGasto.DataSource = table; } else if (entradaGasto == "entrada") { DataGridTipoEntrada.DataSource = table; }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Data grid view tipo gastos");
            }
        }

        private void DataGridGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void idGasto()
        {
            try
            {
                if (DataGridGastos.Rows.Count == 0 || DataGridGastos.Rows.Count == 1)
                {

                }
                else
                {
                    LabelIdGastos.Text = DataGridGastos.CurrentRow.Cells[0].Value.ToString();
                    TextboxGatosTotal.Text = DataGridGastos.CurrentRow.Cells[1].Value.ToString();
                    LabelFechaGastos.Text = DataGridGastos.CurrentRow.Cells[2].Value.ToString();
                    TextboxGastosDescripcion.Text = DataGridGastos.CurrentRow.Cells[3].Value.ToString();

                    comboBoxGastoAlmacen.Text = DataGridGastos.CurrentRow.Cells[5].Value.ToString();
                    comboBoxGastoCatagoria.Text = DataGridGastos.CurrentRow.Cells[6].Value.ToString();
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        private void DataGridGastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gasto_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton21_Click_1(object sender, EventArgs e)
        {
            
        }

        private void agregar(string gastoEntrada)
        {
            try
            {
                string insertarCodigo = "";
                cerrarConeccion();
                if (gastoEntrada == "gasto")
                {
                    insertarCodigo = "INSERT INTO easyerp.gastoentrada (`id`, `total`, `fecha`, `descripcion`, `usuario_cc`, `almacen_nombre`, `gastoOentrada`, `categoria`) VALUES (NULL, '" + TextboxGatosTotal.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + TextboxGastosDescripcion.Text + "', '" + labeCard.Text + "', '" + comboBoxGastoAlmacen.Text + "', '" + gastoEntrada + "', '" + comboBoxGastoCatagoria.Text + "');";
                }
                else
                {
                    insertarCodigo = "INSERT INTO easyerp.gastoentrada (`id`, `total`, `fecha`, `descripcion`, `usuario_cc`, `almacen_nombre`, `gastoOentrada`, `categoria`) VALUES (NULL, '" + TextboxTotalEntrada.text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + TextboxDescipcionEntrada.text + "', '" + labeCard.Text + "', '" + comboBoxAlmacenEntrada.Text + "', '" + gastoEntrada + "', '" + comboBoxCategoriaEntrada.Text + "');";
                }

                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    cargarTablaGastos(gastoEntrada);
                }
                else
                {
                }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "gasto ingresando datos");
            }
        }

        private void ButtonEntradaGastoAgregar(object sender, EventArgs e)
        {
            agregarTipoEntradaGasto("gasto");
        }

        private void agregarTipoEntradaGasto(string entradaGasto)
        {
            try
            {
                string insertarCodigo = "";
                cerrarConeccion();

                if (entradaGasto == "gasto")
                {
                    insertarCodigo = "INSERT INTO easyerp.tipo_gasto_entrada (`nombre`, `descripcion`, `entradaOgasto`) VALUES ('" + TextboxTipoGastoNombre.text + "', '" + TextboxTipoGastoDescripcion.text + "', 'gasto');";
                }
                else
                {
                    insertarCodigo = "INSERT INTO easyerp.tipo_gasto_entrada (`nombre`, `descripcion`, `entradaOgasto`) VALUES ('" + TextboxNombreTipoEntrada.text + "', '" + TextboxDescripcionTipoEntrada.text + "', 'entrada');";
                }

                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    cargarTablaTipoGastos(entradaGasto);
                    cargarGastoDescipcion();
                }
                else
                {
                }
                cerrarConeccion();
            }
            catch
            {
                cerrarConeccion();

            }
        }

        private void buttonCargarTipoGasto(object sender, EventArgs e)
        {
            cargarTablaTipoGastos("gasto");
        }

        private void bunifuFlatButton12_Click_4(object sender, EventArgs e)
        {
           
        }

        private void eliminarEntradaGasto(String entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "";
                if (entradaGasto == "gasto")
                {
                    insertarCodigo = "DELETE FROM easyerp.gastoentrada WHERE `gastoentrada`.`id` = '" + LabelIdGastos.Text + "';";
                }
                else
                {
                    insertarCodigo = "DELETE FROM easyerp.gastoentrada WHERE `gastoentrada`.`id` = '" + LabelIdEntrada2.Text + "';";
                }
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {

                    cargarTablaGastos(entradaGasto);
                }
                else
                {
                }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "gasto borrando datos");
            }
        }

        private void bunifuFlatButton23_Click(object sender, EventArgs e)
        {
            
        }

        private void modificarEntradaGasto(string entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "";
                if (entradaGasto == "gasto")
                {
                    insertarCodigo = "UPDATE easyerp.gastoentrada SET `total` = '" + TextboxGatosTotal.Text + "', `descripcion` = '" + TextboxGastosDescripcion.Text + "', `almacen_nombre` = '" + comboBoxGastoAlmacen.Text + "', `categoria` = '" + comboBoxGastoCatagoria.Text + "' WHERE `gastoentrada`.`id` = " + LabelIdGastos.Text + "";
                }
                else
                {
                    insertarCodigo = "UPDATE easyerp.gastoentrada SET `total` = '" + TextboxTotalEntrada.text + "', `descripcion` = '" + TextboxDescipcionEntrada.text + "', `almacen_nombre` = '" + comboBoxAlmacenEntrada.Text + "', `categoria` = '" + comboBoxCategoriaEntrada.Text + "' WHERE `gastoentrada`.`id` = " + LabelIdEntrada2.Text + "";
                }

                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    cargarTablaGastos(entradaGasto);
                }
                else
                {
                }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "gasto modificando datos");
            }
        }

        private void bunifuCustomLabel21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton25_Click(object sender, EventArgs e)
        {
            eliminarTipoEntradaGasto("gasto");

        }

        private void eliminarTipoEntradaGasto(string entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "";
                if (entradaGasto == "gasto")
                {
                    insertarCodigo = "DELETE FROM easyerp.tipo_gasto_entrada WHERE `tipo_gasto_entrada`.`nombre` = '" + LabelTipoGastoNombre.Text + "'";
                }
                else if (entradaGasto == "entrada")
                {
                    insertarCodigo = "DELETE FROM easyerp.tipo_gasto_entrada WHERE `tipo_gasto_entrada`.`nombre` = '" + LabelNombreTipoEntrada.Text + "'";
                }
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {

                    cargarTablaTipoGastos(entradaGasto);
                    cargarGastoDescipcion();
                }
                else
                {
                }

                cerrarConeccion();
            }
            catch
            {
                cerrarConeccion();
                //MessageBox.Show(error.Message + "gasto borrando datos tipo de gastos");
            }
        }

        private void DataGridTipoGasto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridTipoGasto_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DataGridTipoGasto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextboxTipoGastoNombre_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void bunifuFlatButton31_Click(object sender, EventArgs e)
        {
            cargarTablaGastos("entrada");

        }

        private void bunifuFlatButton30_Click(object sender, EventArgs e)
        {
            agregar("entrada");
        }

        private void bunifuFlatButton24_Click(object sender, EventArgs e)
        {
            modificarTipoGasto("gasto");

        }

        private void modificarTipoGasto(String entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.tipo_gasto_entrada SET `descripcion` = '" + TextboxTipoGastoDescripcion.text + "' WHERE `tipo_gasto_entrada`.`entradaOgasto`= '" + entradaGasto + "' and `tipo_gasto_entrada`.`nombre` = '" + LabelTipoGastoNombre.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {

                    cargarTablaTipoGastos(entradaGasto);

                }
                else
                {
                }
                cerrarConeccion();

            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "gasto modificando datos");

            }
        }

        private void DataGridEntrada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void DataGridEntrada_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton29_Click(object sender, EventArgs e)
        {
            eliminarEntradaGasto("entrada");
        }

        private void bunifuFlatButton28_Click(object sender, EventArgs e)
        {
            modificarEntradaGasto("entrada");
        }

        private void bunifuFlatButton35_Click(object sender, EventArgs e)
        {
            cargarTablaTipoGastos("entrada");
        }

        private void bunifuFlatButton34_Click(object sender, EventArgs e)
        {
            agregarTipoEntradaGasto("entrada");
        }





        private void comboBoxGastoAlmacen_TextChanged(object sender, EventArgs e)
        {
            cargarTablaGastos("gasto");
        }

        private void comboBoxAlmacenEntrada_TextChanged(object sender, EventArgs e)
        {
            cargarTablaGastos("entrada");
        }

        private void bunifuFlatButton33_Click(object sender, EventArgs e)
        {
            eliminarTipoEntradaGasto("entrada");
        }

        private void DataGridTipoEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buscarProducto(string palabraClave, string detalMayor)
        {
            try
            {
                cerrarConeccion();
                MySqlDataReader mdr;
                string select = "SELECT * FROM easyerp.producto where codigo =" + palabraClave + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    string codigo = mdr.GetString("codigo");

                    string precioDetal = mdr.GetString("precioDetal");

                    string precioMayor = mdr.GetString("percioMayor");

                    string costo = Convert.ToString(Convert.ToDecimal(labelCosto.Text) * Convert.ToDecimal(textQuantity.Text));


                }
                else
                {
                    //MessageBox.Show("no encontrado");

                }
                cerrarConeccion();
            }
            catch
            {
            }

        }
    

        string bandera = "detal";
        private void bunifuFlatButton36_Click(object sender, EventArgs e)
        {
            string codigoProducto = "";
            string cantidadProducto;
            try
            {

                for (int cont = 0; cont < labelMessageEnd.RowCount - 1; cont++)
                {
                    codigoProducto = labelMessageEnd.Rows[cont].Cells[0].Value.ToString();
                    cantidadProducto = labelMessageEnd.Rows[cont].Cells[4].Value.ToString();
                    MessageBox.Show(codigoProducto + "la cntidad es" + cantidadProducto);
                    buscarProducto(codigoProducto, bandera);
                }
                
                
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
            
        }

        private void TextboxTipoGastoNombre_OnTextChange(object sender, EventArgs e)
        {

        }

        private void TextboxTipoGastoDescripcion_OnTextChange(object sender, EventArgs e)
        {

        }

        private void TextboxDetalProducto_OnTextChange(object sender, EventArgs e)
        {

        }

        private void DataGridReporteProductosAlmacen2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buniTextUsuario_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void buniTextUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            buniTextUser.Text = "";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void buniTextPass_MouseDown(object sender, MouseEventArgs e)
        {
            buniTextPass.Text = "";
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            logearse();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            cargarTablaGastos("gasto");
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            agregar("gasto");
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            modificarEntradaGasto("gasto");
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            eliminarEntradaGasto("gasto");
        }

        private void DataGridGastos_KeyDown(object sender, KeyEventArgs e)
        {
            idGasto();
        }

        private void DataGridGastos_KeyUp(object sender, KeyEventArgs e)
        {
            idGasto();
        }

        private void bunifuSeparator4_Load(object sender, EventArgs e)
        {

        }

        public void convertirDecimales()
        {
            try
            {
                double valor = Convert.ToDouble(textSumaTotal.Text);
                labelTotalSells.Text = "TOTAL = " + "$" + Convert.ToString(valor.ToString("0,0"));
            }
            catch
            {

            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < labelMessageEnd.Columns.Count - 1; i++)
                {
                    labelMessageEnd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                labelMessageEnd.Columns[labelMessageEnd.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < labelMessageEnd.Columns.Count; i++)
                {
                    int colw = labelMessageEnd.Columns[i].Width;
                    labelMessageEnd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    labelMessageEnd.Columns[i].Width = colw;
                }

                for (int i = 0; i < DataGridUser.Columns.Count - 1; i++)
                {
                    DataGridUser.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                DataGridUser.Columns[DataGridUser.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < DataGridUser.Columns.Count; i++)
                {
                    int colw = DataGridUser.Columns[i].Width;
                    DataGridUser.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    DataGridUser.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            //DataGridVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //tex cedula

            comprobarDatosUsuario();
        }

        private void comboBoxCedulaPermiAlmace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(TextboxCard.Text); agregarUsuario();
        }

        private void TextboxCorreo_OnValueChanged(object sender, EventArgs e)
        {

            comprobarDatosUsuario();
        }

        private void TextboxNombre_OnValueChanged(object sender, EventArgs e)
        {

            comprobarDatosUsuario();
        }

        private void tabPage26_Click(object sender, EventArgs e)
        {

        }

        private void buttonPermisosUsuario_Click(object sender, EventArgs e)
        {
            cargarPermisosUsuario();
        }

        private void cargarPermisosUsuario()
        {
            try
            {
                cargarPermisosPorAlmacen();
                cerrarConeccion();
                //string selectQuery = "select * FROM easyerp.detalle_facturacov where factura_movimiento_nf="+textFactura.Text;
                string selectQuery = "SELECT  usuario as 'Usuario',mVentas as 'Modulo de ventas',mUsuario as 'Modulo de usuarios',mUsuarioPermisosAlmacen as 'Permisos por almacen',mUsuarioPermisosUsuario as 'Permisos por usuario',mProductos as 'Productos',mProductosDepartamento as 'Productos por departamento',mProductosTamano as 'Productos por tamaño',mProductosFecha as 'Fecha de inventario',mAlmacen as 'Almacen',mReporteLocalGeneral as 'Reportes general local',mReporteLocalProducto as 'Reporte local por producto',mReporteLocalDepartamento as 'Rreporte local por departamento',mReporteLocalCajeros as 'Reporte local por cajeros',mReporteGeneral as 'Reporte general',mReporteGeneralProducto as 'Reporte general por producto',mReporteGeneralDepartamento as 'Reporte general por departamento',mReporteGeneralVentas as 'Reporte general  ventas',mReporteGeneralproductosAlmacen as 'Reporte general de productos por almacen',mReporteGeneralVentasDepartamentoAlmacen as 'Reporte general de ventas por departamento en cada almacen',mReporteGeneralVentasCajerosAlmacen as 'Reporte general ventas cajeros por almacen',mReporteGeneralGraficas as 'Reporte general por graficas',mReporteRegistroVentas as 'Reporte registros de ventas',mESentrada as 'Entradas',mEStipoEntrada as 'Tipo de entradas',mESsalida as 'Salidas',mEStipoSalida as 'Tipo de salida' FROM easyerp.permisosusuarios";

                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                bunifuCustomDataGridPermisosUsuario.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Error cuando se inicia la permisos de usuario");
            }
        }

        private void buttonPermisosUsuario_Click_1(object sender, EventArgs e)
        {
           
            cargarPermisosUsuario();            
            cargarNombresPermisosUsuario();
            cargarDatagridviews();
        }

        private void agregarPermisosUsuario()
        {
            try
            {                
                    cerrarConeccion();
                //INSERT INTO easyerp.usuario_almacen (`almacen_fabrica_nombre`, `cc`) VALUES ('"
                string insertarCodigo = "INSERT INTO easyerp.permisosusuarios (`usuario`, `descripcion`, `mVentas`, `mUsuario`, `mUsuarioPermisosAlmacen`, `mUsuarioPermisosUsuario`, `mProductos`, `mProductosDepartamento`, `mProductosTamano`, `mProductosFecha`, `mAlmacen`, `mReporteLocalGeneral`, `mReporteLocalProducto`, `mReporteLocalDepartamento`, `mReporteLocalCajeros`, `mReporteGeneral`, `mReporteGeneralProducto`, `mReporteGeneralDepartamento`, `mReporteGeneralVentas`, `mReporteGeneralproductosAlmacen`, `mReporteGeneralVentasDepartamentoAlmacen`, `mReporteGeneralVentasCajerosAlmacen`, `mReporteGeneralGraficas`, `mReporteRegistroVentas`, `mESentrada`, `mEStipoEntrada`, `mESsalida`, `mEStipoSalida`) VALUES ('" +
                        //[value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7],[value-8],[value-9],[value-10],[value-11],[value-12],[value-13],[value-14],[value-15],[value-16],[value-17],[value-18],[value-19],[value-20],[value-21],[value-22],[value-23],[value-24],[value-25],[value-26],[value-27],[value-28])" +
                        bunifuMaterialTextbox1.Text + "', '" +
                        "CAmpo de descipcion" + "', '" +
                        comboBoxPermisosUsuario1.Text + "', '" +
                        comboBoxPermisosUsuario2.Text + "', '" +
                        comboBoxPermisosUsuario3.Text + "', '" +
                        comboBoxPermisosUsuario4.Text + "', '" +
                        comboBoxPermisosUsuario5.Text + "', '" +
                        comboBoxPermisosUsuario6.Text + "', '" +
                        comboBoxPermisosUsuario7.Text + "', '" +
                        comboBoxPermisosUsuario8.Text + "', '" +
                        comboBoxPermisosUsuario9.Text + "', '" +     
                        comboBoxPermisosUsuario10.Text + "', '" +
                        comboBoxPermisosUsuario11.Text + "', '" +
                        comboBoxPermisosUsuario12.Text + "', '" +
                        comboBoxPermisosUsuario13.Text + "', '" +
                        comboBoxPermisosUsuario14.Text + "', '" +
                        comboBoxPermisosUsuario15.Text + "', '" +
                        comboBoxPermisosUsuario16.Text + "', '" +
                        comboBoxPermisosUsuario17.Text + "', '" +
                        comboBoxPermisosUsuario18.Text + "', '" +
                        comboBoxPermisosUsuario19.Text + "', '" +
                        comboBoxPermisosUsuario20.Text + "', '" +
                        comboBoxPermisosUsuario21.Text + "', '" +
                        comboBoxPermisosUsuario22.Text + "', '" +
                        comboBoxPermisosUsuario23.Text + "', '" +
                        comboBoxPermisosUsuario24.Text + "', '" +
                        comboBoxPermisosUsuario25.Text + "', '" +                      
                        comboBoxPermisosUsuario26.Text + "')";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    if (command.ExecuteNonQuery() == 1) {    /*  MessageBox.Show( "encontre la factura"); */ } else {/*  MessageBox.Show(   "no encontre la factura"); */ }
                    cerrarConeccion();
                    
               

            }
            catch (Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("Duplicate");
                if (valor >= 0) { MessageBox.Show("Ya existe un rol con este nombre"); }
                else
                {
                    MessageBox.Show(error.Message + "Permisos por usuario extendido ");
                }

            }
        }
        private void cargarNombresPermisosUsuario()
        {
            //labelPermisosUsuario0
            //comboBoxPermisosUsuario0
            //bunifuCustomDataGridPermisosUsuario
            List<Label> lst = new List<Label>();
            lst.Add(labelPermisosUsuario0);
            lst.Add(labelPermisosUsuario1);
            lst.Add(labelPermisosUsuario2);
            lst.Add(labelPermisosUsuario3);
            lst.Add(labelPermisosUsuario4);
            lst.Add(labelPermisosUsuario5);
            lst.Add(labelPermisosUsuario6);
            lst.Add(labelPermisosUsuario7);
            lst.Add(labelPermisosUsuario8);
            lst.Add(labelPermisosUsuario9);
            lst.Add(labelPermisosUsuario10);
            lst.Add(labelPermisosUsuario11);
            lst.Add(labelPermisosUsuario12);
            lst.Add(labelPermisosUsuario13);
            lst.Add(labelPermisosUsuario14);
            lst.Add(labelPermisosUsuario15);
            lst.Add(labelPermisosUsuario16);
            lst.Add(labelPermisosUsuario17);
            lst.Add(labelPermisosUsuario18);
            lst.Add(labelPermisosUsuario19);
            lst.Add(labelPermisosUsuario20);
            lst.Add(labelPermisosUsuario21);
            lst.Add(labelPermisosUsuario22);
            lst.Add(labelPermisosUsuario23);
            lst.Add(labelPermisosUsuario24);
            lst.Add(labelPermisosUsuario25);
            lst.Add(labelPermisosUsuario26);
            int cont = 0;
            foreach (Label lbl in lst)
            {


                lbl.Text = bunifuCustomDataGridPermisosUsuario.Columns[cont].HeaderText;
                cont++;


                //lbl.Text = column.HeaderText;
            }


        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {
            cargarcomboBoxUsuarioPermisos();
        }

        private void bunifuFlatButton22_Click_1(object sender, EventArgs e)
        {
            eliminarPermisos();
            cargarcomboBoxUsuarioPermisos();
            cargarcomboBoxUsuarioPermisos();

        }

        public void eliminarPermisos()
        {
            try
            {

                string insertarCodigo = "DELETE FROM easyerp.permisosusuarios WHERE usuario='" + bunifuMaterialTextbox1.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    cargarDatagridviews();
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    cerrarConeccion();

                }
                cargarPermisosPorUsuario();

            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "Elimando permisos de usario extendido");
            }
            cargarComboboxes();
            textInsertCode.Text = "";
            conectar.Close();
        }
        private void bunifuFlatButton12_Click_5(object sender, EventArgs e)
        {
            cargarcomboBoxUsuarioPermisos();
        }

        private void modificarPermisosExtendidos()
        {
            try
            {
                cargarPermisosPorAlmacen();
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.permisosusuarios SET `cc` = '" + TextboxCard.Text + "', `id` = '" + TextboxUsuario.Text + "', `contrasena` = '" + TextboxContrasena.Text + "', `correo` = '" + TextboxCorreo.Text + "', `nombre` = '" + TextboxNombre.Text + "', `permisos` = '" + comboBoxUsuarioPermisos.Text + "' WHERE `usuario`.`cc` = '" + TextboxCard.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    iniciarTablaUsuarios();
                }
                else { }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(Convert.ToString(error));
            }
        }

        private void bunifuCustomDataGridPermisosUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            colocandoPermisosDatagridview();
        }

        private void colocandoPermisosDatagridview()
        {
            try
            {
                //labelPermisosUsuario0
                //comboBoxPermisosUsuario0
                //bunifuCustomDataGridPermisosUsuario     
                bunifuMaterialTextbox1.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[0].Value.ToString();
                comboBoxPermisosUsuario1.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[1].Value.ToString();
                comboBoxPermisosUsuario2.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[2].Value.ToString();
                comboBoxPermisosUsuario3.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[3].Value.ToString();
                comboBoxPermisosUsuario4.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[4].Value.ToString();
                comboBoxPermisosUsuario5.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[5].Value.ToString();
                comboBoxPermisosUsuario6.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[6].Value.ToString();
                comboBoxPermisosUsuario7.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[7].Value.ToString();
                comboBoxPermisosUsuario8.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[8].Value.ToString();
                comboBoxPermisosUsuario9.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[9].Value.ToString();
                comboBoxPermisosUsuario10.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[10].Value.ToString();
                comboBoxPermisosUsuario11.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[11].Value.ToString();
                comboBoxPermisosUsuario12.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[12].Value.ToString();
                comboBoxPermisosUsuario13.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[13].Value.ToString();
                comboBoxPermisosUsuario14.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[14].Value.ToString();
                comboBoxPermisosUsuario15.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[15].Value.ToString();
                comboBoxPermisosUsuario16.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[16].Value.ToString();
                comboBoxPermisosUsuario17.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[17].Value.ToString();
                comboBoxPermisosUsuario18.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[18].Value.ToString();
                comboBoxPermisosUsuario19.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[19].Value.ToString();
                comboBoxPermisosUsuario20.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[20].Value.ToString();
                comboBoxPermisosUsuario21.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[21].Value.ToString();
                comboBoxPermisosUsuario22.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[22].Value.ToString();
                comboBoxPermisosUsuario23.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[23].Value.ToString();
                comboBoxPermisosUsuario24.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[24].Value.ToString();
                comboBoxPermisosUsuario25.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[25].Value.ToString();
                comboBoxPermisosUsuario26.Text = bunifuCustomDataGridPermisosUsuario.CurrentRow.Cells[26].Value.ToString();
          


            }
            catch
            {
                /*
                MessageBox.Show(Convert.ToString(error));
                */
            }
        }

        private void bunifuCustomDataGridPermisosUsuario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            colocandoPermisosDatagridview();
        }

        private void bunifuFlatButton21_Click_2(object sender, EventArgs e)
        {
            agregarPermisosUsuario();
            cargarPermisosUsuario();
        }

        private void tabPage27_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton23_Click_1(object sender, EventArgs e)
        {
            cargarTablaAlmacenes();
        }

        private void bunifuFlatButton39_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "INSERT INTO easyerp.almacen_fabrica (`nombre`, `descripcion`, `tipo_almacen_nombre`) VALUES " +
                    "(" +
                    "'" + TextboxNombreAlmacen.text + "', " +
                    "'" + TextboxDescripcionAlmacen.text + "', " +
                    "'" + comboBoxTipoAlmacen.Text + "')" +
                    ";";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    cargarTablaAlmacenes();
                    cargarCiudadesGastos();
                }
                else
                {
                }
                cargarPermisosPorAlmacen();
                cargarCiudadesPermisosAlamacen();
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "insertando datos almacen");
            }
        }

        private void bunifuFlatButton38_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "DELETE FROM easyerp.almacen_fabrica WHERE nombre ='" + TextboxNombreAlmacen.text + "' and descripcion ='" + TextboxDescripcionAlmacen.text + "' and tipo_almacen_nombre='" + comboBoxTipoAlmacen.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("eliminado con exito");
                }
                else
                {
                }
                cargarPermisosPorAlmacen();
                cargarCiudadesPermisosAlamacen();
                cargarTablaAlmacenes();
                cargarCiudadesGastos();
                cerrarConeccion();

            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "insertando datos almacen");
            }
        }

        private void bunifuFlatButton37_Click(object sender, EventArgs e)
        {
            cargarPermisosPorAlmacen();
            cargarCiudadesPermisosAlamacen();
            cargarCiudadesGastos();
        }

        private void bunifuFlatButton9_Click_1(object sender, EventArgs e)
        {
            cargarCLientesProvedores();
        }
         
        private void cargarCLientesProvedores()
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "SELECT * FROM easyerp.cliente_provedor";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridClientesProvedores.DataSource = table;
                cerrarConeccion();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "Cargando la tabla de clientes o provedores");
            }
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            //DataGridPruebas
            //SELECT * FROM `factura_movimiento`
            
        }

        private void bunifuFlatButton43_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textQuantity.Text);
                string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textInvoiceNumber.Text + " AND `detalle_facturacov`.`codigo` = " + textCode.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    aumentarInventarioTodo();
                    iniciarTablaVentas("");
                }
                else { }
                cerrarConeccion();
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
                    MessageBox.Show(error.Message + " Error al eliminar en los de talles de la factura");
                }
                cerrarConeccion();

            }
            sumaTotal();

        }

        private void bunifuFlatButton41_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt32(textQuantity.Text) > 1)
                {
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textQuantity.Text);
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad-1, total =precio*cantidad, costoTotal =costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textInvoiceNumber.Text + " AND `detalle_facturacov`.`codigo` = " + textCode.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        aumentarInventario1();
                        iniciarTablaVentas("");
                        limpitarTextosVentas();

                    }
                    else { }

                }
                else if (Convert.ToInt32(textQuantity.Text) <= 1)
                {
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textQuantity.Text);
                    string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textInvoiceNumber.Text + " AND `detalle_facturacov`.`codigo` = " + textCode.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        aumentarInventario1();
                        iniciarTablaVentas("");
                        limpitarTextosVentas();
                    }
                    else { }
                }
                else { }
                sumaTotal();
                iniciarTablaVentas("");
            }
            catch (Exception error)
            {
                String mensaje = Convert.ToString(error.Message);
                int valor = mensaje.LastIndexOf("La cadena");
                if (valor >= 0) { }
                else
                {
                    MessageBox.Show(error.Message + "update o restando");
                }
                cerrarConeccion();

            }




            /* codigo para acceder a todos los controles al mismo tiempo sera util en un fútoro proximo
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Enabled = false;
            }
            */
        }

        private void buttonModificarVentas_Click(object sender, EventArgs e)
        {
            if (textCode.Text == "")
            { }
            else
            {
                try
                {
                    double total = Convert.ToDouble(textQuantity.Text) * Convert.ToDouble(textPrecio.Text);

                    //MessageBox.Show(Convert.ToString(total));
                    //string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET precio =" + textPrecio.Text + ", total =precio*cantidad, costoTotal=costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad=" + textQuantity.Text + ", precio =" + textPrecio.Text + ", total =" + total + ", costoTotal=costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textInvoiceNumber.Text + " AND `detalle_facturacov`.`codigo` = " + textCode.Text + " and almacen='" + comboBoxCiudad.Text + "'";

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
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                }

            }
        }

        private void butttonFinalizarVentas_Click(object sender, EventArgs e)
        {
            if (textSumaTotal.Text == ""){}
            else
            {
                facturaVendida();
                Form2 formulario2 = new Form2(textSumaTotal.Text, Convert.ToString(textInvoiceNumber.Text), comboBoxCiudad.Text);
                //formulario2.Visible = true;   
                
                finalizarCerrarFactura();
                formulario2.ShowDialog();
              
                convertirDecimales();

                /*
                DialogResult result = MessageBox.Show("Lo que esta realizando es una venta", "Salir", MessageBoxButtons.YesNo);
              switch (result)
              {
                  case DialogResult.Yes:


                      break;
                  case DialogResult.No:
                      break;
              }

              */
            }
        }

        private void DataGridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaVentajas();
        }

        private void DataGridVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaVentajas();
        }

     

        private void textInsertarCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textInsertarCodigo_TextChanged_1(object sender, EventArgs e)
        {
            codigoCambia();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton6_Click_2(object sender, EventArgs e)
        {

        }

        private void DataGridPermisosPorAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridPermisosPorAlmacen_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargaTablaPermisosPorAlmacen();
        }

        private void DataGridProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CargarProductosconClick();
        }

        private void bunifuCustomDataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosTablaUsuario();
        }

        private void DataGridDepartamento_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargarTableDepartamentoClickDataGridView();
        }

        private void cargarTableDepartamentoClickDataGridView()
        {
            try
            {
                TextboxDepartamentoNombre.text = DataGridDepartamento.CurrentRow.Cells[0].Value.ToString();
                TextboxDescripcionDepartamento.text = DataGridDepartamento.CurrentRow.Cells[1].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        private void DataGridTamano_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextboxTamañoNombre.text = DataGridTamano.CurrentRow.Cells[0].Value.ToString();
                TextboxDescripcionTamano.text = DataGridTamano.CurrentRow.Cells[1].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        private void DataGridAlmacen_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextboxNombreAlmacen.text = DataGridAlmacen.CurrentRow.Cells[0].Value.ToString();
                TextboxDescripcionAlmacen.text = DataGridAlmacen.CurrentRow.Cells[1].Value.ToString();
                comboBoxTipoAlmacen.Text = DataGridAlmacen.CurrentRow.Cells[2].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        private void DataGridEntrada_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LabelIdEntrada2.Text = DataGridEntrada.CurrentRow.Cells[0].Value.ToString();
                TextboxTotalEntrada.text = DataGridEntrada.CurrentRow.Cells[1].Value.ToString();
                LabelFechaEntrada2.Text = DataGridEntrada.CurrentRow.Cells[2].Value.ToString();
                TextboxDescipcionEntrada.text = DataGridEntrada.CurrentRow.Cells[3].Value.ToString();
                //comboBoxAlmacenEntrada.Text = DataGridGastos.CurrentRow.Cells[5].Value.ToString();
                //comboBoxCategoriaEntrada.Text = DataGridGastos.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void DataGridTipoEntrada_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LabelNombreTipoEntrada.Text = DataGridTipoEntrada.CurrentRow.Cells[0].Value.ToString();
                TextboxDescripcionTipoEntrada.text = DataGridTipoEntrada.CurrentRow.Cells[1].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos tipo de gastos");
            }
        }

        private void DataGridGastos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            idGasto();
        }

        private void DataGridTipoGasto_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextboxTipoGastoNombre.Text = "asdasdas";
                LabelTipoGastoNombre.Text = DataGridTipoGasto.CurrentRow.Cells[0].Value.ToString();
                TextboxTipoGastoDescripcion.text = DataGridTipoGasto.CurrentRow.Cells[1].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos tipo de gastos");
            }
        }

        //I could not understand the language at all. =(, could you make in english i can do the translate
        //Ok, let me have a look again.

        private void DataGridClientesProvedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                clienteCedulaText.Text = DataGridClientesProvedores.CurrentRow.Cells[0].Value.ToString();
                clienteCorreoText.Text = DataGridClientesProvedores.CurrentRow.Cells[1].Value.ToString();
                clienteCelularText.Text = DataGridClientesProvedores.CurrentRow.Cells[2].Value.ToString();
                clienteNombreText.Text = DataGridClientesProvedores.CurrentRow.Cells[3].Value.ToString();
                clienteGeneroText.Text = DataGridClientesProvedores.CurrentRow.Cells[4].Value.ToString();
                clienteEdadText.Text = DataGridClientesProvedores.CurrentRow.Cells[5].Value.ToString();
                clienteTipoPersonaCombobox.Text = DataGridClientesProvedores.CurrentRow.Cells[6].Value.ToString();
                cientePuntosText.Text = DataGridClientesProvedores.CurrentRow.Cells[7].Value.ToString();
                cienteMayoristaCombobox.Text = DataGridClientesProvedores.CurrentRow.Cells[8].Value.ToString();
            }
            catch
            {

            }
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            iniciarTablaUsuarios();
        }

        private void bunifuFlatButton41_Click_1(object sender, EventArgs e)
        {
            agregarUsuario();
        }

        private void bunifuFlatButton42_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a este usuario?: '" + TextboxUsuario.Text + "'?", "Eliminar usuario: '" + TextboxNombre.Text + "'", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                try
                {
                    cargarPermisosPorAlmacen();
                    cerrarConeccion();
                    string insertarCodigo = "DELETE FROM easyerp.usuario WHERE cc =" + TextboxCard.Text;
                    conectar.Open();
                    MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        iniciarTablaUsuarios();

                    }
                    else { }
                    cerrarConeccion();

                }
                catch (Exception error)
                {
                    String mensaje = Convert.ToString(error.Message);
                    int valor = mensaje.LastIndexOf("La cadena");
                    if (valor >= 0)
                    { }
                    else
                    {
                        MessageBox.Show(error.Message + "en eliminando");
                    }
                    cerrarConeccion();

                }
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void bunifuFlatButton43_Click_1(object sender, EventArgs e)
        {
            try
            {
                cargarPermisosPorAlmacen();
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.usuario SET `cc` = '" + TextboxCard.Text + "', `id` = '" + TextboxUsuario.Text + "', `contrasena` = '" + TextboxContrasena.Text + "', `correo` = '" + TextboxCorreo.Text + "', `nombre` = '" + TextboxNombre.Text + "', `permisos` = '" + comboBoxUsuarioPermisos.Text + "' WHERE `usuario`.`cc` = '" + TextboxCard.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    iniciarTablaUsuarios();
                }
                else { }
                cerrarConeccion();
            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(Convert.ToString(error));
            }
        }

        private void buttonLoadUserPermitsStore_Click(object sender, EventArgs e)
        {
            cargarPermisosPorUsuario();
        }

        private void buttonAddUserPermitsStore_Click(object sender, EventArgs e)
        {
            //INSERT INTO `usuario_almacen` (`almacen_fabrica_nombre`, `cc`) VALUES ('girardot', '1069178680');

            try
            {
                string insertarCodigo = "UPDATE easyerp.usuario_almacen SET `almacen_fabrica_nombre`=almacen_fabrica_nombre WHERE almacen_fabrica_nombre='" + comboBoxUsuPerAlm.Text + "' and cc = '" + comboBoxCedulaPermiAlmace.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ya existe este registro");
                }
                else
                {
                    cerrarConeccion();
                    string insertarCodigo2 = "INSERT INTO easyerp.usuario_almacen (`almacen_fabrica_nombre`, `cc`) VALUES ('" + comboBoxUsuPerAlm.Text + "', '" + comboBoxCedulaPermiAlmace.Text + "')";
                    conectar.Open();
                    MySqlCommand command2 = new MySqlCommand(insertarCodigo2, conectar);
                    if (command2.ExecuteNonQuery() == 1)
                    {
                        cargarPermisosPorAlmacen();
                        //MessageBox.Show("Dato insertado");
                        cerrarConeccion();
                    }
                    else
                    {
                        MessageBox.Show("Dato NO insertado");
                        cerrarConeccion();
                    }
                    cerrarConeccion();
                    cargarPermisosPorUsuario();
                    cargarComboboxes();
                }

            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + " Error agregando permisos de usario por almacen");
            }
            textInsertCode.Text = "";
            conectar.Close();

        }

        private void buttonDeleteUserPermitsStore_Click(object sender, EventArgs e)
        {
            try
            {

                string insertarCodigo = "DELETE FROM easyerp.usuario_almacen WHERE almacen_fabrica_nombre='" + comboBoxUsuPerAlm.Text + "' and cc='" + comboBoxCedulaPermiAlmace.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    cerrarConeccion();

                }
                cargarPermisosPorUsuario();

            }
            catch (Exception error)
            {
                cerrarConeccion();
                MessageBox.Show(error.Message + "agregando permisos de usario por almacen");
            }
            cargarComboboxes();
            textInsertCode.Text = "";
            conectar.Close();
        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = "Main page";
            tabControl1.TabPages[1].Text = "Wenas";
            tabControl1.TabPages[2].Text = "Wenas";
            tabControl1.TabPages[3].Text = "Wenas";
            tabControl1.TabPages[4].Text = "Wenas";
            tabControl1.TabPages[5].Text = "Wenas";
            tabControl1.TabPages[6].Text = "Wenas";
            tabControl1.TabPages[7].Text = "Wenas";
            tabControl1.TabPages[8].Text = "Wenas";

        }

        private void buttonProducts2Load_Click(object sender, EventArgs e)
        {
            cargarProductosTabla();
        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void buttonProducts2Delete_Click(object sender, EventArgs e)
        {
            eliminarDatos("DELETE from easyerp.producto WHERE ID ='" + labelProductoId.Text + "'");
            cargarProductosTabla();
        }

        private void buttonProducts2Modify_Click(object sender, EventArgs e)
        {
            modificarDatos("UPDATE easyerp.producto SET `codigo`='" + TextboxCodeProduct2.text + "',`nombre`='" + TextboxNameProduct2.text + "',`referencia`='" + TextboxReferenceProduct2.text + "',`precioDetal`='" + TextboxRetailProduct2.text + "',`percioMayor`='" + TextboxWhosaleProduct2.text + "',`costo`='" + TextboxCostsProduct2.text + "',`cantidad`='" + TextboxQuantityProduct.text + "',`tieneIva`='" + comboBoxTaxesProduct2.Text + "',`inventario_fecha`='" + comboBoxDateProduct2.Value.ToString("yyyy-MM-dd") + "',`departamento_nombre`='" + comboBoxDepartamentProduct2.Text + "',`almacen_fabrica_nombre`='" + comboBoxStoreProduct2.Text + "',`tamano_nombre`='" + comboBoxSizeProduct2.Text + "' WHERE almacen_fabrica_nombre='" + comboBoxStoreProduct2.Text + "' and codigo = '" + TextboxCodeProduct2.text + "'");
            cargarProductosTabla();
        }

        private void buttonProducts2Add_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET codigo = codigo WHERE codigo ='" + TextboxCodeProduct2.text + "' AND almacen_fabrica_nombre ='" + comboBoxStoreProduct2.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ya existe un registro en esta ciudad");
                }
                else
                {
                    insertarDatos("INSERT INTO easyerp.producto (`codigo`, `nombre`, `referencia`, `precioDetal`, `percioMayor`, `costo`, `cantidad`, `tieneIva`, `inventario_fecha`, `departamento_nombre`, `almacen_fabrica_nombre`, `tamano_nombre`) VALUES(" +
                   "'" + TextboxCodeProduct2.text + "','"
                   + TextboxNameProduct2.text + "','"
                   + TextboxReferenceProduct2.text + "','"
                   + TextboxRetailProduct2.text + "','"
                   + TextboxWhosaleProduct2.text + "','"
                   + TextboxCostsProduct2.text + "','"
                   + TextboxQuantityProduct.text + "','"
                   + comboBoxTaxesProduct2.Text + "','"
                   + comboBoxDateProduct2.Value.ToString("yyyy-MM-dd") + "','"
                   + comboBoxDepartamentProduct2.Text + "','"
                   + comboBoxStoreProduct2.Text + "','"
                   + comboBoxSizeProduct2.Text + "')");
                }
                cerrarConeccion();
                cargarProductosTabla();

            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        /*

        */
    }

    }
 

