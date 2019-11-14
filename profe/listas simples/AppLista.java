package estructuras;

import java.util.Scanner;

import javax.swing.JOptionPane;
class AppLista{
	static Integer identificacion,buscador;       
    static String nombre,apellido;
    static Double nota1,nota2,nota3,notadefinitiva;
    
    public static void main(String args[]){
        Lista lista = new Lista();
        
        //Inicializacion del teclado
        Scanner Teclado = new Scanner(System.in);
        String na[]={"Insertar en la cola","Insertar en la cabeza","DesplegarLista", "buscar", "salir del programa"},opcion;
        do{
        	opcion = (String)JOptionPane.showInputDialog(null,"señor usuario que desea hacer", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,na, na[0]);
            switch (opcion) {
                case "Insertar en la cola":
                        identificacion = leer_entero("Digite el numero de identificacion");
                        nombre= JOptionPane.showInputDialog("Digite el nombre de la persona");
                        apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
                        nota1=leer_nota("Digite la nota 1 de "+nombre+" "+apellido);
                        nota2=leer_nota("Digite la nota 2 de "+nombre+" "+apellido);
                        nota3=leer_nota("Digite la nota 3 de "+nombre+" "+apellido);
                        notadefinitiva=(nota1+nota2+nota3)/3;
                        lista.insertarcola(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
                        break;
                case "Insertar en la cabeza":
                		identificacion = leer_entero("Digite el numero de identificacion");
                        nombre= JOptionPane.showInputDialog("Digite el nombre de la persona");
                        apellido=JOptionPane.showInputDialog("Digite el apellido de "+nombre);
                        nota1=leer_nota("Digite la nota 1 de "+nombre+" "+apellido);
                        nota2=leer_nota("Digite la nota 2 de "+nombre+" "+apellido);
                        nota3=leer_nota("Digite la nota 3 de "+nombre+" "+apellido);
                        notadefinitiva=(nota1+nota2+nota3)/3;
                        lista.insertarcabeza(identificacion,nombre,apellido,nota1,nota2,nota3,notadefinitiva);
              
                    break;
               
                case "DesplegarLista": lista.despliegaLista();
                        break;
                case "buscar":  buscador = new Integer(JOptionPane.showInputDialog("Digite la identificacion a buscar"));
                	
                	lista.buscar(buscador);
                break;
                case "salir del programa":JOptionPane.showMessageDialog(null, "Gracias por utilizar el programa");
                        break;                                
                default :JOptionPane.showMessageDialog(null, "opcion no valida, intenta de nuevo");
            }
        }while (opcion != "salir del programa");
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
    			JOptionPane.showMessageDialog( null, "Debe digitar una nota en rango 1 a 5..." );
    		}
    		else{
    			try{
    				c = Double.parseDouble(cad);
    				if(c>=1&&c<=5){
    					break;// si es correcto sale del ciclo 
    	    		}else{
    	    			JOptionPane.showMessageDialog(null, "la nota no esta dentro del rango establecido 1 a 5");
    	    		}
    				 
    			}catch(NumberFormatException e){
    				JOptionPane.showMessageDialog( null, "El dato no es entero..." );			     
    			}
    		}
    		
    	}
    	return(c);
    }
}


