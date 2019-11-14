using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial
{
    public partial class Form1 : Form
    {
        Random f = new Random();
        int randomPower = 0;
        int[] listaPowers = new int[100];
        int numAlea = 0;
        int numAlea2 = 0;
        int inicio = 0;
        int pnt = 5;
        bool comenzoJuego = false;
        bool cambioColor = false;
        bool click = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
           if (inicio == 0) { 
            for (int contPower = 0; contPower < 100; contPower++)
            {
                listaPowers[contPower]= f.Next(1, 20);
            }
            }

            inicio = inicio+1;
            poderes(inicio);

            click = true;
            if (comenzoJuego == true)
            {
                if (pnt >= 49)
                    {
                    terminarJuego("gano");
                }
                else
                    {
                        Button btn = (Button)sender;
                        if (btn.BackColor == Color.FromArgb(255, 117, 0)) 
                    {
                        pnt = pnt + 1;
                        //Poder Bomba
                        if (listaPowers[inicio] == 1 || listaPowers[inicio] == 2 || listaPowers[inicio] == 3)
                        {
                            btn.BackColor = Color.FromArgb(0, 0, 255);
                        }
                        // Intercambio de pocisión
                        else if (listaPowers[inicio] == 4 || listaPowers[inicio] == 5 || listaPowers[inicio] == 6)
                        {
                            btn.BackColor= Color.FromArgb(0, 0, 255); ;
                            foreach (Control cComponente in panel1.Controls)
                            {
                                if (cComponente.BackColor == Color.FromArgb(255, 117, 0))
                                {
                                    cComponente.BackColor = Color.FromArgb(255, 0, 0);
                                }
                                else if (cComponente.BackColor == Color.FromArgb(255, 0, 0))
                                {
                                    cComponente.BackColor = Color.FromArgb(255, 117, 0);
                                }
                            }
                        }
                        // ilución
                        else if (listaPowers[inicio] == 7 || listaPowers[inicio] == 8)
                        {
                            btn.BackColor = Color.FromArgb(120, 215, 55);
                        }
                        // congelar pantalla
                        else if (listaPowers[inicio] == 9 || listaPowers[inicio] == 0)
                        {
                            btn.BackColor = Color.FromArgb(213, 0, 255);
                        }
                        //ningun poder
                        else
                        {
                            btn.BackColor = Color.FromArgb(255, 255, 255);
                        }
                        label1.Text = Convert.ToString(pnt);}
                else
                    {
                        pnt = pnt - 1;
                        label1.Text = Convert.ToString(pnt);
                    }
            }
            if (pnt <= 0)
                {
                    terminarJuego("perdio");
                }
            }
        }
        private void comenzarJuego(object sender, EventArgs e)
        {
            button13.Enabled = false;
            comenzoJuego = true;
            asignarColor(0,3);
            timer1.Start();
        }
        private void poderes(int nuevoContador)
        {
            int contador= nuevoContador;
            foreach (Control cComponente in panel2.Controls)
            {
                contador = contador + 1;
                if (listaPowers[contador] == 1 || listaPowers[contador] == 2 || listaPowers[contador] == 3)
                {
                    cComponente.BackColor = Color.FromArgb(0, 0, 255);

                }
                // Intercambio de pocisión
                else if (listaPowers[contador] == 4 || listaPowers[contador] == 5 || listaPowers[contador] == 6)
                {
                    cComponente.BackColor = Color.FromArgb(255, 255, 0);
                }
                // ilución
                else if (listaPowers[contador] == 7 || listaPowers[contador] == 8)
                {
                    cComponente.BackColor = Color.FromArgb(120, 215, 55);
                }
                // congelar pantalla
                else if (listaPowers[contador] == 9 || listaPowers[contador] == 0)
                {
                    cComponente.BackColor = Color.FromArgb(213, 0, 255);
                }
                else
                {
                    cComponente.BackColor = Color.FromArgb(255, 255, 255);
                }
   
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            asignarColor(0,3);           
            numAlea2 = f.Next(1, 13);
            numAlea = f.Next(1, 13);
            while (numAlea2 == numAlea)
            {
                numAlea2 = f.Next(1, 13);
            }
            asignarColor(numAlea2,1);
            asignarColor(numAlea,2);
            cambioColor = false;
            timer2.Start();            
        }
        private void terminarJuego( String quienGano )
        {
            
            timer1.Stop();
            timer2.Stop();
            label1.Text = quienGano;
            label2.Text = "";
            disableBotons();
            asignarColor(0, 3);
        }
       
        private void asignarColor(int num1,int opc)
        {
            foreach (Control cComponente in panel1.Controls)
            {
                int nueva = Convert.ToInt16(cComponente.Tag);
                //naranja
                if (cComponente is Button && num1==nueva && opc==1)
                {
                   cComponente.BackColor = Color.FromArgb(255, 117, 0);
                }
                //rojo
                else if(cComponente is Button && num1 == nueva && opc == 2)
                {
                    cComponente.BackColor = Color.FromArgb(255, 0, 0);
                }
                //blanco
                else if (cComponente is Button && opc==3)
                {
                    cComponente.BackColor = Color.FromArgb(255, 255, 255); ;
                }        
            }
        }
        private void NuevoJuego(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pnt == 0)
            {
                terminarJuego("perdio");
            }
            else if(pnt>0)
            {
                if (click == false && cambioColor == false)
                pnt = pnt - 1;
                label1.Text = Convert.ToString(pnt);
                click = false;
            }
            else
            {
            }

        }
        private void disableBotons()
        {
            foreach (Control cComponente in panel1.Controls)
            {
                if (cComponente is Button)
                {
                    cComponente.Enabled = false;
                }
            }
            button13.Enabled = false;
            
        }
    }
}
