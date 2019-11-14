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

namespace MySql
{
    public partial class Form1 : Form
    {
        MySqlConnection conectar = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //MySqlConnection conectar = new MySqlConnection("server=localhost; database=tienda; Uid=fenix; pwd=;");
            
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string insertarCodigo ="INSERT INTO tienda.producto(idproducto,producto,stock,precio) VALUES ('"+textBox1.Text+ "', '" + textBox1.Text + "','" + textBox1.Text + "','" + textBox1.Text + "')";
            conectar.Open();
            MySqlCommand command = new MySqlCommand(insertarCodigo, conectar);
            if (command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Dato insertado");
            }
            else
            {
                MessageBox.Show("Dato NO insertado");
            }
            conectar.Close();
        }
    }
}
