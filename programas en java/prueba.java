package fenixa;

import javax.swing.JOptionPane;
public class prueba {
	public static void main(String[] args){

	int resto;
	int numero1 = 100;
	int numero2=4;
	 
	resto = numero1%numero2;
	 
	if (resto==0)
	  System.out.println(numero1 + " es múltiplo de " + numero2);
	else
	  System.out.println(numero1 + " NO es múltiplo de " + numero2);
}
}

