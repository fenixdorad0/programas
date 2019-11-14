using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA
{
    class Program
    {
        class EleccionLista //contiene los datos que almacenara la lista //
        {
            static int identificacion, busqueda;
            static string nombre, apellido;
            static double nota_1, nota_2, nota_3, nota_final;
            //----------------------------------------------------------------------------------//
            static void Main(string[] args)
            {
                Lista lista = new Lista();

                bool fin_programa = true;
                do
                {
                    Console.WriteLine("Digite la opcion que desea realizar con la lista");
                    Console.WriteLine("(1) Insertar en la cabeza \n(2) Insertar en la cola  \n(3) DesplegarLista \n(4) Buscar \n(5) Modificar \n(6) Eliminar \n(7) Salir del programa");
                    Console.Write("Elige: ");
                    byte opcion = byte.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Elegiste Insertar dato por la cabeza");
                            Console.Write("digite la identificacion: ");
                            identificacion = int.Parse(Console.ReadLine());
                            Console.Write("Digite el nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("Digite el apellido: ");
                            apellido = Console.ReadLine();
                            Console.Write("Digite la nota 1: ");
                            nota_1 = double.Parse(Console.ReadLine());
                            Console.Write("Digite la nota 2: ");
                            nota_2 = double.Parse(Console.ReadLine());
                            Console.Write("Digite la nota 3: ");
                            nota_3 = double.Parse(Console.ReadLine());
                            nota_final = (nota_1 * 0.3 + nota_2 * 0.3 + nota_3 * 0.4);
                            lista.insertarcabeza(identificacion,nombre,apellido,nota_1,nota_2,nota_3,nota_final);
                            break;

                        case 2:
                            Console.WriteLine("Elegiste Insertar dato por la cola");
                            Console.Write("digite la identificacion: ");
                            identificacion = int.Parse(Console.ReadLine());
                            Console.Write("Digite el nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("Digite el apellido: ");
                            apellido = Console.ReadLine();
                            Console.Write("Digite la nota 1: ");
                            nota_1 = double.Parse(Console.ReadLine());
                            Console.Write("Digite la nota 2: ");
                            nota_2 = double.Parse(Console.ReadLine());
                            Console.Write("Digite la nota 3: ");
                            nota_3 = double.Parse(Console.ReadLine());
                            nota_final = (nota_1 * 0.3 + nota_2 * 0.3 + nota_3 * 0.4);
                            lista.insertarcola(identificacion, nombre, apellido, nota_1, nota_2, nota_3, nota_final);
                            break;

                        case 3:
                            Console.WriteLine("Eligiste desplegar la lista");
                            lista.despliegaLista();
                            break;

                        case 4:
                            Console.WriteLine("Digite la identificacion a buscar: ");
                            busqueda = int.Parse(Console.ReadLine());
                            lista.buscar(busqueda);
                            break;

                        case 5:
                            Console.WriteLine("Elegiste modificar");
                            Console.WriteLine("Digite la identificacion a modificar: ");
                            busqueda = int.Parse(Console.ReadLine());
                            lista.modificar(busqueda);
                            break;

                        case 6:
                            Console.WriteLine("Elegiste eliminarr");
                            Console.WriteLine("Digite la identificacion a eliminar: ");
                            busqueda = int.Parse(Console.ReadLine());
                            lista.Eliminar(busqueda);
                            break;

                        case 7:
                            fin_programa = false;
                            Console.WriteLine("Gracias por utilizar este aplicativo");
                            Console.WriteLine("Saliendo...");
                            break;

                        default:
                            Console.WriteLine("La opcion no existe");
                            break;
                    }

                } while (fin_programa);

                Console.Read();
            }       
        }
    }
}
