using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunifuProProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
     

    

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "Secante";
            //simson
            calcularSimson.Visible = true;
            calcularTrapecio.Visible = false;
            calcularBisecion.Visible = false;
            limA.Text = "XI-1";
            limB.Text = "XI";
            listBox1.Items.Clear();
            valorReal.Visible = true;
            textBox5.Visible = true;
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //trapiezo
            bunifuCustomLabel5.Text = "Falsa posición";
            calcularSimson.Visible = false;
            calcularTrapecio.Visible = true;
            calcularBisecion.Visible = false;
            limA.Text = "Xl";
            limB.Text = "XU";
            listBox1.Items.Clear();
            valorReal.Visible = true;
            textBox5.Visible = true;
        }
      
 
      
        private void CalcularSecante(object sender, EventArgs e)
        {
            try
            {
                Decimal ximenos1a, ximenos1, xi, fxi, fximenos1, ximas1, ximas1a, error = 100;
                int cont1 = 0;
                listBox1.Items.Clear();
                ximenos1 = Convert.ToDecimal(textBox1.Text);
                xi = Convert.ToDecimal(textBox2.Text);
                Decimal limError = Convert.ToDecimal(textBox3.Text);
                Decimal limItera = Convert.ToDecimal(textBox4.Text);
                fxi = fSecante(xi);
                fximenos1 = fSecante(ximenos1);
                ximas1 = xi - (((fxi) * (ximenos1 - xi)) / (fximenos1 - fxi));
                ximas1a = ximas1;
                ximenos1a = ximenos1;
                while (Math.Abs(error) >= limError && cont1 < limItera)
                {
                    ximenos1 = ximas1a;
                    xi = ximenos1a;
                    fxi = fSecante(xi);
                    fximenos1 = fSecante(ximenos1);
                    ximas1 = xi - (((fxi) * (ximenos1 - xi)) / (fximenos1 - fxi));
                    error = ((ximas1 - ximas1a) / ximas1) * 100;
                    String texto =
                    "I= " + cont1 + "   " +
                    "XI-1= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(ximenos1), 5)) + "   " +
                    "XI " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xi), 5)) + "   " +
                    "F(XI) " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fxi), 5)) + "   " +
                    "F(XI-1)= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fximenos1), 5)) + "   " +
                    "XI+1= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(ximas1), 5)) + "   " +
                    "ERROR= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(Math.Abs(error)), 3))
                    ;
                    listBox1.Items.Add(texto);
                    cont1 = cont1 + 1;
                    ximas1a = ximas1;
                    ximenos1a = ximenos1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      

        private void calcularFalsaPosicion(object sender, EventArgs e)
        {
            try
            {
                decimal axl, xl, xu, xr, xra, fxl, fxu, fxr, fxlporfxr, error = 100;
                int cont1 = 0;
                listBox1.Items.Clear();
                xl = Convert.ToDecimal(textBox1.Text);
                xu = Convert.ToDecimal(textBox2.Text);
                Decimal limError = Convert.ToDecimal(textBox3.Text);
                Decimal limItera = Convert.ToDecimal(textBox4.Text);
                fxl = fFalsaPosicion(xl);
                fxu = fFalsaPosicion(xu);
                xr = ((xu - (((fxu) * (xl - xu)) / (fxl - fxu))));
                fxr = fFalsaPosicion(xr);
                fxlporfxr = fxl * fxr;
                xra = xr;
                axl = xl;

                while (Math.Abs(error) >= limError && cont1 < limItera)
                {
                    xl = xra;
                    fxl = fFalsaPosicion(xl);
                    fxu = fFalsaPosicion(xu);
                    xr = ((xu - (((fxu) * (xl - xu)) / (fxl - fxu))));
                    fxr = fFalsaPosicion(xr);
                    fxlporfxr = fxl * fxr;
                    error = ((xr - xra) / xr) * 100;
                    xra = xr;
                    String texto =
                    "I= " + cont1 + "   " +
                    "XL= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xl), 5)) + "   " +
                    "XR= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xr), 5)) + "   " +
                    "XU= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xu), 5)) + "   " +
                    "F(XU)= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fxu), 5)) + "   " +
                    "F(XL)= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fxl), 5)) + "   " +
                    "F(XR)= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fxr), 5)) + "   " +
                    "F(XL)*F(XR)= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fxlporfxr), 5)) + "   " +
                    "ERROR= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(Math.Abs(error)), 3))
                    ;
                    listBox1.Items.Add(texto);
                    cont1 = cont1 + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static Decimal fSecante(Decimal x)
        {
            return ((decimal)0.95 * (x * x * x) - (decimal)5.9 * (x * x) + (decimal)10.9 * (x) - 6);
        }

        public static Decimal fFalsaPosicion(Decimal x)
        {
            return ((2 * (x * x * x * x)) - 4 * (x) - 15);
        }

       
    }
}
