import javax.swing.JOptionPane;
public class operaciones {

	public static void main(String[] args) {
	String[ ] datos = new String[2];
	int cantidadPersonas =0;
	datos[0]= "fisica1";
	datos[1]="fisica2";
	cantidadPersonas = Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de estudiantes"));
	estudiante objeto[] = new estudiante[100];
	//metodo base
	for (int f = 0; f < cantidadPersonas; f++) {
		informacionEstudiantes(datos, objeto, f);
		}
	String[ ] opciones = new String[4];
	opciones[0]="agregar";
	opciones[1]="modificar";
	opciones[2]="eliminar";
	opciones[3]="consultar";
	String quehago = (String) JOptionPane.showInputDialog(null,"Seleccione que desea hacer"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,opciones,opciones[0]);
	int nuevasPersonas=0;
	imprimirEstudiantes(cantidadPersonas, objeto, nuevasPersonas);
	//agregar personas
	if (quehago.equals("agregar")){
		nuevasPersonas = Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de estudiantes que desea agregar"));
	for (int f = (cantidadPersonas); f < (cantidadPersonas+nuevasPersonas); f++) {
		informacionEstudiantes(datos, objeto, f);
		}
	}
	//fin de agregar
	
	if (quehago.equals("modificar")){
		imprimirEstudiantes(cantidadPersonas, objeto, nuevasPersonas);
		double rangoMinimo=  Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango minimo de busqueda"));
		double rangoMaximo= Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango maximo de busqueda"));
		String[ ] CriterioModificar = new String[7];
		CriterioModificar[0]="Nombre";
		CriterioModificar[1]="Apellido";
		CriterioModificar[2]="Identificacion";
		CriterioModificar[3]="asignatura";
		CriterioModificar[4]="nota1";
		CriterioModificar[5]="nota2";
		CriterioModificar[6]="nota3";
		
				String CriterioModificarRespuesta = (String) JOptionPane.showInputDialog(null,"Seleccione que desea modificar"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,CriterioModificar,CriterioModificar[0]);
				if (CriterioModificarRespuesta.equals("Nombre")){
					String nuevonombre=JOptionPane.showInputDialog("Ingrese el nuevo nombres");
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setnombre(nuevonombre);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("apellido")){
					String nuevoapellido=JOptionPane.showInputDialog("Ingrese el nuevo apellido");
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setapellido(nuevoapellido);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("Identificacion")){
					int nuevaIdentificacion=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la nueva identificacion"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setidentificacion(nuevaIdentificacion);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("asignatura")){
					String NuevaAsig = (String) JOptionPane.showInputDialog(null,"Seleccione que materia esta cursando"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,datos,datos[0]);
					String nuevaAsignatura=NuevaAsig;
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setasignatura(nuevaAsignatura);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota1")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setnota1(objeto[f].getnota1()+nuevaNota);
					
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota2")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setnota2(objeto[f].getnota2()+nuevaNota);
					
				}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota3")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnotafinal()>=rangoMinimo && objeto[f].getnotafinal()<=rangoMaximo){
					objeto[f].setnota3(objeto[f].getnota3()+nuevaNota);
					
				}
					}
				}
				JOptionPane.showInputDialog("Los datos se cambiaron saticfactoriamente");
				imprimirEstudiantes(cantidadPersonas, objeto, nuevasPersonas);
	}
	imprimirEstudiantes(cantidadPersonas, objeto, nuevasPersonas);
	
	if (quehago.equals("eliminar")){
	double rangoMinimo=  Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango minimo de busqueda"));
	double rangoMaximo= Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango maximo de busqueda"));
	for (int f = 0; f < cantidadPersonas; f++) {
		if (objeto[f].getnotafinal()>rangoMinimo && objeto[f].getnotafinal()<rangoMaximo){
			f=f+1;
			cantidadPersonas=cantidadPersonas-1;
			imprimirEstudiante(objeto, f);
		}
	}
	if (quehago.equals("consultar")){

		imprimirEstudiantes(cantidadPersonas, objeto, nuevasPersonas);
		double CrangoMinimo=  Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango minimo de busqueda"));
		double CrangoMaximo= Integer.parseInt(JOptionPane.showInputDialog("Ingrese el rango maximo de busqueda"));
		String[ ] CriterioModificar = new String[7];
		CriterioModificar[0]="Nombre";
		CriterioModificar[1]="Apellido";
		CriterioModificar[2]="Identificacion";
		CriterioModificar[3]="asignatura";
		CriterioModificar[4]="nota1";
		CriterioModificar[5]="nota2";
		CriterioModificar[6]="nota3";
		
				String CriterioModificarRespuesta = (String) JOptionPane.showInputDialog(null,"Seleccione que desea modificar"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,CriterioModificar,CriterioModificar[0]);
				if (CriterioModificarRespuesta.equals("Nombre")){
					String nuevonombre=JOptionPane.showInputDialog("Ingrese el nombres");
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnombre().equals(nuevonombre)){
					objeto[f].setnombre(nuevonombre);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("apellido")){
					String nuevoapellido=JOptionPane.showInputDialog("Ingrese el nuevo apellido");
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getapellido().equals(nuevoapellido)){
					objeto[f].setapellido(nuevoapellido);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("Identificacion")){
					int nuevaIdentificacion=Integer.parseInt(JOptionPane.showInputDialog("Ingrese la nueva identificacion"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getidentificacion()==(nuevaIdentificacion)){
					objeto[f].setidentificacion(nuevaIdentificacion);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("asignatura")){
					String NuevaAsig = (String) JOptionPane.showInputDialog(null,"Seleccione que materia esta cursando"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,datos,datos[0]);
					String nuevaAsignatura=NuevaAsig;
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getasignatura().equals(nuevaAsignatura)){
					objeto[f].setasignatura(nuevaAsignatura);
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota1")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnota1()==(nuevaNota)){
					objeto[f].setnota1(objeto[f].getnota1()+nuevaNota);
					objeto[f].setnotafinal(objeto[f].getnota1()+objeto[f].getnota2()+objeto[f].getnota3());
						}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota2")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnota2()==(nuevaNota)){
					objeto[f].setnota2(objeto[f].getnota2()+nuevaNota);
					objeto[f].setnotafinal(objeto[f].getnota1()+objeto[f].getnota2()+objeto[f].getnota3());
				}
					}
				}
				else if (CriterioModificarRespuesta.equals("nota3")){
					double nuevaNota=Integer.parseInt(JOptionPane.showInputDialog("Ingrese cuantos puntos desea agregar"));
					for (int f = 0; f < cantidadPersonas; f++) {
						if (objeto[f].getnota3()==(nuevaNota)){
					objeto[f].setnota3(objeto[f].getnota3()+nuevaNota);
					objeto[f].setnotafinal(objeto[f].getnota1()+objeto[f].getnota2()+objeto[f].getnota3());
				}
					}
				}	
	
		
		
	}
	
	
	}
	
	
	
	
	
	
	}





	private static void imprimirEstudiante(estudiante[] objeto, int f) {
		System.out.println("# "+f+" nombre "+objeto[f].getnombre()+" "+objeto[f].getapellido()+" identificacion "+objeto[f].getidentificacion()+" asignatura "+objeto[f].getasignatura()+" nota1 "+objeto[f].getnota1()+" nota2 "+objeto[f].getnota2()+" nota3 "+objeto[f].getnota3()+" notafinal "+objeto[f].getnotafinal());
	}





	private static void imprimirEstudiantes(int cantidadPersonas, estudiante[] objeto, int nuevasPersonas) {
		for (int i = 0; i < (cantidadPersonas+nuevasPersonas); i++) {
			imprimirEstudiante(objeto, i);
			}
	}

	
	
	
	
	private static void informacionEstudiantes(String[] datos, estudiante[] objeto, int f) {
		String nombre,apellido,asignatura;
		int identificacion;
		double nota1,nota2,nota3,notafinal;
		nombre = JOptionPane.showInputDialog("Ingrese su nombre");
		apellido = JOptionPane.showInputDialog("Ingrese su apellido");
		identificacion = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su identificacion"));
		String selec = (String) JOptionPane.showInputDialog(null,"Seleccione que materia esta cursando"+"","Elegir",JOptionPane.INFORMATION_MESSAGE,null,datos,datos[0]);
		asignatura= selec;
		notafinal=0;
		nota1 = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su nota # 1"));
		nota2 = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su nota # 2"));
		nota3 = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su nota # 3"));
		notafinal = (nota1*0.3)+(nota2*0.3)+(nota3*0.4); 
		objeto[f] = new estudiante(nombre,identificacion,apellido,asignatura,nota1,nota2,nota3,notafinal);
	}
}


