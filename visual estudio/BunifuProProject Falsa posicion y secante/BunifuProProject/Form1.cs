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
     

        private void menu_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 25)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 183;
                PanelAnimator.ShowSync(sidemenu);
                
                panel1.Location = new Point(195, 36);
            }
            else
            {
               
                sidemenu.Visible = false;
                sidemenu.Width = 25;
                PanelAnimator.ShowSync(sidemenu);
                panel1.Location = new Point(112, 36);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "Simson";
            //simson
            calcularSimson.Visible = true;
            calcularTrapecio.Visible = false;
            calcularBisecion.Visible = false;
            limA.Text = "limA";
            limB.Text = "limB";
            listBox1.Items.Clear();
            valorReal.Visible = true;
            textBox5.Visible = true;
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //trapiezo
            bunifuCustomLabel5.Text = "Trapecio";
            calcularSimson.Visible = false;
            calcularTrapecio.Visible = true;
            calcularBisecion.Visible = false;
            limA.Text = "limA";
            limB.Text = "limB";
            listBox1.Items.Clear();
            valorReal.Visible = true;
            textBox5.Visible = true;
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            //biseccion
            bunifuCustomLabel5.Text = "Bisección";
            calcularSimson.Visible = false;
            calcularTrapecio.Visible = false;
            calcularBisecion.Visible = true;
            limA.Text = "Xl";
            limB.Text = "Xu";
            listBox1.Items.Clear();
            valorReal.Visible = false;
            textBox5.Visible = false;
        }
 
        public static double fsimson(double x)
        {
            return x+1+(x*x);
        }
        private void calcularSimson_Click(object sender, EventArgs e)
        {
            double a, b, h, fa, fb,fh, n, i=0, Vactual = 9.8333, error=100;
            double sumpar, sumimpar;
            listBox1.Items.Clear();
            try
            {
                sumpar = 0;
                sumimpar = 0;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                double limError = Convert.ToDouble(textBox3.Text);
                double limItera = Convert.ToDouble(textBox4.Text);
                fa = fsimson(a);
                fb = fsimson(b);
                n = 2;
                int cont1 = 0;
                while (error > limError && cont1 < limItera)
                {
                    h = (b + a) / n;
                    sumimpar = 0;
                    sumpar = 0;
                    for (int cont3 = 1; cont3 < n;cont3++)
                    {
                        if (cont3 % 2 == 0)
                        {
                            sumpar = sumpar + fsimson(h * (cont3));   
                        }
                        else
                        {
                            sumimpar = sumimpar + fsimson(h * (cont3));
                        }
                    }
                    
                    i = (b - a) * ((fa + (4 * sumimpar) + (2 * sumpar) + fb) / (3 * n));
                    error = Math.Abs((((i - Vactual)) / Vactual)*100);
                    String texto =
                              "cont= " + cont1 + "   " +
                              "i= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(i), 3)) + "   " +
                              "n= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(n), 3)) + "   " +
                              "h= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(h), 3)) + "   " +
                              "fa= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fa), 3)) + "   " +
                              "fb= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(fb), 3)) + "   " +
                              "error= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(error), 3))
                              ;
                    listBox1.Items.Add(texto);
                    n++;
                    cont1++;
                }    
            }
            catch
            {
                MessageBox.Show("El limite A y B tienen que ser de caracter numericos");
            }

        }


        public static double ftrapecio(double x)
        {
            return x + 1 + (x * x);
        }

        private void calcularTrapecio_Click(object sender, EventArgs e)
        {

            double a, b, h, fa, fb, fh, n, i, error=100, valorReal = 9.8333, sumh;
            try
            {
                listBox1.Items.Clear();
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                double limError = Convert.ToDouble(textBox3.Text);
                double limItera = Convert.ToDouble(textBox4.Text);
                fa = ftrapecio(a);
                fb = ftrapecio(b);
                n = 1;
                int cont1 = 0;
                while (error > limError && cont1 < limItera)
                {
                    h = (b + a) / n;
                    sumh = 0;
                    for (int cont3 = 1; cont3 < n; cont3++)
                    {
                        sumh = sumh + ftrapecio(h * cont3);
                    }
                    i = (b - a) * ((fa + (2 * (sumh)) + fb) / (2 * n));
                    error = Math.Abs(((i - valorReal) / valorReal) * 100);
                    String texto =
                    "cont= " + cont1 + "   " +
                    "i= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(i), 4)) + "   " +
                    "n= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(n), 3)) + "   " +
                    "h= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(h), 3)) + "   " +
                    "error= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(error), 2))
                    ;
                    listBox1.Items.Add(texto);
                    n++;
                    cont1++;
                }                    
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static double fBisecion(double x)
        {
            return x + 1 + (x * x);
        }

        private void calcularBisecion_Click(object sender, EventArgs e)
        {
            double xl, xu, xr, xra, fxl, fxu, fxr, fxlporfxr, error = 100;
            listBox1.Items.Clear();
            try
            {
                xl = Convert.ToDouble(textBox1.Text);
                xu = Convert.ToDouble(textBox2.Text);
                double limError = Convert.ToDouble(textBox3.Text);  
                double limItera = Convert.ToDouble(textBox4.Text);
                int cont1 = 0;
                //xr = (xl + xu) / 2;
                fxl = fBisecion(xl);
                fxu = fBisecion(xu);
                xr = (xu - (((fxu) * (xl - xu)) / (fxl - fxu)));
                fxr = fBisecion(xr);
                fxlporfxr = fxl * fxr;
                xra = xr;
                while (Math.Abs(error) > limError && cont1 < limItera)
                {
                    if (cont1 == 0) { }
                    else
                    {
                        if (fxlporfxr < 0)
                        {
                            xu = xr;
                        }
                        else
                        {
                            xl = xr;
                        }
                        xr = (xl + xu) / 2;
                        fxl = fBisecion(xl);
                        fxu = fBisecion(xu);
                        fxr = fBisecion(xr);
                        fxlporfxr = fxl * fxr;
                        error = ((xr - xra) / xr) * 100;
                        xra = xr;
                    }
                    String texto =

                                    "i= " + cont1 + "   " +
                                    "XL= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xl), 3)) + "   " +
                                    "Xu= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xu), 3)) + "   " +
                                    "XR= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(xr), 4)) + "   " +
                                    "error= " + Convert.ToString(Decimal.Round(Convert.ToDecimal(Math.Abs(error)), 3))
                                    ;
                    listBox1.Items.Add(texto);
                    cont1 = cont1 + 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
