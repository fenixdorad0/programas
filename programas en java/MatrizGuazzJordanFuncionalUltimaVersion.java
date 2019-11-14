package fenixa;

import javax.swing.JOptionPane;

public class oi {

	public static void main(String[] args) {		
		double a[][];int f,c,filas,columnas;
		filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
		columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
		int comprobar;
		comprobar=0;
		while (comprobar!=1){
			if (filas>columnas){}
			else {comprobar=columnas-filas;
			}
			if (comprobar!=1){
				JOptionPane.showInputDialog("Digite otra vez la matriz filas<columnas ejemplo 2x3");
				filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
				columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));}
		}
		
		a=new double [filas][columnas];
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				a[f][c]=Double.parseDouble(JOptionPane.showInputDialog("El dato de la matriz en la posicion fila  "+ (f) + "  columna  "+ (c) ));
			}}
		System.out.println("--");
		finish(a,filas,columnas);
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
			}
			for (int b=0; b<filas;b++)
			{
				System.out.println("--");
				finish(a,filas,columnas);
				
				//mostrar(a,filas,columnas); // linea para verificar o buscar errores
				if (p==b){}
				else {
					double coeficiente=a[b][p];
					for (c=0;c<=filas;c++){
						a[b][c]-=coeficiente*a[p][c];
					}
				}
			}
	
		}
		}
	private static void soyotrometodo(double[][] matriz, int[][] matriz2, int f, int c, int filas, int columnas) {	
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
			entero=(int)matriz[f][c]; //aqui es ta el pinche error
			while(matriz[f][c]>entero & decimales<=2){
				matriz[f][c]*=10;
				decimales++;
				entero=(int)matriz[f][c];
				}
			while(matriz[f][c]<entero & decimales<=2){
				matriz[f][c]*=10;
				decimales++;
				entero=(int)matriz[f][c];
				}
			
			fraccion=entero;
			
			matriz2[f][c]=(int) Math.pow(10, decimales);
			matriz[f][c]=fraccion;
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
			  if (matriz[fi][co]==0){
				  imprimir= imprimir +" | "+(int)matriz[fi][co];
			  }
			  else if(matriz2[fi][co]==1){
				  imprimir=imprimir +" | "+(int)matriz[fi][co];
			  }
			  else if ((int)matriz[fi][co]==1 & matriz2[fi][co]==1){
				  imprimir= imprimir +" | "+1;
			  }
			  
			  else{
			imprimir = imprimir +" | "+ (int)matriz[fi][co]+"/"+matriz2[fi][co];
			  }
			  }
		 System.out.println(imprimir +" | ");
		 imprimir="";
	}
}
}