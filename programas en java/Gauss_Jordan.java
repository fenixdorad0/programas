package fenixa;

	import javax.swing.JOptionPane;

public class Gauss_Jordan {

	public static void main(String[] args) {
	
	int a[][];int f,c,filas,columnas,cambio,chismosa,cambiando,contador,medirmatriz,ayuda,comprobar; String imprimir;
	cambiando=0;
	comprobar=0;
	imprimir="";
	chismosa=0;
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
	
	
	a=new int [filas][columnas];
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
	
	//System.out.println("El tamaña de la matriz es de =" +medirmatriz); //Solo para probar si voy bien                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
	
	//rrecorrido de la matriz toma de los 2 datos para comenzar las operaciones 
	contador=filas;
	ayuda=0;
	int ayu1,ayu2,ff,cc;
	for (c=0;c<columnas-1;c++){
		contador=filas-1;
		for(f=contador;f!=0 & ayuda<medirmatriz;f--){
			ayuda=ayuda+1;
			System.out.println("mostrar" +a[f][c]+"ayuda"+ayuda);
			ff=f;
			cc=c;
			int f2=0;
			int f1=0;
			if (a[f][c]==0){
				}
			else{
				
				ayu1=a[ff][cc];
				System.out.println("filas" +ff +"columnas" +cc );
				ff=(ff-cc)-ff;
				if (ff<0){
					ff=ff*-1;
				}
				ayu2=a[ff][cc];
				f2=ff;
				System.out.println("filas" +ff +"columnas" +cc );
				System.out.println("Respons" +ayu1 +"respond" + ayu2);
				//Provando formula
				cambiando=0;
				
				
				for(int cs=0;cs<columnas;cs++){
					//a3[f2][c]=ayu1-a[f1][c];
					System.out.println("Respons" +ayu1 +"respond" + ayu2);
					if ((a[f1][cs])<0){
						a[f1][cs]=((ayu1*ayu2)+a[f1][cs]);
						
					}
					else{
						a[f1][cs]=((ayu1*ayu2)-a[f1][cs]);
						
					}
				}
					
					//f2 1er numero
					//f1 wdo numero 
					//cambiando=a[f2][c];
					//a[f2][c]=a[f1][c];
					//a[f1][c]=cambiando;
					
					}
				
			}
				}
		

			
	
	
	//Imprimiend3o matriz final paso por paso
	
	
	for(f=0;f<filas;f++){
		for(c=0;c<columnas;c++){
			imprimir = imprimir +" "+ a[f][c];
		}
		System.out.println(imprimir);
		imprimir="";
	}
	//Orden de busqueda(desde la exquina inferior) de apoyo por si la necesito despues
	//contador=filas;
	//ayuda=0;
	//for (c=0;c<columnas-1;c++){
		//contador=filas-1;
		//for(f=contador;f!=0 & ayuda<medirmatriz;f--){
			//ayuda=ayuda+1;
			//System.out.println("funka " +f +c);
			//System.out.println("mostrar" +a[f][c]);
	//}
		
	//}
	
	}
}





