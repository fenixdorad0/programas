package fenixa;

import javax.swing.JOptionPane;

public class fraccion {
	

	public static void main(String[] args) {
	int filas,columnas;
	double[][] a;
	
	filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
	columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
	int comprobar;
	comprobar=0;
	String imprimir;
	imprimir="";
	a=new double [filas][columnas];
	for(int f=0;f<filas;f++){
		for(int c=0;c<columnas;c++){
			a[f][c]=Double.parseDouble(JOptionPane.showInputDialog("El dato de la matriz en la posicion fila  "+ (f) + "  columna  "+ (c) ));
		}}
	finish(a,filas,columnas);
	}
	private static void finish(double[][] a, int filas, int columnas) {
	
		double matriz[][];
		int matriz2[][];
		int fi,co,resultado,ayuda;
		double fraccion = 0;
		matriz=new double[filas][columnas];
		matriz2=new int[filas][columnas];
		for(int f=0;f<filas;f++){
			for(int c=0;c<columnas;c++){
				matriz[f][c]=a[f][c];
				resultado=0;
				int decimales, entero;
				decimales=0;
				entero=(int)matriz[f][c];
				while(matriz[f][c]>entero & decimales<=2){
					matriz[f][c]*=10;
					decimales++;
					entero=(int)matriz[f][c];
					}
				
				fraccion=entero;
				
				matriz2[f][c]=(int) Math.pow(10, decimales);
				matriz[f][c]=fraccion;
				
				System.out.println(entero +"decimales"+decimales);
				ayuda=entero;
				while(ayuda>0){
					resultado+=ayuda % 10;
					ayuda=ayuda/10;
				}
				soyotrometodo(matriz,matriz2,f,c,filas,columnas);
				
		}
		}
		String imprimir;
		imprimir="";
		for (fi=0; fi<filas; fi++) {
			  for (co=0; co<columnas; co++) {
				imprimir = imprimir +" | "+ (int)matriz[fi][co]+"/"+matriz2[fi][co];
			  }
			 System.out.println(imprimir +" | ");
			 imprimir="";
		}
		
	}

	private static void soyotrometodo(double[][] matriz, int[][] matriz2, int f, int c, int filas, int columnas) {
		// TODO Auto-generated method stub
		int nosepueda=0;
		while(nosepueda==0){
		if (matriz[f][c]%10==0 & matriz2[f][c]%10==0) {
			matriz[f][c]=matriz[f][c]/10;
			matriz2[f][c]=matriz2[f][c]/10;
		}
		else if ( matriz[f][c]%9==0 & matriz2[f][c]%9==0){
			matriz[f][c]=matriz[f][c]/9;
			matriz2[f][c]=matriz2[f][c]/9;
		
		}
		else if ( matriz[f][c]%8==0 & matriz2[f][c]%8==0){
			matriz[f][c]=matriz[f][c]/8;
			matriz2[f][c]=matriz2[f][c]/8;
		
		}
		else if ( matriz[f][c]%7==0 & matriz2[f][c]%7==0){
			matriz[f][c]=matriz[f][c]/7;
			matriz2[f][c]=matriz2[f][c]/7;
		
		}
		else if ( matriz[f][c]%6==0 & matriz2[f][c]%6==0){
			matriz[f][c]=matriz[f][c]/6;
			matriz2[f][c]=matriz2[f][c]/6;
		
		}
		else if (matriz[f][c]%5==0 & matriz2[f][c]%5==0){
			matriz[f][c]=matriz[f][c]/5;
			matriz2[f][c]=matriz2[f][c]/5;
			}
		else if (matriz[f][c]%4==0 & matriz2[f][c]%4==0){
			matriz[f][c]=matriz[f][c]/4;
			matriz2[f][c]=matriz2[f][c]/4;
		}
		else if ( matriz[f][c]%3==0 & matriz2[f][c]%3==0){
			matriz[f][c]=matriz[f][c]/3;
			matriz2[f][c]=matriz2[f][c]/3;
		
		}
	
		else if ( matriz[f][c]%2==0 & matriz2[f][c]%2==0){
			matriz[f][c]=matriz[f][c]/2;
			matriz2[f][c]=matriz2[f][c]/2;
		
		}
		else{
			 nosepueda=1;
		}
		
		}
		nosepueda=0;
	}		
	}

	
		

	

