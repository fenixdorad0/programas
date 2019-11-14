using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;


namespace Ping_LoL
{
    public partial class Form1 : Form
    {       
        int x, y = 0;
        
        public Form1()
        {
            InitializeComponent();
            HeapSort hs = new HeapSort();
            

        }
    

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        private void Imprimir(int val)
        {
            if (val > 0)
            {
                MessageBox.Show(Convert.ToString(val));
                Imprimir(val - 1);
            }
        }
        
        void ordenar(int[] arreglo, int longitud)
        {

            int cont = 0, cambio = 0;
            if (longitud > 1)
            { 
                cont = 0;
                while (cont < longitud - 1)
                {
                    if (arreglo[cont + 1] < arreglo[cont])
                    {
                        cambio = arreglo[cont + 1];
                        arreglo[cont + 1] = arreglo[cont];
                        arreglo[cont] = cambio;
                    }
                    cont++;
                }

                ordenar(arreglo, longitud - 1);
            }
            else { }


        }
        

        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            int cont = 0;          
            
            
            try
            {
                             

                int longitud = Convert.ToInt32(textBox1.Text);
                //int valorbus = Convert.ToInt32(valBuscado.Text);
                int[] arreglo;
                arreglo = new int[longitud];
                ingresarDatos(longitud, arreglo);

                //heapsort inicio
                HeapSort hs = new HeapSort();
                //heapsort fin

               
                TimeSpan stop1;
                TimeSpan start1 = new TimeSpan(DateTime.Now.Ticks);
                //ordenando
                hs.PerformHeapSort(arreglo);
                //heapsor fin
                stop1 = new TimeSpan(DateTime.Now.Ticks);
                double tiempoOrdenando=stop1.Subtract(start1).TotalMilliseconds;
                chartOrdenado.Series["tiempos"].Points.AddXY(cont, tiempoOrdenando);
                MessageBox.Show(verDatos(longitud, arreglo));
                /*
                TimeSpan stop;
                TimeSpan start = new TimeSpan(DateTime.Now.Ticks);            
                int encontrado = interpolacion(arreglo, 0, longitud - 1, (longitud-2)*10);
                stop = new TimeSpan(DateTime.Now.Ticks);
                Console.WriteLine(stop.Subtract(start).TotalMilliseconds);
                double tiempoBuscado = stop.Subtract(start).TotalMilliseconds;
                chartBusqeda.Series["tiempos"].Points.AddXY(cont, tiempoBuscado);
                MessageBox.Show(verDatos(longitud, arreglo));
                if (encontrado == -1 || encontrado==0)
                {
                    //MessageBox.Show("No encontrado");
                }
                else
                {
                    MessageBox.Show(Convert.ToString( encontrado));
                }
                */
                cont++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private static void ingresarDatos(int longitud, int[] arreglo)
        {
            int i = 0;
            Random rnd = new Random();

            while (i < longitud)
            {                
                arreglo[i] = rnd.Next(1,longitud);                         
                
               //arreglo[i] = i * 10;
               i++;
            }

        }

        private string verDatos(int longitud, int[] arreglo)
        {
            int i = 0;
            String cadena = "";
            while (i < (longitud))
            {
                cadena = cadena + " " + Convert.ToString(arreglo[i]);
                i++;
            }
            return cadena;
        }

           public int interpolacion(int[] arreglo, int izquierda, int derecha, int valorbuscado)
        {
            int posicion = 0;
            int encontrado = 0;
            while ((izquierda <= derecha) & (valorbuscado >= arreglo[izquierda]) & (valorbuscado <= arreglo[derecha]) & (izquierda != derecha))
            {
                posicion = (izquierda + (((derecha - izquierda) / (arreglo[derecha] - arreglo[izquierda])) * (valorbuscado - arreglo[izquierda])));
                if (arreglo[posicion] == valorbuscado)
                {
                    //Console.WriteLine("encontrado" +"estoy en "+arreglo[posicion]+"busco: "+valorbuscado );
                    encontrado = posicion;
                    izquierda = derecha;
                    break;
                }
                else if (arreglo[posicion] < valorbuscado)
                {
                    izquierda = posicion + 1;
                    //Console.WriteLine("no encontrado" + "estoy en "+arreglo[posicion] + "busco: " + valorbuscado);
                }
              
                else
                {
                    derecha = posicion - 1;
                    encontrado = -1;
                    
                }            
            }
            return encontrado;
        }
    }
}



