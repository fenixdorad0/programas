package fenixa;

import javax.swing.JOptionPane;

public class diatres {

	public static void main(String[] args) {
	int a;String z;
	z="";
	a=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de personas"));
	for(int i=0;i<a;i++){
		z=dato(a);
		JOptionPane.showMessageDialog(null,z);
	}
	}

	private static String dato(int a) {
		int edad,sexo;String sexorespuesta,nombre,edadrespuesta;
		nombre=JOptionPane.showInputDialog("Ingrese su nombre");
		edad=Integer.parseInt(JOptionPane.showInputDialog("Ingrese su edad"));
		sexo=Integer.parseInt(JOptionPane.showInputDialog("Ingrese 0 si hombre o 1 si es mujer"));
		sexorespuesta=quesoy(sexo,nombre);
		edadrespuesta=comomedicen(edad,sexorespuesta);
		return edadrespuesta;
	}
	private static String quesoy(int sexo, String nombre) {
		String res;
		if (sexo==0){
			res="Hola " +nombre + " Usted es hombre (otokonnoishto) " ;
		}
		else{
			res="Hola " +nombre + " usted es una mujer (onanoistho) ";
		}
		return res;
	}
	
	private static String comomedicen(int edad,String sexorespuesta) {
		String mensaje; 
		mensaje="";
		if (edad==1 | edad==0){
			mensaje=sexorespuesta +" bebe " +"y tiene " +edad +" años";
		}
		else if (edad >=12 & edad<18){
			mensaje=sexorespuesta +" adolecente " +"y tiene " +edad +" años";
		}
		
		else if (edad >=18 & edad<31){
			mensaje=sexorespuesta +" joven " +"y tiene " +edad + " años";
		}
		
		else if (edad >=31 & edad<60){
			mensaje=sexorespuesta +" adulto " +"y tiene " +edad +" años";
		}
		else {
			mensaje=sexorespuesta +" mayor " +"y tiene " +edad +" años";
		}
		
		return mensaje;
	}
}