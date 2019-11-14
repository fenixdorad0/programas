package fenixa;

import javax.swing.JOptionPane;

public class comp {

	public static void main(String[] args) {
		float a,b,z;
		a=Float.parseFloat(JOptionPane.showInputDialog("Digite cantidad de numeros"));
		b=Float.parseFloat(JOptionPane.showInputDialog("Digite que desea hacer: 1 sumar, 2 restar, 3 multiplicar, 4 dividir"));
		z=datos(a,b);
		mostrar(z);
	}
public static Float datos(Float a, Float b) {
	Float h,n;
	if (b==1){
		h=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
		for(int i=1;i<a;i++){
			n=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
			h=h+n;
		}
    }
	else if (b==2){
		h=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
		for(int i=1;i<a;i++){
			n=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
			h=h-n;
		}
	}
	else if (b==3){
		h=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
		for(int i=1;i<a;i++){
			n=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
			h=h*n;
		}
	}
	
	else{
		h=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
		for(int i=1;i<a;i++){
			n=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
			while (n==0){
				JOptionPane.showMessageDialog(null, "No puede dividirse ente 0, Digite el numero de nuevo");
				n=Float.parseFloat(JOptionPane.showInputDialog("Ingrese un numero"));
			}
				
			h=h/n;
		}
	}

	return h;
	
}



public static void mostrar (Float z){
	JOptionPane.showMessageDialog(null, z);
}

}	
