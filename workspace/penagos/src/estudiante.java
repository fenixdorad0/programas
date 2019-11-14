public class estudiante {;
//declara
	private String nombre,apellido,asignatura;
	private int identificacion;
	double nota1,nota2,nota3,notafinal;
	
//inicializa 
	public estudiante() {
		nombre = "";
		identificacion = 0;
		apellido= "";
		asignatura="";
		nota1=0;
		nota2=0;
		nota3=0;
		notafinal=0;
		
	}
//el apartado donde se guarda el nombre y cedula desde finalizando ultimo
	public estudiante(String nom,int id,String ap,String as,double not1,double not2,double not3,double notf){
		nombre = nom;
		identificacion = id;
		apellido =ap;
		asignatura =as;
		nota1 =not1;
		nota2=not2;
		nota3=not3;
		notafinal=notf;
	}
//retornar
	public String getnombre() {
		return nombre;
	}
//asignar
	public void setnombre(String nombre){
		this.nombre =nombre;
	}
//retornar
	public int getidentificacion (){
		return identificacion;
	}
//asignar
	public void setidentificacion(int identificacion){
		this.identificacion = identificacion;
	}
	public String getapellido (){
		return apellido;
	}
//asignar
	public void setapellido(String apellido){
		this.apellido = apellido;
	}
	public String getasignatura() {
		return asignatura;
	}
//asignar
	public void setasignatura(String asignatura){
		this.asignatura =asignatura;
	}
	public double getnota1 (){
		return nota1;
	}
//asignar
	public void setnota1(double nota1){
		this.nota1 = nota1;
	}
	public double getnota2 (){
		return nota2;
	}
//asignar
	public void setnota2(double nota2){
		this.nota2 = nota2;
	}
	public double getnota3 (){
		return nota3;
	}
//asignar
	public void setnota3(double nota3){
		this.nota3 = nota3;
	}
	public double getnotafinal (){
		return notafinal;
	}
//asignar
	public void setnotafinal(double notafinal){
		this.notafinal = notafinal;
	}
}
