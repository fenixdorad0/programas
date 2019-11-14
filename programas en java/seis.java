package fenixa;

import javax.swing.JOptionPane;

public class seis {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int n1,n2,z;
		n1=Integer.parseInt(JOptionPane.showInputDialog("numero"));
		n2=Integer.parseInt(JOptionPane.showInputDialog("numero"));
		z=datos(n1,n2);
		mostrar(z);
		
}
public static int datos(int n1,int n2) {
	n1=n1+n2;
	return n1;
}
public static void mostrar (int n1){
	JOptionPane.showMessageDialog(null, n1);
}

}