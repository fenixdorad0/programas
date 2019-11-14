using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;


namespace Ping_LoL
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           
        }             

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int x, y = 0;

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;

            }
            else
            {
                Left = Left + (e.X - x);
                Top = Top + (e.Y - y);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/groups/730410653674259/?ref=br_rs");
        }

        /// <summary>
        /// {"","",""}
        /// </summary>
        string[,] lista2D = new string[,] {
            {"agregar vlan", "inserte vlan","borrar vlan" },//0
            {"modo access","modo trunk","escriba la interface ejemplo 0"},//1
            {"estatica","",""}, //2
            {"direción de destino","mascara de destino","por donde va a pasar es decir la ip del puerto serial 1.1.1.2 ejemplo"},//3
            {"","",""}
        };
        
        private void metodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (metodo.Text==lista2D[0,0])
            {
                textTop1.Text = lista2D[0, 1];
            }
            else if(metodo.Text== lista2D[0, 2]) {
                textTop1.Text = lista2D[0, 1];
            }
            else if (metodo.Text == lista2D[1, 0])
            {
                textTop1.Text = lista2D[1, 2];
            }
            else if (metodo.Text == lista2D[1, 1])
            {
                textTop1.Text = lista2D[1, 2];
            }
            else if (metodo.Text == lista2D[2, 0])
            {
                textTop1.Text = lista2D[3, 0];
                textTop2.Text = lista2D[3, 1];
                textTop3.Text = lista2D[3, 2];
            }

        }

        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            if (metodo.Text== lista2D[0, 0]){                
                texto.Text = ""+
                    "vlan database \n" +
                    "vlan "+textBox1.Text+" name "+textBox1.Text+
                    "\n exit";
            }
            else if (metodo.Text == lista2D[0, 2])
            {
                texto.Text = "" +
                    "vlan database \n" +
                    "no vlan " + textBox1.Text +
                    "\n exit";
            }
            else if (metodo.Text == lista2D[1, 0])
            {
                texto.Text = "" +
                    "configure terminal"+
                    "\n interface f0/" + textBox1.Text +
                    "\n switchport mode access" +
                    "\n no shutdown" +
                    "\n exit";
            }
            else if (metodo.Text == lista2D[1, 1])
            {
                texto.Text = "" +
                    "configure terminal" +
                    "\n interface f0/" + textBox1.Text +
                    "\n switchport mode trunk" +
                    "\n no shutdown" +
                    "\n exit";
            }
            else if (metodo.Text == lista2D[2, 0])
            {
                texto.Text = "" +
                    "interface serial 1/0" +
                    "\n ip address" + textBox1.Text +" "+ textBox2.Text+ " "+textBox3.Text +
                    "\n clock rate 64000" +
                    "\n no shutdown" +
                    "\n exit";             
            }


        }


    }
}
