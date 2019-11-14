package fenixa;

import javax.swing.JOptionPane;

public class gauzz_yo {
	
		public static void main(String[] args) {
		
		float a[][];int f,c,filas,columnas,chismosa,contador,medirmatriz,ayuda,comprobar; String imprimir;
		float cambiando;
		cambiando=0;
		comprobar=0;
		imprimir="";
		chismosa=0;
		int cambio;
		cambio=0;
		filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
		columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
		
		//Determina que solo sea cuadratica la matriz
		while (comprobar!=1){
			if (filas>columnas){
			}
			else {
				comprobar=columnas-filas;
			}
			if (comprobar!=1){
				JOptionPane.showInputDialog("No sea chucha digite eso bien pdd bedoya approvate");
				filas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de filas"));
				columnas=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de columnas"));
			}
			
		}
		
		
		a=new float [filas][columnas];
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				a[f][c]=Integer.parseInt(JOptionPane.showInputDialog("el dato de la matriz a en posicion fila  "+ (f) + "  columna  "+ (c) ));
			}
		}
		//Detectando si el 1er termino es = 0 o si no se puede intercambiar
		if (a[0][0]==0){
			for(f=1;f<filas;f++){
				for(c=0;c<columnas & chismosa==0;c++){
					if (a[f][0]!=0){
						cambio=f;
						System.out.println("Debido a que hay un 0 en la 1er fila se cambia la F1 con la F" + (cambio+1));
						chismosa=1;
							}
					}
				}
			
			}
		//Cambiando variables si el 1er pibote es 0 nota si los 3 son 0 no habria variables es algo imposible por eso no hay else =)
		if (chismosa==1){
				for(c=0;c<columnas;c++){
					cambiando=a[cambio][c];
					a[cambio][c]=a[0][c];
					a[0][c]=cambiando;
		}
		}
		//Medir matriz
		medirmatriz=0;
		if (filas==columnas){
			medirmatriz=((filas*columnas)-filas)/2;//esta condicion sobra o mejor dicho la formula dentro del 1er if
			
		}
		else{
			//Sea o nosea cuadratica esta la solucion aunque realmente se puede solo con no cuadraticas lel
			if (filas<columnas){
				
				medirmatriz=((filas*(columnas-1))-filas)/2;
			}
			else {
				medirmatriz=(((filas-1)*columnas)-columnas)/2;
			}
			
		}
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				imprimir = imprimir +" "+ a[f][c];
			}
			System.out.println(imprimir);
			imprimir="";
		}

		
		contador=filas;
		ayuda=0;
		float ayu1,ayu2;
		int ff,cc;
		contador=filas;
				ayuda=0;
				for (c=0;c<columnas-1;c++){
					contador=filas-1;
					for(f=contador;f!=0 & ayuda<medirmatriz;f--){
						int colum;
						ayuda=ayuda+1;
						ff=f;
						cc=c;
						ayu1=a[ff][cc];
						int resul=(ff-cc)-ff;
						if (resul<0){
							resul=resul*-1;
						}
						
						
						ayu2=a[resul][cc];
						System.out.println("funka " +f +c+"result"+ayu2+ayu1);
						
						for (colum=0;colum<columnas;colum++){
							System.out.println("Antes"+ a[ff][colum]);
							if (ayu1<0){
								ayu1=ayu1*-1;
							}
							if (ayu2<0){
								ayu2=ayu2*-1;
							}
							if (a[ff][colum]<0) {
								//a[ff][colum]=(ayu1*ayu2)+a[ff][colum];
								System.out.println(ayu1);
								a[ff][colum]=((ayu2*a[ff][colum])-(ayu1*a[resul][colum]));
							}
							else{
								//a[ff][colum]=(ayu1*ayu2)-a[ff][colum];
								
								a[ff][colum]=((ayu2*a[ff][colum])-(ayu1*a[resul][colum]));
							
							}
							System.out.println("despues"+ a[ff][colum]);
							
						}
						}
					
				}	
		for(f=0;f<filas;f++){
			for(c=0;c<columnas;c++){
				imprimir = imprimir +" "+ a[f][c];
			}
			System.out.println(imprimir);
			imprimir="";
		}

		
		}
	}


