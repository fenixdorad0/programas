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
    public partial class Form3 : Form
    {
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        //MySqlCommand command;
        public Form3()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buniBtnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
