package fenixa;

import javax.swing.JOptionPane;

public class ejercicio_1_10_personas {

	public static void main(String[] args) {
		String nombre,z; int edad;
		for(int i=0;i<10;i++){
			nombre=JOptionPane.showInputDialog("Ingrese su nombre");
			edad=Integer.parseInt(JOptionPane.showInputDialog("Ingrese su edad"));
			z=dato(nombre,edad);
			respues(z);
		}
	}

	private static void respues(String z) {
		JOptionPane.showMessageDialog(null,z);
	}

	private static String dato(String nombre, int edad) {
		String respuesta;
		respuesta="";
		if (edad>=18){
			 respuesta="Se puede casar";
		}
		else{
			respuesta="A lavar la loza baaakat ";//pdd espero que no lo vea el profe xD
		}
		return respuesta;
	}
	
}