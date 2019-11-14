package fenixa;

import javax.swing.JOptionPane;

public class cinco {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int a,b; String z;
		a=Integer.parseInt(JOptionPane.showInputDialog("numero"));
		b=Integer.parseInt(JOptionPane.showInputDialog("numero"));
		z=datos(a,b);
		mostrar (z);
		
	}
	public static String datos(int a,int b) {
		String c;
		c="";
		if (a<0 & b>0 | a>0 & b<0) {
			c= "Son de diferentes signos";
		}
		else {
			
		}
		return c;
	}
	public static void mostrar (String c){
		JOptionPane.showMessageDialog(null, c);
	}

	}	