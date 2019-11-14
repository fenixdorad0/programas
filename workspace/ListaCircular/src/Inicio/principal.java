package Inicio;
import javax.swing.JOptionPane;
public class principal {
NodoLista Primero, ultimo, aux, nuevo, ant, post;
String log;
public principal(){
   Primero = ultimo = aux = nuevo = ant = post = null;
}
public void insercabeza(int dato, Object nom,Object apell, Object n1, Object n2, Object n3, Object nf ){
   if(Primero==null){// si la lista esta vacia
       Primero=ultimo = new NodoLista(dato,nom,apell,n1,n2,n3,nf);
   }
   else{////ya hay mas nodos en la lista
	   //anterior apunta a null
	   Primero = new NodoLista(dato,nom,apell,n1,n2,n3,nf,Primero,null);
       Primero.sig.ant=Primero;
	   }          
}

public void insertarcola(int dato,Object nom,Object apell, Object n1, Object n2, Object n3, Object nf){
   if(Primero==null){// si la lista esta vacia
       Primero =ultimo= new NodoLista(dato,nom,apell,n1,n2,n3,nf);  
   }
   else{
       ultimo = new NodoLista(dato,nom,apell,n1,n2,n3,nf,null,ultimo);
       ultimo.ant.sig=ultimo;
       
   }
}
public void log (){
	JOptionPane.showMessageDialog(null, log);
}
public boolean estavacio (){
	boolean respuesta=false;
	if (ultimo==null){
		respuesta=true;;
	}
	else{
		respuesta=false;
	}
	return respuesta;
}
public void buscar(int busc, String s){
	String cad = "";
	aux = Primero;
	if (s.equals("buscar")){
	if(aux == null){
		JOptionPane.showMessageDialog(null, "no hay datos en la lista");
		log=log+"buscar, no se encontraron datos"+"\n";
	}
	   while (aux != null) {
		   if(aux.id == busc){
			   JOptionPane.showMessageDialog(null, "los datos que pertenecen a la identificacion "+busc+ " son:");
			   cad = cad +" identificacion: "+aux.id+" \n "
			   		     +"nombre: "+ aux.nomb + " \n apellido: " +
					   	   aux.apelli + " \n nota1: " +
					       aux.not1+ " \n nota2: " +
					       aux.not2 + " \n nota3: " +
					       aux.not3+ " \n nota final: " +
					       aux.notfinal + "  " +
						   "\n";
			  JOptionPane.showMessageDialog(null, cad);
			  
			   break;
		   }
	       aux = aux.sig;
	       }
	   log=log+"se busco "+busc+" y se encontro"+"\n";
	   if(aux==null){
		   JOptionPane.showMessageDialog(null, "la identificacion "+busc+" no existe");
		   log=log+"se busco "+busc+" y se encontro"+"\n";
	   }
	}
	else if (s.equals("buscar en bloque")){
		
		while(aux!=null){
			if (busc==aux.id){
			   cad = cad +"ID "+aux.id+" | nombre: "+ aux.nomb +" "+aux.apelli +" "+ "notas |" +" "+aux.not1+ "| " +aux.not2 + "| " +aux.not3+ " | nota final: " +aux.notfinal + "  " +	"\n";	  	
			}
		aux = aux.sig;
		}
		JOptionPane.showMessageDialog(null, cad);
	}
	else if (s.equals("modificar")){
		int cont=0;
		post=Primero;
		while (post!= null){
			if (busc==post.id){
				cont=cont+1;
			}
			post=post.sig;
		}
		if (cont>0){			
		log=log+"se busco en bloque "+busc+" y se encontro"+"\n";
		aux=Primero;
		while (aux!= null){
		if (aux.id==busc){
			String desicion;
			String opciones[]={"todo","identificacion","nombre","apellido","notas","finalizar"};			   
		    desicion = (String)JOptionPane.showInputDialog(null,"señor usuario que desea modificar", "lista doble",JOptionPane.INFORMATION_MESSAGE,null,opciones, opciones[0]);
		    	switch (desicion) {
		         	case "todo":				   
		 			    aux.id = funciones.leer_entero("Digite el nuevo numero de identificación ");
		                aux.nomb= JOptionPane.showInputDialog("Digite el nuevo nombre de la persona ");
		                aux.apelli=JOptionPane.showInputDialog("Digite el apellido de "+aux.nomb);
		                notas();
		                break;
		          	case "identificacion":
		           		aux.id = funciones.leer_entero("Digite el nuevo numero de identificación ");
		           		break;
		           	case "nombre":
		        		aux.nomb= JOptionPane.showInputDialog("Digite el nuevo nombre de la persona ");
		        		break;
		            case "apellido":
		               	aux.apelli=JOptionPane.showInputDialog("Digite el apellido de "+aux.nomb);
		               	break;
		            case "notas":
		               	notas();
		                break;
		            case "finalizar":
		               	JOptionPane.showMessageDialog(null,"Los cambios se han realizado exitosamente");
		               	break;
		            default :JOptionPane.showMessageDialog(null, "opcion no valida, intenta de nuevo");
		               	}
		        	break;
		}
		aux = aux.sig;
		}
		}
		else{
		JOptionPane.showMessageDialog(null, "no se encontro la id");
		log=log+"se busco "+busc+" y NO se encontro"+"\n";
		}
		
	}
	else if (s.equals("modificar en bloque id")){
		int cont=0;
		post=Primero;
		while (post!= null){
			if (busc==post.id){
				cont=cont+1;
			}
			post=post.sig;
		}
		aux=Primero;
		if (cont>0){
			String desicion;
			String opciones[]={"todo","identificacion","nombre","apellido","notas","finalizar"};
			desicion = (String)JOptionPane.showInputDialog(null,"señor usuario que desea modificar", "lista doble",JOptionPane.INFORMATION_MESSAGE,null,opciones, opciones[0]);
		    String nomb,apelli;
		    int id;
		    double not1,not2,not3,notf;
		    switch (desicion) {
		       	case "todo":				   
		       		id = funciones.leer_entero("Digite el nuevo numero de identificación ");
		            nomb= JOptionPane.showInputDialog("Digite el nuevo nombre de la persona ");
		            apelli=JOptionPane.showInputDialog("Digite el apellido de "+aux.nomb);
		            not1=funciones.leer_nota("Digite la nueva nota 1 de "+nomb+" "+apelli);
		            not2=funciones.leer_nota("Digite la nueva nota 2 de "+nomb+" "+apelli);
		            not3=funciones.leer_nota("Digite la nueva nota 3 de "+nomb+" "+apelli);
		            notf=(not1*0.3)+(not2*0.3)+(not3*0.4);
		            log=log+"se modifico "+busc+" y se modifico todo"+"\n";
		            	while (aux!= null){
		                 	//1,1 =1
		            		if (busc==aux.id){
		            			aux.id=id;
				        		aux.nomb=nomb;
				        		aux.apelli=apelli;
				        		aux.not1=not1;
				        		aux.not2=not2;
				        		aux.not3=not3;
				        		aux.notfinal=notf;
				        		}
				        		aux = aux.sig;
				        	}
		            	break;
		        case "identificacion":
		        	id = funciones.leer_entero("Digite el nuevo numero de identificación ");
		            while (aux!= null){
		            	if (busc==aux.id){
		            		aux.id=id;					        				        			
					        }
					        aux = aux.sig;
		            		}
		            log=log+"se busco "+busc+" y se modifico la ID"+"\n";
		        		break;
		        case "nombre":
		        	nomb= JOptionPane.showInputDialog("Digite el nuevo nombre de la persona ");
		            while (aux!= null){
		            	if (busc==aux.id){
		            		aux.nomb=nomb;					        				        			
						    }
						    aux = aux.sig;
						    }
		            log=log+"se busco "+busc+" y se modifico el nombre"+"\n";
		            		break;
		        case "apellido":
		           	aux.apelli=JOptionPane.showInputDialog("Digite el apellido de "+aux.nomb);
		           	log=log+"se busco"+busc+" y se modigo el apellido"+"\n";
		           	break;
		        case "notas":
		        	not1=funciones.leer_nota("Digite la nueva nota 1 de "+aux.nomb+" "+aux.apelli);
	                not2=funciones.leer_nota("Digite la nueva nota 2 de "+aux.nomb+" "+aux.apelli);
	                not3=funciones.leer_nota("Digite la nueva nota 3 de "+aux.nomb+" "+aux.apelli);
	                notf=(not1*0.3)+(not2*0.3)+(not3*0.4);
	                log=log+"se busco  "+busc+" y se modificaron las notas"+"\n";
	                while (aux!= null){
	                   	//1,1 =1
	                	if (busc==aux.id){			        			
			        	aux.not1=not1;
			        	aux.not2=not2;
			        	aux.not3=not3;
			        	aux.notfinal=notf;
			        		}
			        		aux = aux.sig;
			        	}
		                break;
		         case "finalizar":
		           	JOptionPane.showMessageDialog(null,"Los cambios no se realizaron ");
		           	log=log+"se busco "+busc+" y no se realizaron cambios"+"\n";
		           	break;
		            default :JOptionPane.showMessageDialog(null, "opcion no valida, intenta de nuevo");
		             	}
		        	while (aux!= null){
		        		if (aux.id==busc){	
		        		}
		        		aux = aux.sig;
		        	}
		}
		else{
			JOptionPane.showMessageDialog(null, "no se encontro esa id");
			log=log+"se busco "+busc+" no se encontro"+"\n";
		}		
	}
	
	else if (s.equals("eliminar")){
		eliminar(busc);
		log=log+"se busco "+busc+" y se elimino"+"\n";
    }
	else if (s.equals("eliminar en bloque")){
		aux=Primero;
		int cont=0;
		while(aux!=null){
			if (busc==aux.id){
				cont=cont+1;
			}
			aux=aux.sig;
		}
		
		if (cont>0){
		for (int f = 0; f < cont; f++) {
			aux=Primero;
		if (aux != null)
		{               
		    if (aux == ultimo && aux.id == busc) //eliminar si es el primer nodo y la lista solo tiene un dato//
		    {
		        
		        aux = ultimo = null; //nodo_primero pasa a ser el ultimo y ser igual a null//
		        Primero=null;
		    }
		    else if (aux.id == busc)  // si el nodo a eliminar es el primero sin la lista estar vacia//
		    {
		        Primero = aux.sig; //apuntar inicio al siguiente nodo//
		        
		    }
		    else
		    {
		        //anterior, temporal; // se crean dos punteros//
		        ant = Primero; // anterior igual al nodo_primero//
		        post = Primero.sig; // temporal igual al siguiente nodo del nodo actual o nodo_primero//
		        while (post != null && post.id != busc) // se realiza un ciclo mientras que temporal no sea null//                                                                   
		        {                                                          //  y el nodo no sea igual a la identificacion a eliminar//    
		            ant = ant.sig; // los apuntadores cambian conforme avanza el ciclo//
		            post = post.sig;
		        }
		        if (post != null)  // es decir que encontro el nodo a eliminar//
		        {
		            ant.sig = post.sig;
		            if (post == ultimo)
		            {
		                ultimo = ant;

		            }
		        }
		    }
		}		
		}
		JOptionPane.showMessageDialog(null,"Las eliminaciones se han completado exitosamente");
		log=log+"se busco "+busc+" y se ELIMINARON TODAS SUS IDS"+"\n";
		}
		else{
			JOptionPane.showMessageDialog(null,"no se encontro la id en la lista");
			log=log+"se busco "+busc+" y no se encontro la id a ELIMINAR "+"\n";
		}
			

		                               
    }

	else if (s.equals("insertar")){
		log=log+"se inserto "+busc+""+"\n";
		opcion3(cad);
	   }
}

public void eliminar(int busc) {
	if (aux != null)
	{               
	    if (aux == ultimo && aux.id == busc) //eliminar si es el primer nodo y la lista solo tiene un dato//
	    {
	        JOptionPane.showMessageDialog(null,"los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + aux.id + " \t nombre: " + aux.nomb + " \t apellido: " + aux.apelli + " \t nota1: " + aux.not1 + " \t nota2: " + aux.not2 + " \t nota3: " + aux.not3 + " \t nota final: " + aux.notfinal);
	        aux = ultimo = null; //nodo_primero pasa a ser el ultimo y ser igual a null//
	        Primero=null;
	    }
	    else if (aux.id == busc)  // si el nodo a eliminar es el primero sin la lista estar vacia//
	    {
	        Primero = aux.sig; //apuntar inicio al siguiente nodo//
	        JOptionPane.showMessageDialog(null,"los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + aux.id + " \t nombre: " + aux.nomb + " \t apellido: " + aux.apelli + " \t nota1: " + aux.not1 + " \t nota2: " + aux.not2 + " \t nota3: " + aux.not3 + " \t nota final: " + aux.notfinal);
	    }
	    else
	    {
	        //anterior, temporal; // se crean dos punteros//
	        ant = Primero; // anterior igual al nodo_primero//
	        post = Primero.sig; // temporal igual al siguiente nodo del nodo actual o nodo_primero//
	        while (post != null && post.id != busc) // se realiza un ciclo mientras que temporal no sea null//                                                                   
	        {                                                          //  y el nodo no sea igual a la identificacion a eliminar//    
	            ant = ant.sig; // los apuntadores cambian conforme avanza el ciclo//
	            post = post.sig;
	        }
	        if (post != null)  // es decir que encontro el nodo a eliminar//
	        {
	            ant.sig = post.sig;
	            JOptionPane.showMessageDialog(null,"los datos que pertenecen a la identificacion " + busc + "  a eliminar son: \n" + "identificacion: " + aux.id + " \t nombre: " + aux.nomb + " \t apellido: " + aux.apelli + " \t nota1: " + aux.not1 + " \t nota2: " + aux.not2 + " \t nota3: " + aux.not3 + " \t nota final: " + aux.notfinal);
	            if (post == ultimo)
	            {
	                ultimo = ant;

	            }
	        }
	    }
	}
	else
	{
		JOptionPane.showMessageDialog(null,"no hay datos en la lista");
	}
}

public void opcion3(String cad) {
	String opcionesInsertar[]={"Despues de","Antes de"},desicionInsertar;
	desicionInsertar = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista doble",JOptionPane.INFORMATION_MESSAGE,null,opcionesInsertar, opcionesInsertar[0]);
	switch (desicionInsertar) {
	case "Antes de":
		if (aux==Primero && aux.sig==null){//si antes de 1
			int identificacion = funciones.leer_entero("Digite el numero de identificacion");
			String nombre= JOptionPane.showInputDialog("Digite el nombre de la persona");
			while (nombre.isEmpty()){
				nombre =JOptionPane.showInputDialog("Digite el nombre de la persona");
			}		
			String apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
			while (apellido.isEmpty()){
				apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
			}
			double nota1=funciones.leer_nota("Digite la nota 1 de "+nombre+" "+apellido);
			double nota2=funciones.leer_nota("Digite la nota 2 de "+nombre+" "+apellido);
			double nota3=funciones.leer_nota("Digite la nota 3 de "+nombre+" "+apellido);                       
			double notadefinitiva=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
			insercabeza(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
		}
		else {
			
		}
		break;
	case "Despues de":
		if (aux.sig==null){//despues del ultimo
			int identificacion = funciones.leer_entero("Digite el numero de identificacion");
			String nombre= JOptionPane.showInputDialog("Digite el nombre de la persona");
			while (nombre.isEmpty()){
				nombre =JOptionPane.showInputDialog("Digite el nombre de la persona");
			}		
			String apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
			while (apellido.isEmpty()){
				apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
			}
			double nota1=funciones.leer_nota("Digite la nota 1 de "+nombre+" "+apellido);
			double nota2=funciones.leer_nota("Digite la nota 2 de "+nombre+" "+apellido);
			double nota3=funciones.leer_nota("Digite la nota 3 de "+nombre+" "+apellido);                       
			double notadefinitiva=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
	        insertarcola(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
		}
		else{
			JOptionPane.showMessageDialog( null, cad );				   
		    nuevo.id = funciones.leer_entero("Digite el nuevo numero de identificación ");
		    nuevo.nomb= JOptionPane.showInputDialog("Digite el nuevo nombre de la persona ");
		    nuevo.apelli=JOptionPane.showInputDialog("Digite el apellido de "+aux.nomb);
	        double nota1=funciones.leer_nota("Digite la nueva nota 1 de "+nuevo.nomb+" "+nuevo.apelli);
	    	double nota2=funciones.leer_nota("Digite la nueva nota 2 de "+nuevo.nomb+" "+nuevo.apelli);
	    	double nota3=funciones.leer_nota("Digite la nueva nota 3 de "+nuevo.nomb+" "+nuevo.apelli);
	    	double notadefinitiva=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
	    	nuevo.not1=nota1;
	    	nuevo.not2=nota2;
	    	nuevo.not3=nota3;
	    	nuevo.notfinal=notadefinitiva;
			nuevo.sig=aux.sig;
			aux.sig=nuevo;
		}
		break;
	}
}
public void notas() {
	double nota1=funciones.leer_nota("Digite la nueva nota 1 de "+aux.nomb+" "+aux.apelli);
	double nota2=funciones.leer_nota("Digite la nueva nota 2 de "+aux.nomb+" "+aux.apelli);
	double nota3=funciones.leer_nota("Digite la nueva nota 3 de "+aux.nomb+" "+aux.apelli);
	double notadefinitiva=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
	aux.not1=nota1;
	aux.not2=nota2;
	aux.not3=nota3;
	aux.notfinal=notadefinitiva;
}
public void despliegaLista(){
	String cad = "";
	aux = Primero;
	
	if(aux == null){
		JOptionPane.showMessageDialog(null, "no hay datos en la lista");
	}
	while(aux!=null){
		cad = cad +"ID "+aux.id+" | nombre: "+ aux.nomb +" "+aux.apelli +" "+ "notas |" +" "+aux.not1+ "| " +aux.not2 + "| " +aux.not3+ " | nota final: " +aux.notfinal + "  " +"\n";	 
		aux = aux.sig;   		        
		}
	JOptionPane.showMessageDialog(null, cad);
	}
public void buscarString(String buscador, String modificarString) {
	
	if (modificarString.equals("modificar en bloque nombre")){
			aux=Primero;
			String nuevoNombre=JOptionPane.showInputDialog("Digite el nuevo nombre");
			while(aux!=null){
				if (buscador.equals(aux.nomb)){
				aux.nomb=nuevoNombre;
			}
				aux=aux.sig;
		}
	
	}
	else if (modificarString.equals("modificar en bloque apellido")){
		aux=Primero;
		String nuevoNombre=JOptionPane.showInputDialog("Digite el nuevo apellido");
		while(aux!=null){
			if (buscador.equals(aux.apelli)){
			aux.apelli=nuevoNombre;
		}
			aux=aux.sig;
	}


		
	}
		
	
}
public void buscarNotas(int notMin, int notMax) {
	double nota1,nota2,nota3;
	double agregarPnts=new Double(JOptionPane.showInputDialog("Digite los puntos a agregar"));
	while (agregarPnts<0 || agregarPnts>2 ){
		JOptionPane.showMessageDialog(null, "los puntos no pueden ser superiores a 2 o inferiores a 0");
		agregarPnts=new Double(JOptionPane.showInputDialog("Digite los puntos a agregar"));
	}
	String opcionesNotas[]={"nota1","nota2","nota3"};
	String desicionNotas = (String)JOptionPane.showInputDialog(null,"señor usuario que desea modificar", "lista doble",JOptionPane.INFORMATION_MESSAGE,null,opcionesNotas, opcionesNotas[0]);
	if (desicionNotas.equals("nota1")){
		aux=Primero;
		while(aux!=null){
			double notfinal=(double) aux.notfinal;
			if(notfinal>=notMin && notfinal<=notMax && notfinal<=4){
				double result=(double) aux.not1+agregarPnts;			
				aux.not1=result;
				while(result>5){
					JOptionPane.showMessageDialog(null, "el resultado no puede ser mayor a 5");
					agregarPnts=new Double(JOptionPane.showInputDialog("Digite los puntos a agregar"));
					result=(double) aux.not1+agregarPnts;
				}
				nota1=(double) aux.not1;
				nota2=(double) aux.not2;
				nota3=(double) aux.not3;
				double resultadoNotfinal=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
				aux.notfinal=resultadoNotfinal;
						}
			aux=aux.sig;
		}
	}
	if (desicionNotas.equals("nota2")){
		aux=Primero;
		while(aux!=null){
			double notfinal=(double) aux.notfinal;
			if(notfinal>=notMin && notfinal<=notMax && notfinal<=4){
				double result=(double) aux.not2+agregarPnts;			
				aux.not2=result;
				while(result>5){
					JOptionPane.showMessageDialog(null, "el resultado no puede ser mayor a 5");
					agregarPnts=new Double(JOptionPane.showInputDialog("Digite los puntos a agregar"));
					result=(double) aux.not2+agregarPnts;
				}
				nota1=(double) aux.not1;
				nota2=(double) aux.not2;
				nota3=(double) aux.not3;
				double resultadoNotfinal=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
				aux.notfinal=resultadoNotfinal;
						}
			aux=aux.sig;
		}
	}
	if (desicionNotas.equals("nota3")){
		aux=Primero;
		while(aux!=null){
			double notfinal=(double) aux.notfinal;
			if(notfinal>=notMin && notfinal<=notMax && notfinal<=4){
				double result=(double) aux.not3+agregarPnts;			
				aux.not3=result;
				while(result>5){
					JOptionPane.showMessageDialog(null, "el resultado no puede ser mayor a 5");
					agregarPnts=new Double(JOptionPane.showInputDialog("Digite los puntos a agregar"));
					result=(double) aux.not3+agregarPnts;
				}
				nota1=(double) aux.not1;
				nota2=(double) aux.not2;
				nota3=(double) aux.not3;
				double resultadoNotfinal=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
				aux.notfinal=resultadoNotfinal;
						}
			aux=aux.sig;
		}
	}
	
	
	
}
public void desplegarDecendente(){
	aux=ultimo;
	String cad="";
	while(aux!=null){
		cad = cad +"ID "+aux.id+" | nombre: "+ aux.nomb +" "+aux.apelli +" "+ "notas |" +" "+aux.not1+ "| " +aux.not2 + "| " +aux.not3+ " | nota final: " +aux.notfinal + "  " +"\n";
		aux=aux.ant;
	}
	JOptionPane.showMessageDialog(null, cad);
}
}