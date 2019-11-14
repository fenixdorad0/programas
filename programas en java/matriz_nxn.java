package fenixa;

import javax.swing.JOptionPane;

public abstract class matriz_nxn {

	public static void main(String[] args) {
		int Nfilas,Ncolumnas,c,ciclo;
		Nfilas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese el numero de fiilas"));
		Ncolumnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese el numero de columnas"));
		ciclo=comprovarciclo(Nfilas,Ncolumnas);
		while (ciclo==0){
			JOptionPane.showInputDialog("La matriz no es cuadratica repita el numero de filas y el de columnas");
			Nfilas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese el numero de fiilas"));
			Ncolumnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese el numero de columnas"));
			ciclo=comprovarciclo(Nfilas,Ncolumnas);
		}
		JOptionPane.showInputDialog("FUNK");
	}

	private static int comprovarciclo(int Nfilas, int Ncolumnas) {
		// TODO Auto-generated method stub
		int respuesta;
		respuesta=0;
		if (Nfilas%2==0 & Ncolumnas%2==0 ){
			respuesta=1;
		}
		
		return respuesta;
	}

}
