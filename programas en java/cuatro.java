package fenixa;

import javax.swing.JOptionPane;

public class cuatro {

	public static void main(String[] args) {
		int a,z;
		for(int i=0;i<2;i++){
			a=Integer.parseInt(JOptionPane.showInputDialog("numero"));
			z=dato(a);
			mostrar(z);
		}
	}

public static int dato(int a) {
	if (a==0){
		a=0;
	}
	else {
		JOptionPane.showMessageDialog(null, +a);
	}
	return a;
}
public static void mostrar (int a){
	JOptionPane.showMessageDialog(null, a);
}

}	