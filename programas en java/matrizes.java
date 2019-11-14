package fenixa;

import javax.swing.JOptionPane;

public class matrizes {
	

	public static void main(String[] args) {

		double matriz[][];int f,c,filas,columnas;
		filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
		columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
		matriz=new double[filas][columnas];
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				matriz[f][c]=Integer.parseInt(JOptionPane.showInputDialog("El dato de la matriz en la posicion fila  "+ (f) + "  columna  "+ (c) ));
			}}
		mostrar(matriz);
		
		
}

	private static void mostrar(double[][] matriz) {
		// TODO Auto-generated method stub
		String imprimir;
		imprimir="";
		for (int f=0; f < 2; f++) {
			  for (int c=0; c < 2; c++) {
				imprimir = imprimir +" | "+ matriz[f][c];
			  }
			 System.out.println(imprimir +" | ");
			 imprimir="";
			}
	}

	}
