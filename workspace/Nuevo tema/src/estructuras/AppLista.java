package estructuras;
import javax.swing.JOptionPane;
public class AppLista{
	static Integer identificacion,buscador;       
    static String nombre,apellido,buscadorString;
    static Double nota1,nota2,nota3,notadefinitiva;
    public static void main(String args[]){
        Lista lista = new Lista();
        String opciones[]={"insertar","desplegar lista", "buscar","modificar","eliminar","log", "salir del programa"},desicion;
        do{
        	desicion = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opciones, opciones[0]);
            switch (desicion) {            
            	case "modificar":
            		if (lista.estavacio()==false){
            			String opcionesModificar[]={"normal","bloque"},desicionModificar;
            			desicionModificar = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opcionesModificar, opcionesModificar[0]);
            			if (desicionModificar.equals("normal")){
            				lista.despliegaLista();
            				buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a modificar"));
            				lista.buscar(buscador,"modificar");
            				lista.despliegaLista();
            				}
            		else if (desicionModificar.equals("bloque")){
                			String opcionesModificarCriterio[]={"id","nombre","apellido","nota"},desicionModificarCriterio;
                			desicionModificarCriterio = (String)JOptionPane.showInputDialog(null,"Seleccione el criterio de busqueda", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opcionesModificarCriterio, opcionesModificarCriterio[0]);
                			if (desicionModificarCriterio.equals("id")){
                				lista.despliegaLista();
                				buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a modificar"));
                				lista.buscar(buscador,"modificar en bloque id");
                			}
                			else if (desicionModificarCriterio.equals("nombre")){
                				lista.despliegaLista();
                				buscadorString = JOptionPane.showInputDialog("Digite el nombre a modificar en bloque");
                				lista.buscarString(buscadorString,"modificar en bloque nombre");
                			}
                			else if (desicionModificarCriterio.equals("apellido")){
                				lista.despliegaLista();
                				buscadorString = JOptionPane.showInputDialog("Digite el apellido a modificar en bloque");
                				lista.buscarString(buscadorString,"modificar en bloque apellido");
                			}
                			else if (desicionModificarCriterio.equals("nota")){
                				lista.despliegaLista();
                				int notMin = new Integer(JOptionPane.showInputDialog("Digite la nota minima"));
                				int notMax = new Integer(JOptionPane.showInputDialog("Digite la nota maxima"));
                				lista.buscarNotas(notMin,notMax);
                			}
                			
            		}
            		else{
        				JOptionPane.showMessageDialog(null, "no hay datos T_T");
        			} 
            		}
            		break;
            	case "eliminar":
            		if (lista.estavacio()==false){
            		String opcionesEliminar[]={"normal","bloque"},desicionEliminar;
            		desicionEliminar = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opcionesEliminar, opcionesEliminar[0]);
            		if (desicionEliminar.equals("normal")){
            			lista.despliegaLista();
            		 	buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a ELIMINAR"));
            		 	lista.buscar(buscador,"eliminar");
            		}
            		else if(desicionEliminar.equals("bloque")){
            			JOptionPane.showMessageDialog(null, " Es hora de ponernos TRYHARDS");
            			buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a ELIMINAR en bloque"));
                		lista.buscar(buscador,"eliminar en bloque");            			
            		}
            		}
            		else{
        				JOptionPane.showMessageDialog(null, "Ste men, no hay datos T_T");
        			}
            		break;
            	case "insertar":
            		String opcionesInsertar[]={"Insertar en la cola","Insertar en la cabeza","insertar desp o antes"},desicionInsertar;
            		desicionInsertar = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opcionesInsertar, opcionesInsertar[0]);
            		if (desicionInsertar.equals("Insertar en la cola")){
            			ingresarDatos();
                        lista.insertarcola(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
            		}
            		else if (desicionInsertar.equals("Insertar en la cabeza")){
            			ingresarDatos();
                        lista.insertarcabeza(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
            		}
            		else if (desicionInsertar.equals("insertar desp o antes")){
            			if (lista.estavacio()==false){
                			lista.despliegaLista();
                			buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion base para insertar"));
            				lista.buscar(buscador, "insertar");}
            				else{
                				JOptionPane.showMessageDialog(null, "no hay datos T_T");
                			}
            		}
            		
            		break;
                case "desplegar lista":
                		if (lista.estavacio()==false){
                		lista.despliegaLista();}
                		else{
                			JOptionPane.showMessageDialog(null, "no hay datos");
                		}
                        break;
                case "buscar":                	
            		if (lista.estavacio()==false){
            			String opcionesBuscar[]={"normal","bloque"},desicionBuscar;
                		desicionBuscar = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,opcionesBuscar, opcionesBuscar[0]);
            			if (desicionBuscar.equals("normal")){            			
            				buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a buscar"));
            				lista.buscar(buscador, "buscar");
                    		}
            			else if(desicionBuscar.equals("bloque")){
            				buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a buscar en BLOQUE"));
            				lista.buscar(buscador, "buscar en bloque");
            			}
            		}
            		else{
            			JOptionPane.showMessageDialog(null, "no hay datos T_T");
            		}
                		break;
                case "salir del programa":JOptionPane.showMessageDialog(null, "Gracias por utilizar el programa, refactorizado "+"\n"+
                		                                                      "----Por: Yeferson Andres Quevedo Gutierrez-----");
                        break;
                case "log":
                	lista.log();
                	//Pensandolo todavia me falta estructurarlo
                	// falta organizarlo más y agregarle todas las funci
                	break;
                default :JOptionPane.showMessageDialog(null, "opcion no valida, intente de nuevo");
            }
        }while (desicion != "salir del programa");
        
    }
	public static void ingresarDatos() {
		identificacion = leer_entero("Digite el numero de identificacion");
		nombre= JOptionPane.showInputDialog("Digite el nombre de la persona");
		while (nombre.isEmpty()){
			nombre =JOptionPane.showInputDialog("Digite el nombre de la persona");
		}		
		apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
		while (apellido.isEmpty()){
			apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
		}
		nota1=leer_nota("Digite la nota 1 de "+nombre+" "+apellido);
		nota2=leer_nota("Digite la nota 2 de "+nombre+" "+apellido);
		nota3=leer_nota("Digite la nota 3 de "+nombre+" "+apellido);                       
		notadefinitiva=(nota1*0.3)+(nota2*0.3)+(nota3*0.4);
	}
    static int leer_entero( String a ){
    	String cad;
    	int c;

    	while( true ){
    		cad = JOptionPane.showInputDialog( a );
    		if( cad.isEmpty() ){
    			JOptionPane.showMessageDialog( null, "Debe digitar entero..." );
    		}
    		else{
    			try{
    				c = Integer.parseInt(cad);
    				break; // si es correcto sale del ciclo 
    			}catch(NumberFormatException e){
    				JOptionPane.showMessageDialog( null, "El dato no es entero..." );			     
    			}
    		}
    	}
    	return(c);
    }
    static double leer_nota( String a ){
    	String cad;
    	double c;

    	while( true ){
    		cad = JOptionPane.showInputDialog( a );
    		if( cad.isEmpty() ){
    			JOptionPane.showMessageDialog( null, "Debe digitar una nota en rango 0 a 5..." );
    		}
    		else{
    			try{
    				c = Double.parseDouble(cad);
    				if(c>=0 && c<=5){
    					break;
    	    		}else{
    	    			JOptionPane.showMessageDialog(null, "La nota no esta dentro del rango establecido 0 a 5");
    	    		}
    				 
    			}catch(NumberFormatException e){
    				JOptionPane.showMessageDialog( null, "El dato no es entero..." );			     
    			}
    		}
    		
    	}
    	return(c);
    }
}


