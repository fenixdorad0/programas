import javax.swing.JOptionPane;

public class Finalizando {
	public static void main(String[] args) {
		int cantidadPersonas =0;
		cantidadPersonas = Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de personas"));
		estudiante objeto[] = new estudiante[100];
		for (int f = 0; f < cantidadPersonas; f++) {
			agregarpersonas(objeto, f);
		}
		int opc0 = Integer.parseInt(JOptionPane.showInputDialog("0 editar, 1 buscar, 2 eliminar, 3 agregar"));
		if (opc0==2){
			imprimirObjeto(objeto,0);
			opcion0N2(objeto);
		}
		// no funca
		else if (opc0==3){
			int agregarPersonas = Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantas personas desea agregar"));
			for (int ag = cantidadPersonas; ag < (cantidadPersonas+agregarPersonas) ; ag++) {
				agregarpersonas(objeto, ag);
			}
		}
		else{
			int opc1 = Integer.parseInt(JOptionPane.showInputDialog("0 nombre, 1 edad,2 municipio"));
			Switch(objeto, opc0, opc1);
		}
		System.out.println("--");
		imprimirObjeto(objeto,opc0);
		
		
		
	}


	private static void agregarpersonas(estudiante[] objeto, int f) {
		String nombre;
		String municipio;
		int edad;
		nombre = JOptionPane.showInputDialog("Ingrese su nombre");
		edad = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su edad"));
		municipio = JOptionPane.showInputDialog("Ingrese su municipio");
		objeto[f] = new estudiante(nombre,edad,municipio);
	}
	

	private static void Switch(estudiante[] objeto, int opc0, int opc1) {
		
		if (opc1==0){
			opcion1N0(objeto, opc0);
		}
		else if(opc1==1){
			opcion1N1(objeto, opc0);
		}
		else if(opc1==2){
			opcion1N2(objeto, opc0);
	}
		
	}

	private static void opcion0N2(estudiante[] objeto) {
		int posicionEliminar = Integer.parseInt(JOptionPane.showInputDialog("que linea desea borrar"));
		for (int a = 0; a < objeto.length; a++) {
			if (posicionEliminar==a && posicionEliminar!=objeto.length-1){
				objeto[a]=objeto[a+1];
			}
		}
	}

	private static void opcion1N0(estudiante[] objeto, int opc0) {
		String opc3 = JOptionPane.showInputDialog(" Que bloque de nombres desea encontrar o corregir ");
		if (opc0==1){
			for (int i = 0; i < objeto.length; i++) {
				if (objeto[i].getmunicipio().equals(opc3))
					imprimir(objeto, i);
				}	
		}
		else if (opc0==0){
			String NewNombre = JOptionPane.showInputDialog(" ingrese el nuevo nombre para el bloque ");
			for (int i = 0; i < objeto.length; i++) {
				if(objeto[i].getnombre().equals(opc3)){
					objeto[i].setnombre(NewNombre);
				}	
			}
		}
	}


	private static void opcion1N1(estudiante[] objeto, int opc0) {
		int opc3 = Integer.parseInt(JOptionPane.showInputDialog("que edad desea corregir en bloque"));
		if (opc0==1){
			for (int i = 0; i < objeto.length; i++) {
				if (objeto[i].getedad()==(opc3))
					imprimir(objeto, i);
				}	
		}
		else if (opc0==0){
			int NewEdad = Integer.parseInt(JOptionPane.showInputDialog("Ingrese la nueva edad para el bloque"));
			for (int i = 0; i < objeto.length; i++) {
				if(objeto[i].getedad()==(opc3)){
					objeto[i].setedad(NewEdad);
				}		
		}
}
	}


	private static void opcion1N2(estudiante[] objeto, int opc0) {
		String opc4 = JOptionPane.showInputDialog(" Que municipio desea encontrar o corregir ");
		if (opc0==1){
			for (int i = 0; i < objeto.length; i++) {
				if (objeto[i].getmunicipio().equals(opc4))
					imprimir(objeto, i);
				}	
		}
		else if (opc0==0){
			String NewMunicipio = JOptionPane.showInputDialog(" ingrese el nuevo municipio ");
			for (int i = 0; i < objeto.length; i++) {
				if(objeto[i].getmunicipio().equals(opc4)){
					objeto[i].setmunicipio(NewMunicipio);
				}	
			}
		}
	}
		
	private static void imprimir(estudiante[] objeto, int i) {
		System.out.println("# "+i+" nombre "+objeto[i].getnombre()+" edad "+objeto[i].getedad()+" municipio "+objeto[i].getmunicipio());
	}
	
	private static void imprimirObjeto(estudiante[] objeto, int opc0) {
		if (opc0==2){
			for (int i = 0; i < objeto.length-1; i++) {
				imprimir(objeto, i);
			}
		}
			else{
				for (int i = 0; i < objeto.length; i++) {
					imprimir(objeto, i);
				}
				
		}
		
	}
	}

