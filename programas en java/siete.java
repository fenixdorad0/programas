package fenixa;

import javax.swing.JOptionPane;

public class siete {

	public static void main(String[] args) {
		// TODO Auto-generated method stub sueldo horas nombre
		int sueldo, hora, z; String nombre;
		nombre=JOptionPane.showInputDialog("Ingrese su nombre");
		sueldo=Integer.parseInt(JOptionPane.showInputDialog("Cuanto es su sueldo"));
		hora=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de horas trabajadas"));
		z=datos(nombre, sueldo, hora);
		mostrar (z);
	}
	public static int datos(String nombre,int sueldo,int hora) {
		int resultado;
		resultado=sueldo*hora;
		return resultado;
	}
	public static void mostrar(int resultado) {
		JOptionPane.showMessageDialog(null,"su sueldo es de : " +resultado);
	}
}
