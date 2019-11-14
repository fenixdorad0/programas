package fenixa;

import javax.swing.JOptionPane;

public class nueve {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String nombre; int salario;double z;
		nombre=JOptionPane.showInputDialog("Ingrese su nombre");
		salario=Integer.parseInt(JOptionPane.showInputDialog("Cuanto es su sueldo"));
		z=datos(nombre,salario);
		mostrar (nombre,salario,z);
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
		total=0;
	}
	return total;	
}
public static void mostrar(String nombre, int salario, double total) {
	JOptionPane.showMessageDialog(null,"Su nombre es :" + nombre);
	JOptionPane.showMessageDialog(null,"Su salario es de :" +salario);
	JOptionPane.showMessageDialog(null,"la retencion de la fuente es de :" + total);
}

}

