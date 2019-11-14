package fenixa;

import javax.swing.JOptionPane;

public class cristhian {
	public static void main(String[] args) {
		double a[][];int f,c,filas,columnas;
		filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
		columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
		int comprobar;
		comprobar=0;
		String imprimir;
		imprimir="";
		a=new double [filas][columnas];
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				a[f][c]=Integer.parseInt(JOptionPane.showInputDialog("El dato de la matriz en la posicion fila  "+ (f) + "  columna  "+ (c) ));
			}}
		mostrar(a,filas,columnas);
		int p,A,cambio,chismosa;
		cambio=0;
		chismosa=0;
		if (a[0][0]==0){
			for(f=1;f<filas;f++){
				for(c=0;c<columnas & chismosa==0;c++){
					if (a[f][0]!=0){
						cambio=f;
						System.out.println("Debido a que hay un 0 en la 1er fila se cambia la F1 con la F" + (cambio+1));
						chismosa=1;
						}}}}
		
		double cambiando;
		if (chismosa==1){
				for(c=0;c<columnas;c++){
					cambiando=a[cambio][c];
					a[cambio][c]=a[0][c];
					a[0][c]=cambiando;
				}}
		
		for (p=0;p<filas;p++){
			double Dividir=a[p][p];
			for (A=p; A <= filas;A++ ){
			a[p][A]=a[p][A]/Dividir;
			//fracciones(a,filas, columnas);
			
			}
			for (int b=0; b<filas;b++){
				if (p==b){}
				else {
					double coeficiente=a[b][p];
					for (c=0;c<=filas;c++){
						a[b][c]-=coeficiente*a[p][c];
					}}
				}}

	}
	private static void mostrar(double[][] a, int filas, int columnas) {
		String imprimir;
		imprimir="";
		System.out.println("--------------------------");
		for(int fi=0;fi<filas;fi++){
			for(int co=0;co<columnas;co++){
				 imprimir = imprimir +" | "+ a[fi][co];
			}
			System.out.println(imprimir +"|");
			imprimir="";
		}
	}}
