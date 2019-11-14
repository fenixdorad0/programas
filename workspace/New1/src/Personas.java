package new1;
public class Personas {
    private String Codigo;
    private String Nombre;
    private String Semestre;
    private int Edad;

    public int getEdad() {
        return Edad;
    }
    public void setEdad(int Edad) {
        this.Edad = Edad;
    }
    public String getNombre() {
        return Nombre;
    }
    public void setNombre(String Nombre) {
        this.Nombre = Nombre;
    }
    public String getCodigo() {
        return Codigo;
    }
    public void setCodigo(String Codigo) {
        this.Codigo = Codigo;
    }
    public String getSemestre() {
        return Semestre;
    }
    public void setSemestre(String Semestre) {
        this.Semestre = Semestre;
    }
    
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("\nCodigo: ");
        sb.append(Codigo);
        sb.append("\nNombre: ");
        sb.append(Nombre);
        sb.append("\nSemestre: ");
        sb.append(Semestre);
        sb.append("\nEdad: ");
        sb.append(Edad);    
        return sb.toString();
    }    
}
