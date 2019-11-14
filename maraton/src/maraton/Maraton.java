package maraton;

/**
 *
 * @author Yeferson Quevedo
 */
import java.util.Scanner;
public class Maraton {

   
    public static void main(String[] args) {
            int a;
            int d;
            int c4=0;
            Scanner sc = new Scanner(System.in);
            int[] Bi = new int[12];
            int[] Cj = new int[12];
            String[] texto= new String [20];
            a = sc.nextInt();
            d = sc.nextInt();
            
            
            if (a>=2 && a<=11 && d>=2 && d<=11){
            //---toma de datos----
            for (int c = 0; c < a; c++)
            {
                    Bi[c] = sc.nextInt();
                    //while (Bi[c]<1 || Bi[c]>104){
                    //System.out.print("verifique el numero \n");
                    //Bi[c] = sc.nextInt();
             //}                  
            }
            
            for (int c1 = 0; c1 < d; c1++)
            {
                  Cj [c1] = sc.nextInt();
                  //while (Cj[c1]<1 || Cj[c1]>104){
                  //System.out.print("verifique el numero \n");
                  //Cj [c1] = sc.nextInt();
            //}
            }
            int mayorBi=Bi[0];
             for (int c2 = 0; c2 < a; c2++)
            {
                if (Bi[c2]> mayorBi){
                    mayorBi=Bi[c2];
                }
            }
             
            int mayorCj=Cj[0];
             for (int c2 = 0; c2 < a; c2++)
            {
                if (Cj[c2]> mayorCj){
                    mayorCj=Cj[c2];
                }
            } 
            
            System.out.print("\n");
            c4=0;
             if (mayorCj>mayorBi){
                 
                 texto[c4]="y";
             }
             else if(mayorCj==mayorBi){
                 texto[c4]="n";
             }
             else {
                 texto[c4]="4";
             }
            System.out.print("\n"); 
            
            }
            
            
            
            for (int c5 = 0; c5 < c4 ; c5++)
            {
            System.out.print(texto[c5]);    
            }
            
            
            }
            
    }

    
    

