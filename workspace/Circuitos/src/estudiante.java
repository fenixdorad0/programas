//*
public class estudiante {;
//declara
	private String nombre,municipio;
	private int edad;
	
//inicializa 
	public estudiante() {
		nombre = "";
		edad = 0;
		municipio= "";
	}
//el apartado donde se guarda el nombre y cedula desde finalizando ultimo
	public estudiante(String n,int c,String m){
		nombre = n;
		edad = c;
		municipio =m;
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
	public int getedad (){
		return edad;
	}
//asignar
	public void setedad(int edad){
		this.edad = edad;
	}
	public String getmunicipio (){
		return municipio;
	}
//asignar
	public void setmunicipio(String municipio){
		this.municipio = municipio;
	}
}
