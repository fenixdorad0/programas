package listaDoble;
public class NodoLista {
	Integer id;
	Object nomb,apelli,not1,not2,not3,notfinal;
	NodoLista sig,ant;
	public NodoLista(int dato,Object nom,Object apell, Object n1, Object n2, Object n3, Object nf ){
	      id = dato;
	      nomb = nom;
	      apelli = apell;
	      not1 = n1;
	      not2 = n2;
	      not3 = n3;
	      notfinal = nf;
	      sig = null;
	      ant = null;
	  }
	  
	  //SEGUNDO CONSTRUCTOR
	  public NodoLista(int dato,Object nom, Object apell, Object n1, Object n2, Object n3, Object nf, NodoLista s, NodoLista a){
		  id = dato;
	      nomb = nom;
	      apelli = apell;
	      not1 = n1;
	      not2 = n2;
	      not3 = n3;
	      notfinal = nf;
	      this.ant= a;
	      this.sig = s;  /////el this solo es para decir que la primera "liga"
	  }                          ////es global
	  
	}



