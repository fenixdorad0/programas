package fenixa;

import javax.swing.JOptionPane;

public class uno {

	public static void main(String[] args) {
		String nombre;int edad;String z; 
		nombre=JOptionPane.showInputDialog("Digite su nombre");
		edad=Integer.parseInt(JOptionPane.showInputDialog("Digite su edad"));
		z = datos(nombre,edad);
		mostrar(z);
	}
public static String datos(String nombre, int edad) {
	// TODO Auto-generated method stub
	String res;
	if (edad>=18){
		res="ud es mayor de edad";
    }
	else{
		res="";
	}
	return res;
	
}

public static void mostrar (String z){
	JOptionPane.showMessageDialog(null, z);
}

}