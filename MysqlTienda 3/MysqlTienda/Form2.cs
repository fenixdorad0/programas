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
using MysqlTienda;

namespace MysqlTienda
{
    public partial class Form2 : Form
    {
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SslMode=none");
        MySqlCommand command;
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
        public Form2()
        {
            InitializeComponent();            
            this.TopMost = true;
        }
        public Form2(string texto)
        {
            InitializeComponent();
            this.TopMost = true;
            lbl.Text = texto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string texto = "hola mundo";
            Form1 formulario1 = new Form1();
            //formulario1.Show();
            formulario1.logearse();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }
        
    }
}