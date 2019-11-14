package fenixa;

import javax.swing.JOptionPane;

public class Promedio_general {

	public static void main(String[] args) {
		int estudiantes,identificacion,aprovados,contador;String nombre;float z,promedio_general;
		promedio_general=0;
		contador=0;
		estudiantes=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de estudiantes"));
		for(int i=0;i<estudiantes;i++){
			identificacion=Integer.parseInt(JOptionPane.showInputDialog("# de identificacion"));
			nombre=JOptionPane.showInputDialog("Ingrese su nombre");
			z=promedio(promedio_general);
			aprovados=aprovo(z) ;
			promedio_general=promedio_general+z;
			contador=contador+aprovados;
		}
		JOptionPane.showMessageDialog(null,"aprovados" +contador );
		JOptionPane.showMessageDialog(null,"promedio" +promedio_general/estudiantes);
	}

	private static float promedio(float promedio_general) {
		float nota;
		nota=Float.parseFloat(JOptionPane.showInputDialog("Digite nota"));
		return nota;
	}

	private static int aprovo(float nota) {
		int respuesta2;
		respuesta2=0;
		if (nota >=3 & nota <=5) {
			respuesta2=1;
		}
		return respuesta2;
	}

}