package fenixa;

import javax.swing.JOptionPane;

public class diez {

	public static void main(String[] args) {
		String nombre; int salario, horas, salariobruto;float z,salarioneto;
		salarioneto=0;
		horas=Integer.parseInt(JOptionPane.showInputDialog("Horas"));
		nombre=JOptionPane.showInputDialog("Ingrese su nombre");
		salario=Integer.parseInt(JOptionPane.showInputDialog("Cuanto es su sueldo"));
		salariobruto=0;
		z=datos(nombre,salario,horas,salariobruto,salarioneto);
		mostrar(z,salarioneto);
	}
	
public static float datos(String nombre,int salario,int horas,int salariobruto,double salarioneto) {
	int porcentaje;
	porcentaje=0;
	if (salariobruto>=3837000) {
		porcentaje=salariobruto*4/100;
		salarioneto=salariobruto-porcentaje;
	}
	else {
		JOptionPane.showMessageDialog(null,"este se supone que" + porcentaje);
	}
	return porcentaje;	
}
public static void mostrar(float porcentaje,double salarioneto) {
	JOptionPane.showMessageDialog(null,"el porcentaje es" + porcentaje);
	JOptionPane.showMessageDialog(null,"este se supone que" + porcentaje);
	JOptionPane.showMessageDialog(null,"este se supone que" + porcentaje);
	;	
}

}
