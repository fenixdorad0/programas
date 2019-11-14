package fenixa;

import javax.swing.JOptionPane;

public class dos {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String nombre,z;int edad,sexo,estado_civil;
		nombre=JOptionPane.showInputDialog("Digite su nombre");
		edad=Integer.parseInt(JOptionPane.showInputDialog("Digite su edad"));
		estado_civil=Integer.parseInt(JOptionPane.showInputDialog("Digite su estado civil si es soltero 1, si es casado 2, otra 3"));
		sexo=Integer.parseInt(JOptionPane.showInputDialog("Digite si es onnanoishto=1 otokonoshto=2"));
		z=datos(nombre,edad,sexo,estado_civil);
		mostrar(z);
	}
public static String datos(String nombre, int edad, int sexo, int estado_civil) {
	// TODO Auto-generated method stub
	String res;
	if (edad>=18 & estado_civil==1){
		res="Su nombre es: " +nombre ;
    }
	else{res="";
	}
	return res;
	
}
public static void mostrar (String z){
	JOptionPane.showMessageDialog(null, z);
}

}

