package fenixa;//Metodo entro un metodo GG very easy, no que va estaba dificil xD

import javax.swing.JOptionPane;

public class Pruebas {

	public static void main(String[] args) {
	int a,b,c,z;
	z=0;
	a=1;
	b=2;
	c=3;
	z=datos(a,b,c,z);
	}
	
public static int datos(int a, int b, int c,int z) {
	int total;
	total=a*b*c;
	if (total==6){
		JOptionPane.showMessageDialog(null,"Funca");
		mostrar(z);
	}
	else {
		JOptionPane.showMessageDialog(null,"no funk");
	}
	return total;
}
public static void mostrar(int total) {
	
	JOptionPane.showMessageDialog(null,"Super funca");
	;	
}

}
