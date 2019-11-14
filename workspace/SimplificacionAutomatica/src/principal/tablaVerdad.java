package principal;

import javax.swing.JOptionPane;

public class tablaVerdad {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
	String opciones[]={"a","b","c","d"},desicion;
	
	
	int[ ] a = new int[64];
	int[ ] b = new int[64];
	int[ ] c = new int[64];
	int[ ] d = new int[64];
	int[ ] e = new int[64];
	int[ ] respuesta =new int[64];
	int conta=0,contb=0,contc=0,contd=0,conte=0;
	String cad="";
	for (int f = 0; f < 32; f++) {
		conta=conta+1;
		contb=contb+1;
		contc=contc+1;
		contd=contd+1;
		conte=conte+1;
		if (conta==1){
			a[f]=0;
		}
		else{
		conta=0;
		a[f]=1;	
		}
		//0-1
		if (contb<=2){
			b[f]=0;
		}
		else 
		b[f]=1;
		if (contb==4){
				b[f]=1;
				contb=0;
		}
		//00-11
		if (contc<=4){
			c[f]=0;
		}
		else 
		c[f]=1;
		if (contc==8){
				c[f]=1;
				contc=0;
		}
		//0000-1111
		if (contd<=8){
			d[f]=0;
		}
		else 
		d[f]=1;
		if (contd==16){
				d[f]=1;
				contd=0;
		}
		//8(0)
		if (conte<=16){
			e[f]=0;
		}
		else 
		e[f]=1;
		if (conte==32){
				e[f]=1;
				contc=0;
		}
		cad=cad +" "+d[f]+" "+c[f]+" "+b[f]+" "+a[f]+"\n";
		//respuesta[f]=d[f]*((c[f]*b[f]);
		}
	JOptionPane.showInputDialog(cad);
		
		
	}
	
		
	}
	

