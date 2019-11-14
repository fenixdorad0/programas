package fenixa;

import javax.swing.JOptionPane;

public class consumo_de_energia {

	public static void main(String[] args) {
	int clientes,condicion; float total_pagar,consumo_promedio;
	condicion=0;
	consumo_promedio=0;
	total_pagar=0;
	
	clientes=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de clientes"));
	for(int i=0;i<clientes;i++){
		total_pagar=calculo_pagar();
		consumo_promedio=consumo_promedio+total_pagar;
		imprimir(total_pagar,consumo_promedio,clientes,condicion);
	}
	condicion=1;
	imprimir(total_pagar,consumo_promedio,clientes,condicion);
	}

	private static void imprimir(float total_pagar, float consumo_promedio, int clientes,int condicion) {
		// TODO Auto-generated method stub
		if (condicion==0){
			JOptionPane.showMessageDialog(null,"El total a pagar es de : " + total_pagar);
		}
		else {
			JOptionPane.showMessageDialog(null,"El promedio es de : " + consumo_promedio/clientes);
		}
		
	}

	private static float calculo_pagar() {
		float consumo,valor_vatio,consumo_anterior,resultado;
		
		consumo_anterior=Float.parseFloat(JOptionPane.showInputDialog("Ingrese el consumo anterior"));
		consumo=Float.parseFloat(JOptionPane.showInputDialog("Cuanta electricidad utilizo en vatios"));
		valor_vatio=Float.parseFloat(JOptionPane.showInputDialog("Ingrese el valor vatio"));
		resultado=(consumo-consumo_anterior)*valor_vatio;
		return resultado;
	}
}
