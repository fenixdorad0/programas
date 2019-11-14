package fenixa;

import javax.swing.JOptionPane;

public class Ocho {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String nombre; int salario;double z;
		nombre=JOptionPane.showInputDialog("Ingrese su nombre");
		salario=Integer.parseInt(JOptionPane.showInputDialog("Cuanto es su sueldo"));
		z=datos(nombre,salario);
		mostrar (z);
	}
public static double datos(String nombre,int salario) {
	double total;
	if (salario >3000000) {
		total=salario*0.08;
	}
	else if (salario >=2000000) {
		total=salario*0.05;
	}
	else {
		total=salario;
	}
	return total;	
	}
public static void mostrar(double total) {
	JOptionPane.showMessageDialog(null,"su sueldo es de : " +total);
}

}


