package fenixa;

import javax.swing.JOptionPane;

public class Numero_menor {

	public static void main(String[] args) {
		int a,b,c,z;
		z=0;
		a=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de numeros"));
		b=Integer.parseInt(JOptionPane.showInputDialog("Ingrese un numero"));
		for(int i=1;i<a;i++){
			c=Integer.parseInt(JOptionPane.showInputDialog("Ingrese un numero"));
			z=condicion(b,c);
			b=z;
		}
		imprimir(b);
		
	}

	private static void imprimir(int b) {
		// TODO Auto-generated method stub
		JOptionPane.showMessageDialog(null, b);
	}

	private static int condicion(int b, int c) {
		if (c>b){
			c=b;
		}
		else{
		}
		return c;
	}
}