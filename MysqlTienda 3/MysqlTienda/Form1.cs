﻿using System;
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
        public int yainicio = 0;
        public String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
        public string respuestaFormulario = "algo";
        public Form1()
        {

            InitializeComponent();
            comboBoxCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIvaProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartamentoProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlmacenProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTamanoProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCedulaPermiAlmace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsuPerAlm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoriaEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGastoAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGastoCatagoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlmacenEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
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
            buniMaxMin.Enabled = false;
            //this.Size = new Size(240, 637);
            textInsertarCodigo.Enabled = false;
        }
        public void iniciarTablaVentas(string baseDatos)
        {
            try
            {
                cerrarConeccion();
                string selectQuery = "select codigo,referencia,producto,tamano, cantidad, precio,total FROM easyerp.detalle_facturacov where factura =" + textFactura.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                DataTable table = new DataTable();
                MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                adpter.Fill(table);
                DataGridVentas.DataSource = table;
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
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad+1, total =precio*cantidad, costoTotal=costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";

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
                    string insertarCodigo2 = "INSERT INTO easyerp.detalle_facturacov(`factura`,`fecha`, `almacen`, `codigo`, `referencia`, `producto`, `tamano`, `cantidad`, `precio`,`costo`, `iva`, `SubtotalSinIva`, `SubtotalConIva`, `total`, `costoTotal`) VALUES ('"
                    + textFactura.Text + "', '" //factura
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + comboBoxCiudad.Text + "', '" //almacen falta por arreglar
                    + textInsertarCodigo.Text + "', '" //codigo 
                    + textReferencia.Text + "','"
                    + textProducto.Text + "','" //                    
                    + textTamano.Text + "','"
                    + textCantidad.Text + "','"
                    + textPrecio.Text + "','"
                    + textBoxCostoTotal.Text + "','"
                    + "0" + "','" //iva
                    + "0" + "','" // sub total sin iva
                    + "0" + "','" //sub total con iva
                    + textTotal.Text + "','"
                    + labelCostoTotal.Text + "')";
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
                MessageBox.Show(error.Message + "update o sumando!");
            }
            textInsertarCodigo.Text = "";
            conectar.Close();
        }
        public void limpiarTextbox()
        {
            textInsertarCodigo.Text = null;
            textReferencia.Text = null;
            textProducto.Text = null;
            textCantidad.Text = null;
            textPrecio.Text = null;
            textTotal.Text = null;
            textTamano.Text = null;
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
                //cmd.CommandText = "select sum(cantidad) from tienda.ventas where factura=" + textFactura.Text;
                cmd.CommandText = "select sum(total) from easyerp.detalle_facturacov where factura=" + textFactura.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conectar;
                conectar.Open();
                textSumaTotal.Text = Convert.ToString(cmd.ExecuteScalar());
                conectar.Close();

                MySqlCommand cmd2 = new MySqlCommand();
                //cmd.CommandText = "select sum(cantidad) from tienda.ventas where factura=" + textFactura.Text;
                cmd2.CommandText = "select sum(costoTotal) from easyerp.detalle_facturacov where factura=" + textFactura.Text + " and almacen='" + comboBoxCiudad.Text + "'";
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.Connection = conectar;
                conectar.Open();
                labelCostoTotalizado.Text = Convert.ToString(cmd2.ExecuteScalar());
                conectar.Close();

                labelUtilidad.Text = Convert.ToString(1 - (Convert.ToDouble(labelCostoTotalizado.Text) / Convert.ToDouble(textSumaTotal.Text)));
            }
            catch {
                cerrarConeccion();
            }
        }

        public void buscarFactura()
        {
            //CON ESTE CODIGO CAPTURO EL NUMERO DE FACTURA y lo cambio
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
                    textFactura.Text = Convert.ToString(Convert.ToInt16(mdr.GetString("nf")) + numero);
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
                    textFactura.Text = "1";
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
            if (textSumaTotal.Text == "")
            {

            }
            else
            {

                DialogResult result = MessageBox.Show("Lo que esta realizando es una venta", "Salir", MessageBoxButtons.YesNo);
                Form2 formulario2 = new Form2(textSumaTotal.Text, Convert.ToString(textFactura.Text), comboBoxCiudad.Text);
                //formulario2.Visible = true;               

                switch (result)
                {
                    case DialogResult.Yes:
                        facturaVendida();
                        formulario2.ShowDialog();
                        finalizarCerrarFactura();
                        break;
                    case DialogResult.No:
                        break;
                }





            }

        }

        public void facturaVendida()
        {

            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET vendido='si' WHERE `detalle_facturacov`.`factura` ='" + textFactura.Text + "' and almacen='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("venta realizada");
                }
                else
                {
                    //MessageBox.Show("pero que ha pasado chaval");

                }
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
            textInsertarCodigo.Text = "";
            iniciarTablaVentas("");
            textSumaTotal.Text = "";
            buscarFactura();
            iniciarTablaVentas("");
        }

        public void finalizarFactura()
        {
            try
            {

                string insertarCodigo = "UPDATE easyerp.factura_movimiento SET deuda = deuda WHERE nf =" + textFactura.Text + " and almacen_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {

                    //  MessageBox.Show("Dato actualiza suma");
                }
                else
                {
                    cerrarConeccion();
                    //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));
                    //MessageBox.Show("se ejecuto el ingresodel producto");
                    string insertarCodigo2 = "INSERT INTO easyerp.factura_movimiento(`nf`, `fecha`, `total`,`costo`, `deuda`, `cliente_provedor_cc`, `pago_dividido_id`, `tipo_factura_nombre`, `usuario_cc`, `almacen_nombre`) VALUES ('"
                        + textFactura.Text + "', '" //factura
                        + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" //fecha
                        + textSumaTotal.Text + "', '" //total    
                        + labelCostoTotalizado.Text + "','" // costo
                        + "0" + "','" // deuda
                        + "1" + "','" // CC cliente o del provedor
                        + "1" + "','"  // tipo de pago efecturado
                        + "venta" + "','" //tipo de factura o movimiento
                        + labelCedula.Text + "','" //cedula del vendedor
                        + comboBoxCiudad.Text + "')"; //almacen               
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


        public void codigoCambia()
        {
            sumaTotal();
            bool prueba = false;

            try
            {
                cerrarConeccion();
                MySqlDataReader mdr;
                string select = "SELECT * FROM easyerp.producto where codigo =" + int.Parse(textInsertarCodigo.Text) + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    textCodigo.Text = mdr.GetString("codigo");
                    textReferencia.Text = mdr.GetString("referencia");
                    textProducto.Text = mdr.GetString("nombre");
                    textTamano.Text = mdr.GetString("tamano_nombre");
                    textCantidad.Text = "1";
                    textPrecio.Text = mdr.GetString("precioDetal");
                    textTotal.Text = Convert.ToString(Convert.ToDecimal(textPrecio.Text) * Convert.ToDecimal(textCantidad.Text));
                    labelCosto.Text = mdr.GetString("costo");
                    labelMayor.Text = mdr.GetString("percioMayor");
                    labelDetal.Text = mdr.GetString("precioDetal");
                    textBoxCostoTotal.Text = mdr.GetString("costo");
                    labelCostoTotal.Text = Convert.ToString(Convert.ToDecimal(labelCosto.Text) * Convert.ToDecimal(textCantidad.Text));
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
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad-1 WHERE `producto`.`codigo` =" + textCodigo.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
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

            }


        }

        public void aumentarInventario1()
        {
            //al momento de restar 1 producto en la factura se suma este en 1
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad+1 WHERE `producto`.`codigo` =" + textCodigo.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("aumente el inventario");
                }
                else { }
                cerrarConeccion();


            }
            catch (Exception error)
            {

            }
        }
        public void aumentarInventarioTodo()
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET cantidad = cantidad+" + textCantidad.Text + " WHERE `producto`.`codigo` =" + textCodigo.Text + " and almacen_fabrica_nombre='" + comboBoxCiudad.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("aumente el inventario");
                }
                else { }
                cerrarConeccion();


            }
            catch (Exception error)
            {

            }
        }

        public void textCodigo_TextChanged_1(object sender, EventArgs e)
        {
            codigoCambia();
        }

        public void buniBtnLogin_Click(object sender, EventArgs e)
        {
            logearse();

        }

        public void logearse()
        {
            try
            {
                labelInsertarCodigo.Visible = true;
                textInsertarCodigo.Visible = true;
                MySqlDataReader mdr;
               
                string select = "SELECT* FROM easyerp.usuario WHERE `usuario`.`id` ='" + buniTextUsuario.Text + "' and contrasena ='" + buniTextPass.Text + "'";
                command = new MySqlCommand(select, conectar);
                abrirConeccion();
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    comboBoxCiudad.Visible = true;
                    labelCedula.Text = mdr.GetString("cc");
                    labelVendedor.Text = mdr.GetString("nombre");
                    MessageBox.Show("Login exitoso");
                    labelAlmacen.Text = buniTextUsuario.Text;
                    //this.Size = new Size(1339, 637);
                    textInsertarCodigo.Enabled = true;
                    buniMaxMin.Enabled = true;
                    cerrarConeccion();
                    cargarCiudades();
                    cargarCiudadesGastos();
                    cargarCiudadesEntradas();
                    cargarGastoDescipcion();
                    cargarCategoriaEntrada();

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

        private void colocarFormatoDecimalDataGrids()
        {
            try
            {
                DataGridVentas.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridVentas.Columns[6].DefaultCellStyle.Format = "#,#";
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
        }

        public void cargarPermisosPorAlmacen()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
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
        public void cargarDepartamentosCombobox()
        {
            try
            {
                //carga las ciudades en un combo box importantisimo
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.departamento";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxDepartamentoProducto.ValueMember = "nombre";
                        comboBoxDepartamentoProducto.DisplayMember = "nombre";
                        comboBoxDepartamentoProducto.DataSource = dt;
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.tamano";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxTamanoProducto.ValueMember = "nombre";
                        comboBoxTamanoProducto.DisplayMember = "nombre";
                        comboBoxTamanoProducto.DataSource = dt;
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT nombre FROM easyerp.almacen_fabrica";
                    using (MySqlCommand cmd = new MySqlCommand(sql, c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        comboBoxAlmacenProducto.ValueMember = "nombre";
                        comboBoxAlmacenProducto.DisplayMember = "nombre";
                        comboBoxAlmacenProducto.DataSource = dt;
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labelCedula.Text + "";
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labelCedula.Text + "";
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labelCedula.Text + "";
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
                {
                    c.Open();
                    var sql = "SELECT cc, almacen_fabrica_nombre FROM easyerp.usuario_almacen where cc=" + labelCedula.Text + "";
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
                using (MySqlConnection c = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none"))
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
                comboBoxUsuPerAlm.Text = DataGridPermisosPorAlmacen.CurrentRow.Cells[0].Value.ToString();
                comboBoxCedulaPermiAlmace.Text = DataGridPermisosPorAlmacen.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            {
                /*
                MessageBox.Show(Convert.ToString(error));
                */
            }

        }

        public void cargarDatosTablaUsuario()
        {

            try
            {
                //Cargando los datos cuando doy clic en datagridview                           
                TextboxCedula.text = bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString();
                TextboxUsuario.text = bunifuCustomDataGrid2.CurrentRow.Cells[1].Value.ToString();
                TextboxContrasena.text = bunifuCustomDataGrid2.CurrentRow.Cells[2].Value.ToString();
                TextboxCorreo.text = bunifuCustomDataGrid2.CurrentRow.Cells[3].Value.ToString();
                TextboxNombre.text = bunifuCustomDataGrid2.CurrentRow.Cells[4].Value.ToString();
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
                textCodigo.Text = textProducto.Text = DataGridVentas.CurrentRow.Cells[0].Value.ToString();
                textReferencia.Text = DataGridVentas.CurrentRow.Cells[1].Value.ToString();
                textProducto.Text = DataGridVentas.CurrentRow.Cells[2].Value.ToString();
                textTamano.Text = DataGridVentas.CurrentRow.Cells[3].Value.ToString();
                textCantidad.Text = DataGridVentas.CurrentRow.Cells[4].Value.ToString();
                textPrecio.Text = DataGridVentas.CurrentRow.Cells[5].Value.ToString();
                textTotal.Text = DataGridVentas.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }

        }

        public void bunifuEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt32(textCantidad.Text) > 1)
                {
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET cantidad = cantidad-1, total =precio*cantidad, costoTotal =costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";
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
                else if (Convert.ToInt32(textCantidad.Text) <= 1)
                {
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";
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

        public void limpitarTextosVentas()
        {

            textCodigo.Text = "";
            textReferencia.Text = "";
            textProducto.Text = "";
            textTamano.Text = "";
            textCantidad.Text = "";
            textPrecio.Text = "";
            textTotal.Text = "";
        }

        public void buniActualizar_Click(object sender, EventArgs e)
        {

            if (textCodigo.Text == "")
            { }
            else
            {
                try
                {
                    double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                    string insertarCodigo = "UPDATE easyerp.detalle_facturacov SET precio =" + textPrecio.Text + ", total =precio*cantidad, costoTotal=costo*cantidad  WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";
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
            try
            {
                cargarPermisosPorAlmacen();
                bool todoEstaBien = comprobarDatosUsuario();
                if (todoEstaBien == true) {
                    cerrarConeccion();
                    string insertarCodigo = "INSERT INTO easyerp.usuario (`cc`, `id`, `contrasena`, `correo`, `nombre`) VALUES (" +
                        "'" +
                        TextboxCedula.text + "', '" +
                        TextboxUsuario.text + "', '" +
                        TextboxContrasena.text + "', '" +
                        TextboxCorreo.text + "', '" +
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
            bool verificarEmail = bien_escrito(TextboxCorreo.text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (verificarEmail == true) { LabelUCorreo.Text = "correo"; } else { LabelUCorreo.Text = "correo (verifique que este bien escrito)"; };

            bool verificarNombre = bien_escrito(TextboxNombre.text, "[a-zA-ZñÑ\\s]{2,50}");
            if (verificarNombre == true) { LabelUNombre.Text = "nombre"; } else { LabelUNombre.Text = "nombre (verifique que este bien escrito)"; };

            bool verificarCedula = bien_escrito(TextboxCedula.text, @"[0-9]{1,30}(\.[0-9]{0,2})?$");
            if (verificarCedula == true) { LabelUCedula.Text = "cédula"; } else { LabelUCedula.Text = "cédula(verifique que este bien escrito)"; };

            if (verificarCedula == true && verificarNombre == true && verificarEmail == true)
            {
                ButtonUsuarioAgregar.Enabled = true;
                ButtonUsuarioEliminar.Enabled = true;
                ButtonUsuarioModificar.Enabled = true;
                return true;
            }
            else
            {
                ButtonUsuarioAgregar.Enabled = false;
                ButtonUsuarioEliminar.Enabled = false;
                ButtonUsuarioModificar.Enabled = false;
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
            iniciarTablaUsuarios();
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
                bunifuCustomDataGrid2.DataSource = table;
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
                DataGridPermisosPorAlmacen.DataSource = table;
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
            try
            {
                cerrarConeccion();
                double precio = Convert.ToDouble(textTotal.Text) / Convert.ToDouble(textCantidad.Text);
                string insertarCodigo = "DELETE FROM easyerp.detalle_facturacov WHERE `detalle_facturacov`.`factura` =" + textFactura.Text + " AND `detalle_facturacov`.`codigo` = " + textCodigo.Text + " and almacen='" + comboBoxCiudad.Text + "'";
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

            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar a este usuario?: '" + TextboxUsuario.text + "'?", "Eliminar usuario: '" + TextboxNombre.text + "'", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                try
                {
                    cargarPermisosPorAlmacen();
                    cerrarConeccion();
                    string insertarCodigo = "DELETE FROM easyerp.usuario WHERE cc =" + TextboxCedula.text;
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

        public void ButtonUsuarioModificar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPermisosPorAlmacen();
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.usuario SET `cc` = '" + TextboxCedula.text + "', `id` = '" + TextboxUsuario.text + "', `contrasena` = '" + TextboxContrasena.text + "', `correo` = '" + TextboxCorreo.text + "', `nombre` = '" + TextboxNombre.text + "' WHERE `usuario`.`cc` = '" + TextboxCedula.text + "'";
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

        public void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        public void ButtonAgregarPeAl_Click(object sender, EventArgs e)
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
            textInsertarCodigo.Text = "";
            conectar.Close();


        }

        public void ButtonCargarPeAl_Click(object sender, EventArgs e)
        {
            iniciarTablaPermisosAlmacen();
        }

        public void ButtonCargarPeAl_Click_1(object sender, EventArgs e)
        {
            cargarPermisosPorUsuario();
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
                DataGridPermisosPorAlmacen.DataSource = table;
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
            cargarProductosTabla();
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
            textInsertarCodigo.Text = "";
            conectar.Close();
        }

        public void bunifuFlatButton8_Click(object sender, EventArgs e)
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

        public void ButtonEliminarAlmacen(object sender, EventArgs e)
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

        public void DataGridAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
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

        public void DataGridAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaTablaPermisosPorAlmacen();
        }

        public void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            cargarPermisosPorAlmacen();
            cargarCiudadesPermisosAlamacen();
            cargarCiudadesGastos();
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

        public void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            eliminarDatos("DELETE FROM easyerp.tamano WHERE nombre='" + TextboxTamañoNombre.text + "'");
            cargarTablaTamano();
            cargarComboboxes();
        }

        public void DataGridTamano_CellClick(object sender, DataGridViewCellEventArgs e)
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

        public void DataGridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarProductosconClick();
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
                TextboxCodigoProducto.text = DataGridProductos.CurrentRow.Cells[1].Value.ToString();
                TextboxNombreProducto.text = DataGridProductos.CurrentRow.Cells[2].Value.ToString();
                TextboxReferenciaProducto.text = DataGridProductos.CurrentRow.Cells[3].Value.ToString();
                TextboxDetalProducto.text = DataGridProductos.CurrentRow.Cells[4].Value.ToString();
                TextboxMayorProducto.text = DataGridProductos.CurrentRow.Cells[5].Value.ToString();
                TextboxCostoProducto.text = DataGridProductos.CurrentRow.Cells[6].Value.ToString();
                TextboxCantidadProducto.text = DataGridProductos.CurrentRow.Cells[7].Value.ToString();
                comboBoxIvaProducto.Text = DataGridProductos.CurrentRow.Cells[8].Value.ToString();
                comboBoxFechaProducto.Text = DataGridProductos.CurrentRow.Cells[9].Value.ToString();
                comboBoxDepartamentoProducto.Text = DataGridProductos.CurrentRow.Cells[10].Value.ToString();
                comboBoxAlmacenProducto.Text = DataGridProductos.CurrentRow.Cells[11].Value.ToString();
                comboBoxTamanoProducto.Text = DataGridProductos.CurrentRow.Cells[12].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("El error es :" + Convert.ToString(error) + "el error se encuentra cargando los datos");
            }
        }

        public void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "UPDATE easyerp.producto SET codigo = codigo WHERE codigo ='" + TextboxCodigoProducto.text + "' AND almacen_fabrica_nombre ='" + comboBoxAlmacenProducto.Text + "'";
                conectar.Open();
                MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ya existe un registro en esta ciudad");
                }
                else
                {
                    insertarDatos("INSERT INTO easyerp.producto (`codigo`, `nombre`, `referencia`, `precioDetal`, `percioMayor`, `costo`, `cantidad`, `tieneIva`, `inventario_fecha`, `departamento_nombre`, `almacen_fabrica_nombre`, `tamano_nombre`) VALUES(" +
                   "'" + TextboxCodigoProducto.text + "','"
                   + TextboxNombreProducto.text + "','"
                   + TextboxReferenciaProducto.text + "','"
                   + TextboxDetalProducto.text + "','"
                   + TextboxMayorProducto.text + "','"
                   + TextboxCostoProducto.text + "','"
                   + TextboxCantidadProducto.text + "','"
                   + comboBoxIvaProducto.Text + "','"
                   + comboBoxFechaProducto.Value.ToString("yyyy-MM-dd") + "','"
                   + comboBoxDepartamentoProducto.Text + "','"
                   + comboBoxAlmacenProducto.Text + "','"
                   + comboBoxTamanoProducto.Text + "')");
                }
                cerrarConeccion();
                cargarProductosTabla();

            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }



        }

        public void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            eliminarDatos("DELETE from easyerp.producto WHERE ID ='" + labelProductoId.Text + "'");
            cargarProductosTabla();
        }

        public void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            modificarDatos("UPDATE easyerp.producto SET `codigo`='" + TextboxCodigoProducto.text + "',`nombre`='" + TextboxNombreProducto.text + "',`referencia`='" + TextboxReferenciaProducto.text + "',`precioDetal`='" + TextboxDetalProducto.text + "',`percioMayor`='" + TextboxMayorProducto.text + "',`costo`='" + TextboxCostoProducto.text + "',`cantidad`='" + TextboxCantidadProducto.text + "',`tieneIva`='" + comboBoxIvaProducto.Text + "',`inventario_fecha`='" + comboBoxFechaProducto.Value.ToString("yyyy-MM-dd") + "',`departamento_nombre`='" + comboBoxDepartamentoProducto.Text + "',`almacen_fabrica_nombre`='" + comboBoxAlmacenProducto.Text + "',`tamano_nombre`='" + comboBoxTamanoProducto.Text + "' WHERE almacen_fabrica_nombre='" + comboBoxAlmacenProducto.Text + "' and codigo = '" + TextboxCodigoProducto.text + "'");
            cargarProductosTabla();
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
                    labelVentasCreditoLocal.Text = "las ventas del día de hoy por credito fueron:" + (Convert.ToDouble(cmd10.ExecuteScalar())).ToString("C");
                    double credito = Convert.ToDouble(cmd10.ExecuteScalar());
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd11 = new MySqlCommand();
                    cmd11.CommandText = "SELECT SUM(efectivo) FROM easyerp.metodo_pago_detallado WHERE ciudad='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd11.CommandType = System.Data.CommandType.Text;
                    cmd11.Connection = conectar;
                    conectar.Open();
                    labelEfectivoLocal.Text = "las ventas del día de hoy por efectivo fueron:" + (Convert.ToDouble(cmd11.ExecuteScalar())).ToString("C");
                    double efectivo = Convert.ToDouble(cmd11.ExecuteScalar());
                    conectar.Close();

                    //
                    cerrarConeccion();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT SUM(total) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and almacen_nombre='" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;
                    conectar.Open();
                    labelReporte1.Text = "las ventas del día de hoy fueron:" + (Convert.ToDouble(cmd.ExecuteScalar())).ToString("C");
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

                    labelReporteGanancias.Text = "Las ganancias fueron: " + (ganancia).ToString("C") + " El costo es de :" + costo.ToString("C") + " Que representan una utilidad de: " + Convert.ToString(Math.Round(((ganancia / costo)) * 100, 2)) + "%";

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
                    labelReporteLocalEntradas.Text = "El total de las entradas de dinero fueron: " + entrada.ToString("C");
                    conectar.Close();



                }
                catch (Exception error)
                {
                    //MessageBox.Show(Convert.ToString(error));
                }

                //aquiiiiii

                //";
                try
                {

                    cerrarConeccion();
                    string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteProducto.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes");
                }

                try
                {
                    cerrarConeccion();

                    string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',sum(costoTotal) as 'costoTotal',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and almacen = '" + comboBoxCiudad.Text + "' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto ";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteDepartamento.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes");
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
                    MessageBox.Show(error.Message + "datrigreportes");
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
                DataGridReporteProducto.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridReporteProducto.Columns[6].DefaultCellStyle.Format = "#,#";
                DataGridReporteProducto.Columns[7].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros.Columns[4].DefaultCellStyle.Format = "#,#";
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
                    labelReporteCredito2.Text = "las ventas del día de hoy por credito fueron:" + (Convert.ToDouble(cmd10.ExecuteScalar())).ToString("C");
                    double credito = Convert.ToDouble(cmd10.ExecuteScalar());
                    conectar.Close();

                    cerrarConeccion();
                    MySqlCommand cmd11 = new MySqlCommand();
                    cmd11.CommandText = "SELECT SUM(efectivo) FROM easyerp.metodo_pago_detallado WHERE fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd11.CommandType = System.Data.CommandType.Text;
                    cmd11.Connection = conectar;
                    conectar.Open();
                    labelReporteEfectivo2.Text = "las ventas del día de hoy por efectivo fueron:" + (Convert.ToDouble(cmd11.ExecuteScalar())).ToString("C");
                    double efectivo = Convert.ToDouble(cmd11.ExecuteScalar());
                    conectar.Close();
                    //
                    cerrarConeccion();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT SUM(total) FROM easyerp.factura_movimiento WHERE tipo_factura_nombre ='venta' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;
                    conectar.Open();
                    labelReporte2.Text = "las ventas de todos los locales día de hoy fueron " + (Convert.ToDouble(cmd.ExecuteScalar())).ToString("C");
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

                    labelReporteGanancias2.Text = "Las ganancias de todos los locales fueron:" + (ganancia).ToString("C") + " El costo fue de :" + (costo).ToString("C") + " Que representan una utilidad de: " + Convert.ToString(Math.Round((((ganancia) / costo)) * 100, 2)) + "%";

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
                    string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'ventas totales',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteProducto2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes");
                }

                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT producto as 'departamento', sum(cantidad) as 'cantidad vendida' ,sum(total) as 'venta total',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto";
                    //string selectQuery = "SELECT codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,(total - costoTotal) as 'ganancia',(1-(costoTotal / total)) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(selectQuery, conectar);
                    adpter.Fill(table);
                    DataGridReporteDepartamento2.DataSource = table;
                    cerrarConeccion();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "datrigreportes");
                }

                try
                {
                    cerrarConeccion();
                    string selectQuery = "SELECT almacen,sum(total) as 'ventas totales',sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by almacen ORDER BY `detalle_facturacov`.`almacen` ASC";
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
                    string selectQuery = "SELECT almacen,codigo,referencia,producto,tamano, sum(cantidad) as 'cantidad vendida' ,sum(costoTotal) as 'costo Total',(sum(total) - sum(costoTotal)) as 'ganancia',(((sum(total) - sum(costoTotal))/sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by codigo, almacen ORDER BY `detalle_facturacov`.`almacen` ASC";
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
                    MessageBox.Show(error.Message + "datrigreportes");
                }

                //venta por departamento de cada almacen
                try
                {
                    cerrarConeccion();
                    //string selectQuery = "SELECT producto, sum(cantidad) as 'cantidad vendida' ,sum(total) as 'total vendido',(sum(total) - sum(costoTotal)) as 'ganancia',(1-(sum(costoTotal) / sum(total))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE almacen_nombre = '" + comboBox1.Text + "' and fecha BETWEEN '" + fechaHoy + " 00:00:00' AND '" + fechaHoy + " 23:59:59' GROUP by producto ";
                    string selectQuery = "SELECT almacen,producto as 'departamento', sum(cantidad) as 'cantidad vendida' ,sum(total) as 'venta total',(sum(total) - sum(costoTotal)) as 'ganancia',sum(costoTotal) as 'costo total',((sum(total)-sum(costoTotal)) /(sum(costoTotal))) as 'ganancia porcentual' from easyerp.detalle_facturacov WHERE vendido='si' and fecha BETWEEN '" + fechaA + " 00:00:00' AND '" + fechaB + " 23:59:59' GROUP by producto,almacen ORDER BY almacen DESC, `cantidad vendida` DESC";
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
                DataGridReporteProducto2.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridReporteProducto2.Columns[6].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento2.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento2.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamento2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentasAlmacen2.Columns[1].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentasAlmacen2.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentasAlmacen2.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[7].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridReporteProductosAlmacen2.Columns[6].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamentoAlmacen2.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamentoAlmacen2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteDepartamentoAlmacen2.Columns[5].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros2.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros2.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaCajeros2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDia2.Columns[1].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDia2.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDia2.Columns[3].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDia2.Columns[4].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDiaR2.Columns[1].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDiaR2.Columns[2].DefaultCellStyle.Format = "#,#";
                DataGridReporteVentaDiaR2.Columns[3].DefaultCellStyle.Format = "#,#";
            }
            catch
            {

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
            cargarTablaGastos("gasto");
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
            try
            {
                LabelIdGastos.Text = DataGridGastos.CurrentRow.Cells[0].Value.ToString();
                TextboxGatosTotal.text = DataGridGastos.CurrentRow.Cells[1].Value.ToString();
                LabelFechaGastos.Text = DataGridGastos.CurrentRow.Cells[2].Value.ToString();
                TextboxGastosDescripcion.text = DataGridGastos.CurrentRow.Cells[3].Value.ToString();

                comboBoxGastoAlmacen.Text = DataGridGastos.CurrentRow.Cells[5].Value.ToString();
                comboBoxGastoCatagoria.Text = DataGridGastos.CurrentRow.Cells[6].Value.ToString();
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
            agregar("gasto");
        }

        private void agregar(string gastoEntrada)
        {
            try
            {
                string insertarCodigo = "";
                cerrarConeccion();
                if (gastoEntrada == "gasto")
                {
                    insertarCodigo = "INSERT INTO easyerp.gastoentrada (`id`, `total`, `fecha`, `descripcion`, `usuario_cc`, `almacen_nombre`, `gastoOentrada`, `categoria`) VALUES (NULL, '" + TextboxGatosTotal.text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + TextboxGastosDescripcion.text + "', '" + labelCedula.Text + "', '" + comboBoxGastoAlmacen.Text + "', '" + gastoEntrada + "', '" + comboBoxGastoCatagoria.Text + "');";
                }
                else
                {
                    insertarCodigo = "INSERT INTO easyerp.gastoentrada (`id`, `total`, `fecha`, `descripcion`, `usuario_cc`, `almacen_nombre`, `gastoOentrada`, `categoria`) VALUES (NULL, '" + TextboxTotalEntrada.text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + TextboxDescipcionEntrada.text + "', '" + labelCedula.Text + "', '" + comboBoxAlmacenEntrada.Text + "', '" + gastoEntrada + "', '" + comboBoxCategoriaEntrada.Text + "');";
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
            eliminarEntradaGasto("gasto");
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
            modificarEntradaGasto("gasto");
        }

        private void modificarEntradaGasto(string entradaGasto)
        {
            try
            {
                cerrarConeccion();
                string insertarCodigo = "";
                if (entradaGasto == "gasto")
                {
                    insertarCodigo = "UPDATE easyerp.gastoentrada SET `total` = '" + TextboxGatosTotal.text + "', `descripcion` = '" + TextboxGastosDescripcion.text + "', `almacen_nombre` = '" + comboBoxGastoAlmacen.Text + "', `categoria` = '" + comboBoxGastoCatagoria.Text + "' WHERE `gastoentrada`.`id` = " + LabelIdGastos.Text + "";
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
            try
            {
                LabelIdEntrada2.Text = DataGridEntrada.CurrentRow.Cells[0].Value.ToString();
                TextboxTotalEntrada.text = DataGridEntrada.CurrentRow.Cells[1].Value.ToString();
                LabelFechaEntrada2.Text = DataGridEntrada.CurrentRow.Cells[2].Value.ToString();
                TextboxDescipcionEntrada.text = DataGridEntrada.CurrentRow.Cells[3].Value.ToString();
                comboBoxAlmacenEntrada.Text = DataGridGastos.CurrentRow.Cells[5].Value.ToString();
                comboBoxCategoriaEntrada.Text = DataGridGastos.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {

            }

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

                    string costo = Convert.ToString(Convert.ToDecimal(labelCosto.Text) * Convert.ToDecimal(textCantidad.Text));


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

                for (int cont = 0; cont < DataGridVentas.RowCount - 1; cont++)
                {
                    codigoProducto = DataGridVentas.Rows[cont].Cells[0].Value.ToString();
                    cantidadProducto = DataGridVentas.Rows[cont].Cells[4].Value.ToString();
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

        private void tab1Inicio_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    }
 

