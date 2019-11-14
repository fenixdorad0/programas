using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA
{
    class Lista
    {
        public Nodo nodo_primero, nodo_ultimo, auxiliar, nodo_nuevo, nodo_anterior, nodo_siguiente;

        public Lista()
        {
            nodo_primero = nodo_ultimo = auxiliar = nodo_nuevo = nodo_anterior = nodo_siguiente = null;
        }

        public void insertarcola(int dato, Object nom, Object apell, Object n1, Object n2, Object n3, Object nf)
        {
            if (nodo_primero == null)
            {// si la lista esta vacia
                nodo_primero = new Nodo(dato, nom, apell, n1, n2, n3, nf);
                nodo_ultimo = nodo_primero;
            }
            else {//ya hay mas nodos en la lista
                nodo_nuevo = new Nodo(dato, nom, apell, n1, n2, n3, nf);
                nodo_ultimo.sig = nodo_nuevo;
                nodo_ultimo = nodo_nuevo;
            }
            despliegaLista();
        }

        public void insertarcabeza(int dato, Object nom, Object apell, Object n1, Object n2, Object n3, Object nf)
        {
            if (nodo_primero == null)
            {// si la lista esta vacia
                nodo_primero = new Nodo(dato, nom, apell, n1, n2, n3, nf);
                nodo_ultimo = nodo_primero;
            }
            else {
                nodo_nuevo = new Nodo(dato, nom, apell, n1, n2, n3, nf, nodo_primero);
                nodo_primero = nodo_nuevo;
            }
            despliegaLista();
        }
        //----------------------------BUSCAR-------------//
        public void buscar(int busc)
        {
            string cad = "";
            auxiliar = nodo_primero;
            if (auxiliar == null)
                Console.WriteLine("no hay datos en la lista");
            while (auxiliar != null)
            {
                if (auxiliar.identificacion == busc)
                {
                    Console.WriteLine("los datos que pertenecen a la identificacion " + busc + " son:");
                    cad = cad + "identificacion " + auxiliar.identificacion + " \n nombre: " + auxiliar.nomb + " \n apellido: " +
                            auxiliar.apelli + " \n nota1: " +
                            auxiliar.not1 + " \n nota2: " +
                            auxiliar.not2 + " \n nota3: " +
                            auxiliar.not3 + " \n nota final: " +
                            auxiliar.notfinal + "  " +
                             "\n";
                    Console.WriteLine(cad);
                    break;
                }
                auxiliar = auxiliar.sig;
            }
            if (auxiliar == null)
                Console.WriteLine("la identificacion " + busc + " no existe");
        }
        //------------------------Modificar----------------//

        public void modificar(int busc)
        {            
            auxiliar = nodo_primero;
            if (auxiliar == null)
                Console.WriteLine("no hay datos en la lista");
            while (auxiliar != null)
            {
                if (auxiliar.identificacion == busc)
                {
                    Console.WriteLine("los datos que pertenecen a la identificacion " + busc + " son:");
                    /*cad = cad + "identificacion " + auxiliar.identificacion + " \n nombre: " + auxiliar.nomb + " \n apellido: " +
                            auxiliar.apelli + " \n nota1: " +
                            auxiliar.not1 + " \n nota2: " +
                            auxiliar.not2 + " \n nota3: " +
                            auxiliar.not3 + " \n nota final: " +
                            auxiliar.notfinal + "  " +
                             "\n";*/
                    Console.WriteLine("MODIFICA");
                    Console.Write("digite la identificacion: ");
                    auxiliar.identificacion = int.Parse(Console.ReadLine());
                    Console.Write("Digite el nombre: ");
                    auxiliar.nomb = Console.ReadLine();
                    Console.Write("Digite el apellido: ");
                    auxiliar.apelli = Console.ReadLine();
                    Console.Write("Digite la nota 1: ");
                    auxiliar.not1 = double.Parse(Console.ReadLine());
                    double n1 = Convert.ToDouble(auxiliar.not1);
                    Console.Write("Digite la nota 2: ");
                    auxiliar.not2 = double.Parse(Console.ReadLine());
                    double n2 = Convert.ToDouble(auxiliar.not2);
                    Console.Write("Digite la nota 3: ");
                    auxiliar.not3 = double.Parse(Console.ReadLine());
                    double n3 = Convert.ToDouble(auxiliar.not3);
                    auxiliar.notfinal = (n1 * 0.3 + n2 * 0.3 + n3 * 0.4);
                    //Console.WriteLine(cad);
                    break;
                }
                auxiliar = auxiliar.sig;
            }
            if (auxiliar == null)
                Console.WriteLine("la identificacion " + busc + " no existe");
        }
        //--------------------Eliminar------------------------//
        public void Eliminar(int busc)
        {
            auxiliar = nodo_primero;
            if (auxiliar != null)
            {               
                if (auxiliar == nodo_ultimo && auxiliar.identificacion == busc) //eliminar si es el primer nodo y la lista solo tiene un dato//
                {
                    Console.WriteLine("los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + auxiliar.identificacion + " \t nombre: " + auxiliar.nomb + " \t apellido: " + auxiliar.apelli + " \t nota1: " + auxiliar.not1 + " \t nota2: " + auxiliar.not2 + " \t nota3: " + auxiliar.not3 + " \t nota final: " + auxiliar.notfinal);
                    auxiliar = nodo_ultimo = null; //nodo_primero pasa a ser el ultimo y ser igual a null//
                }
                else if (auxiliar.identificacion == busc)  // si el nodo a eliminar es el primero sin la lista estar vacia//
                {
                    nodo_primero = auxiliar.sig; //apuntar inicio al siguiente nodo//
                    Console.WriteLine("los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + auxiliar.identificacion + " \t nombre: " + auxiliar.nomb + " \t apellido: " + auxiliar.apelli + " \t nota1: " + auxiliar.not1 + " \t nota2: " + auxiliar.not2 + " \t nota3: " + auxiliar.not3 + " \t nota final: " + auxiliar.notfinal);
                }
                else
                {
                    Nodo anterior, temporal; // se crean dos punteros//
                    anterior = nodo_primero; // anterior igual al nodo_primero//
                    temporal = nodo_primero.sig; // temporal igual al siguiente nodo del nodo actual o nodo_primero//
                    while (temporal != null && temporal.identificacion != busc) // se realiza un ciclo mientras que temporal no sea null//                                                                   
                    {                                                          //  y el nodo no sea igual a la identificacion a eliminar//    
                        anterior = anterior.sig; // los apuntadores cambian conforme avanza el ciclo//
                        temporal = temporal.sig;
                    }
                    if (temporal != null)  // es decir que encontro el nodo a eliminar//
                    {
                        anterior.sig = temporal.sig;
                        Console.WriteLine("los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + auxiliar.identificacion + " \t nombre: " + auxiliar.nomb + " \t apellido: " + auxiliar.apelli + " \t nota1: " + auxiliar.not1 + " \t nota2: " + auxiliar.not2 + " \t nota3: " + auxiliar.not3 + " \t nota final: " + auxiliar.notfinal);
                        if (temporal == nodo_ultimo)
                        {
                            nodo_ultimo = anterior;

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("no hay datos en la lista");
            }                               
        }
        //------------------------------------------------------------//
        public void despliegaLista()
        {
            string cad = "";
            auxiliar = nodo_primero;
            if (auxiliar == null)
            {
                Console.WriteLine("no hay datos en la lista");
            }                
            while (auxiliar != null)
            {
                cad = cad + "identificacion " + auxiliar.identificacion + " \n| nombre: " + auxiliar.nomb + " |apellido: " +
                        auxiliar.apelli + " |nota1: " +
                        auxiliar.not1 + " |nota2: " +
                        auxiliar.not2 + " |nota3: " +
                        auxiliar.not3 + " |nota final: " +
                        auxiliar.notfinal + "  |" +
                         "\n";
                auxiliar = auxiliar.sig;
            }
            Console.WriteLine(cad);

        }

    }
}

