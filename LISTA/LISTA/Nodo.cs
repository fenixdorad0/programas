using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA
{
    class Nodo
    {
        public int identificacion;
        public Object nomb, apelli, not1, not2, not3, notfinal;
        public Nodo sig;

        //PRIMER CONSTRUCTOR
        public Nodo(int dato, Object nom, Object apell, Object n1, Object n2, Object n3, Object nf)
        {
            identificacion = dato;
            nomb = nom;
            apelli = apell;
            not1 = n1;
            not2 = n2;
            not3 = n3;
            notfinal = nf;
            sig = null;
        }

        //SEGUNDO CONSTRUCTOR
        public Nodo(int dato, Object nom, Object apell, Object n1, Object n2, Object n3, Object nf, Nodo liga)
        {
            identificacion = dato;
            nomb = nom;
            apelli = apell;
            not1 = n1;
            not2 = n2;
            not3 = n3;
            notfinal = nf;
            this.sig = liga;  /////el this solo es para decir que la primera "liga"
        }                          ////es global
    }
}
