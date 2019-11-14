package new1;

import java.util.ArrayList;
import java.util.Scanner;

public class Basico1 {


    static ArrayList<Personas> Personas = new ArrayList<>();
    static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        leerPersonas();
        System.out.println("\nPersonas:");
        mostrarCodigo();
        mostrarNombre();
        mostrarEdad();
        System.out.println("\nPersona con mas edad: " + mostrarMayorEdad());
        System.out.println("\nPersonas ordenadas de menor a mayor");
        mostrarOrdenadosEdad();
    }
   

public static void leerPersonas(){
        String Codigo;
        String Nombre;
        String Semestre;
        int Edad;
        Personas aux;
        int i, N;
        do {
            System.out.print("Número de Personas: ");
            N = sc.nextInt();
        } while (N < 0);
        sc.nextLine();
        for (i = 1; i <= N; i++) {
            System.out.println("Persona " + i);
            System.out.print("Codigo: ");
            Codigo = sc.nextLine();          
            System.out.print("Nombre: ");
            Nombre = sc.nextLine();
            System.out.print("Semestre: ");
            Semestre = sc.nextLine();
            System.out.print("Edad: ");
            Edad = sc.nextInt();
            sc.nextLine();
            aux = new Personas();
            aux.setCodigo(Codigo);
            aux.setNombre(Nombre);
            aux.setSemestre(Semestre);
            aux.setEdad(Edad);
            Personas.add(aux);
        }
    }   
    public static void mostrarCodigo(){      
        for(int i = 0; i< Personas.size(); i++)
            System.out.println(Personas.get(i));
    }
   

    public static void mostrarNombre(){
        String Nombre;
        System.out.print("Introduce Nombre: ");
        Nombre = sc.nextLine();
        System.out.println("Personas llamada " + Nombre);
        for(int i = 0; i<Personas.size(); i++){
            if(Personas.get(i).getNombre().equalsIgnoreCase(Nombre))
                System.out.println(Personas.get(i));
        }
    }
  
    public static void mostrarEdad(){
        int Edad;
        System.out.print("Introduce Edad: ");
        Edad = sc.nextInt();
        System.out.println("Personas menores de " + Edad + " Años");
        for(int i = 0; i<Personas.size(); i++){
            if(Personas.get(i).getEdad() < Edad)
                System.out.println(Personas.get(i));
        }
    }
   
    public static Personas mostrarMayorEdad(){
        Personas mayor = Personas.get(0);
        for(int i = 0; i < Personas.size(); i++){
            if(Personas.get(i).getEdad() > mayor.getEdad())
                mayor = Personas.get(i);
        }
        return mayor;
    }
    public static void mostrarOrdenadosEdad(){
        int i, j;
        Personas aux;
        for(i = 0; i< Personas.size()-1; i++)
            for(j=0;j<Personas.size()-i-1; j++)
                if(Personas.get(j+1).getEdad() < Personas.get(j).getEdad()){
                    aux = Personas.get(j+1);
                    Personas.set(j+1, Personas.get(j));
                    Personas.set(j, aux);                
                }
        mostrarCodigo();
    }
} //fin de la clase principal