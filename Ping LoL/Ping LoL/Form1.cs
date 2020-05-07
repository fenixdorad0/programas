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
            timer1.Start();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                 using (Ping a = new Ping())
                {
                    bunifuCustomLabel1.Text="EUW: "+ (a.Send("104.160.141.3").RoundtripTime.ToString() + "ms\n");              
                }
                using (Ping b = new Ping())
                {
                    bunifuCustomLabel2.Text = "NA: " + (b.Send("104.160.131.3").RoundtripTime.ToString() + "ms\n");
                }
                using (Ping c = new Ping())
                {
                    bunifuCustomLabel3.Text = "EUNE: " + (c.Send("104.160.142.3").RoundtripTime.ToString() + "ms\n");
                }
                using (Ping d = new Ping())
                {
                    bunifuCustomLabel4.Text = "OCE: " + (d.Send("104.160.156.1").RoundtripTime.ToString() + "ms\n");
                }
                using (Ping d = new Ping())
                {
                    bunifuCustomLabel5.Text = "LAN: " + (d.Send("104.160.136.3").RoundtripTime.ToString() + "ms\n") + "local" +d.Send("192.168.0.1").RoundtripTime.ToString();
                }
            }catch(Exception error)
            {
            
            }
           

        }


        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
