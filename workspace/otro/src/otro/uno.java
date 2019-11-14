package otro;
import javax.swing.JOptionPane;
public class uno {
	
 
	
    public static void main(String[] args)
	    {
	        int contadormas=0;
	        String ge[]={"Hombre","Mujer"};
	        String se []= {"agregar","eliminar","modificar","genero","edad","ciudad de origen","lista completa","salir"};
	        String nombre;
	        int contador=0;
	        String eleci="";
	        String sele="";
	        String ciuo;
	        int edad=0;
	        int cp= Integer.parseInt(JOptionPane.showInputDialog("Ingrese la cantidad de personas"));
	        cp=cp+1;
	        datos arreglo[] = new datos[cp];
	        for (int x = 1; x < arreglo.length; x++) 
	        {
	            boolean c= (true);
	            contador=x;
	            nombre = JOptionPane.showInputDialog("Ingrese su nombre");
	            while (c)
	            {
	               edad = Integer.parseInt(JOptionPane.showInputDialog("Ingrese su edad"));
	                if ((edad>120) ||(edad<0) )
	                {
	                    JOptionPane.showMessageDialog(null,"la edad no puede ser mayor a 120 años ingrese de nuevo su edad");
	                }
	                else
	                {
	                    c=(false);
	                }
	            }
	            ciuo= JOptionPane.showInputDialog("Ingrese su ciudad de origen");
	            eleci= (String)JOptionPane.showInputDialog(null,"eliga la opcion de su interes"+"","OPCIONES",JOptionPane.INFORMATION_MESSAGE,null,ge,ge[0]);
	            arreglo[x] = new datos( contador, nombre,edad,eleci,ciuo);    
	        }
	        lista (arreglo);
	        boolean n=(true);
	        while (n)
	        {
	            sele= (String)JOptionPane.showInputDialog(null,"eliga la opcion de su interes"+"","OPCIONES",JOptionPane.INFORMATION_MESSAGE,null,se,se[0]);
	            switch (sele)
	            {
	                case "agregar":
	                    agregar(contador,arreglo);                    
	                    break;
	                case "eliminar":
	                    break;
	                case "modificar":
	                    int numodi=Integer.parseInt(JOptionPane.showInputDialog("ingrese el numero de la lista a modificar"));
	                    modificar(contador,numodi,arreglo,ge);
	                    break;
	                
	                case "genero":
	                    System.out.println("listado de hombres");
	                    genero("Hombre", arreglo);
	                    System.out.println("listado de mujeres");
	                    genero("Mujer", arreglo);
	                    break;
	                case "edad":
	                    System.out.println("listado mayores de edad");
	                    edad (18 , arreglo);
	                    break;
	                case "ciudad de origen":
	                    System.out.println("lista de ciudades de origen ");
	                    String ciu=JOptionPane.showInputDialog("ciudad a buscar");
	                    ciudado(ciu ,arreglo);
	                    break;
	                case "lista completa":
	                    lista(arreglo);
	                    break;
	                case "salir":
	                    n=(false);
	                    break;
	                }
	        }
	    }
	    public static void agregar (int x, datos arreglo [])
	    {
	        int añadir=Integer.parseInt(JOptionPane.showInputDialog("cuantas personas desea añadir"));
	        JOptionPane.showMessageDialog(null,"esto es el numero de contador "+x);
	        for (int a = 1; a < arreglo.length; a++)
	        {
	            
	        }
	    }
	    public static void ciudado (String c, datos arreglo [])
	    {
	        System.out.println("lista de personas de la ciudad "+ c);
	        for (int a = 1; a < arreglo.length; a++) 
	        {
	            if (arreglo[a].getciuo().equals(c))
	            {
	                System.out.println(" nombre: " + arreglo[a].getnombre()+" "+" edad: "+arreglo[a].getEdad()+" "+" genero: "+arreglo[a].getGenero()+ " "+" ciudad de origen: "+ arreglo [a].getciuo());
	            }
	        }
	    }

	    public static void genero (String j, datos arreglo[])
	    {
	        for (int a = 1; a < arreglo.length; a++) 
	                {
	            if (arreglo[a].getGenero().equals(j))
	                    {
	                        System.out.println(" nombre: " + arreglo[a].getnombre()+" "+" edad: "+arreglo[a].getEdad()+" "+" genero: "+arreglo[a].getGenero()+ " "+" ciudad de origen: "+ arreglo [a].getciuo());
	                    }   
	                }  
	    }
	    public static void edad (int k, datos arreglo[])
	    {
	        for (int a = 1; a < arreglo.length; a++) 
	        {
	            if (arreglo[a].getEdad()>=(k))
	            {
	                System.out.println(" nombre: " + arreglo[a].getnombre()+" "+" edad: "+arreglo[a].getEdad()+" "+" genero: "+arreglo[a].getGenero()+ " "+" ciudad de origen: "+ arreglo [a].getciuo());
	            }
	        }
	        System.out.println("listado menores de edad");
	        for (int a = 1; a < arreglo.length; a++) 
	        {
	            if (arreglo[a].getEdad()<(k))
	            {
	                System.out.println(" nombre: " + arreglo[a].getnombre()+" "+" edad: "+arreglo[a].getEdad()+" "+" genero: "+arreglo[a].getGenero()+ " "+" ciudad de origen: "+ arreglo [a].getciuo());
	            }   
	        }
	    }
	    public static void modificar (int contador, int numodi, datos arreglo[], String ge[])
	    {
	        String tu[]={"Nombre","Edad","Genero","ciudad de origen","Editar todos los campos"};
	        String elecion=(String)JOptionPane.showInputDialog(null,"eliga la opcion de su interes"+"","OPCIONES",JOptionPane.INFORMATION_MESSAGE,null,tu,tu[0]); 
	        switch (elecion)
	        {
	            case "Nombre":
	                arreglo[numodi].nombre=JOptionPane.showInputDialog("Ingrese su nombre");
	                System.out.println("Estos son los datos modificados del usuario");
	                System.out.println("N°"+arreglo[numodi].getcontadores()+" nombre: " + arreglo[numodi].getnombre()+" "+" edad: "+arreglo[numodi].getEdad()+" "+" genero: "+arreglo[numodi].getGenero()+ " "+" ciudad de origen: "+ arreglo [numodi].getciuo());
	                return;
	            case "Edad":
	                arreglo[numodi].edad=Integer.parseInt(JOptionPane.showInputDialog("ingrese la edad a modificar"));
	                System.out.println("Estos son los datos modificados del usuario");
	                System.out.println("N°"+arreglo[numodi].getcontadores()+" nombre: " + arreglo[numodi].getnombre()+" "+" edad: "+arreglo[numodi].getEdad()+" "+" genero: "+arreglo[numodi].getGenero()+ " "+" ciudad de origen: "+ arreglo [numodi].getciuo());
	                return;
	            case "Genero":
	                arreglo[numodi].eleci=(String)JOptionPane.showInputDialog(null,"eliga la su genero"+"","OPCIONES",JOptionPane.INFORMATION_MESSAGE,null,ge,ge[0]);
	                System.out.println("Estos son los datos modificados del usuario");
	                System.out.println("N°"+arreglo[numodi].getcontadores()+" nombre: " + arreglo[numodi].getnombre()+" "+" edad: "+arreglo[numodi].getEdad()+" "+" genero: "+arreglo[numodi].getGenero()+ " "+" ciudad de origen: "+ arreglo [numodi].getciuo());
	                return;
	                
	             case "ciudad de origen":
	                arreglo[numodi].ciuo=JOptionPane.showInputDialog("ingrese la ciudad modificada");
	                System.out.println("Estos son los datos modificados del usuario");
	                System.out.println("N°"+arreglo[numodi].getcontadores()+" nombre: " + arreglo[numodi].getnombre()+" "+" edad: "+arreglo[numodi].getEdad()+" "+" genero: "+arreglo[numodi].getGenero()+ " "+" ciudad de origen: "+ arreglo [numodi].getciuo());
	                return;
	            case "Editar todos los campos":
	                arreglo[numodi].nombre=JOptionPane.showInputDialog("ingrese el nombre a modificar");
	                arreglo[numodi].edad=Integer.parseInt(JOptionPane.showInputDialog("ingrese la edad a modificar"));
	                arreglo[numodi].eleci=(String)JOptionPane.showInputDialog(null,"eliga la su genero"+"","OPCIONES",JOptionPane.INFORMATION_MESSAGE,null,ge,ge[0]);                     
	                System.out.println("Estos son los datos modificados del usuario");
	                System.out.println("N°"+arreglo[numodi].getcontadores()+" nombre: " + arreglo[numodi].getnombre()+" "+" edad: "+arreglo[numodi].getEdad()+" "+" genero: "+arreglo[numodi].getGenero()+ " "+" ciudad de origen: "+ arreglo [numodi].getciuo());
	                break;
	        }
	    }
	    public static void lista (datos arreglo[])
	    {
	        for (int a = 1; a < arreglo.length; a++) 
	                    {
	                        System.out.println( "N°"+arreglo[a].getcontadores()+"nombre: " + arreglo[a].getnombre()+" "+" edad: "+arreglo[a].getEdad()+" "+" genero: "+arreglo[a].getGenero()+ " "+" ciudad de origen: "+ arreglo [a].getciuo());
	                    }
	    }
	}

}
