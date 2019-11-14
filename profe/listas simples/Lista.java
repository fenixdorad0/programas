package estructuras;

import javax.swing.JOptionPane;

////clase que manipula a los punteros para manipular los nodos en la memoria

public class Lista {
// declarar los punteros!!!
NodoLista Primero, ultimo, aux, nuevo, ant, post;

public Lista(){
   Primero = ultimo = aux = nuevo = ant = post = null;
}

public void insertarcola(int dato, Object nom,Object apell, Object n1, Object n2, Object n3, Object nf ){
   if(Primero==null){// si la lista esta vacia
       Primero = new NodoLista(dato,nom,apell,n1,n2,n3,nf);
       ultimo=Primero;
   }
   else{////ya hay mas nodos en la lista
       nuevo = new NodoLista(dato,nom,apell,n1,n2,n3,nf);
       ultimo.sig = nuevo;
       ultimo = nuevo;
   }despliegaLista();          
}

public void insertarcabeza(int dato,Object nom,Object apell, Object n1, Object n2, Object n3, Object nf){
   if(Primero==null){// si la lista esta vacia
       Primero = new NodoLista(dato,nom,apell,n1,n2,n3,nf);
       ultimo=Primero;
   }
   else{
       nuevo = new NodoLista(dato,nom,apell,n1,n2,n3,nf,Primero);
       Primero = nuevo;
   }despliegaLista();
}    
public void buscar(int busc){
	String cad = "";
	aux = Primero;
	if(aux == null)
		JOptionPane.showMessageDialog(null, "no hay datos en la lista");
	   while (aux != null) {
		   if(aux.id == busc){
			   JOptionPane.showMessageDialog(null, "los datos que pertenecen a la identificacion "+busc+ " son:");
			   cad = cad +"identificacion "+aux.id+" \n nombre: "+ aux.nomb + " \n apellido: " +
					   aux.apelli + " \n nota1: " +
					   aux.not1+ " \n nota2: " +
					   aux.not2 + " \n nota3: " +
					   aux.not3+ " \n nota final: " +
					   aux.notfinal + "  " +
						"\n";
			   JOptionPane.showMessageDialog( null, cad );
			   break;
		   }
	       aux = aux.sig;
	   }
	   if(aux==null)
		   JOptionPane.showMessageDialog(null, "la identificacion "+busc+" no existe");
}
public void despliegaLista(){
String cad = "";
   aux = Primero;
   if(aux == null)
		JOptionPane.showMessageDialog(null, "no hay datos en la lista");
 
   while (aux != null) {
	   cad = cad +"identificacion "+aux.id+" \n| nombre: "+ aux.nomb + " |apellido: " +
			   aux.apelli + " |nota1: " +
			   aux.not1+ " |nota2: " +
			   aux.not2 + " |nota3: " +
			   aux.not3+ " |nota final: " +
			   aux.notfinal + "  |" +
				"\n";
       aux = aux.sig;
   }
   JOptionPane.showMessageDialog( null, cad );
 
}

}
