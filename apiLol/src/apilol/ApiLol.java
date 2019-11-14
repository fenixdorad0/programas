/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package apilol;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import javax.swing.JOptionPane;
import org.json.JSONObject;
/**
 *
 * @author Yeferson Quevedo
 */
public class ApiLol {
    //Conectando la Appjason
    public static void main(String[] args) throws MalformedURLException, IOException {
     String listaServidores[]={"LAN","LAS","BR", "JAP", "KOR"},server;
     server = (String)JOptionPane.showInputDialog(null,"Ingrese su servidor", "lista simple",JOptionPane.INFORMATION_MESSAGE,null,listaServidores, listaServidores[0]);
     String nombre=JOptionPane.showInputDialog("Digite Su Nombre de invocador");
     URL lolApiSite=new URL("https://"+server+".api.riotgames.com/api/lol/"+server+"/v1.4/summoner/by-name/"+nombre+"?api_key=1053cf28-7a56-4934-b3dd-599b915a1470");
     BufferedReader in=new BufferedReader(new InputStreamReader(lolApiSite.openStream()));
     String lolApiJson = in.readLine();
    //System.out.print(lolApiJson); 
     //informacion Json
     JSONObject lolApi =new JSONObject(lolApiJson);
     String name= lolApi.getJSONObject(nombre).getString("name");
     int level =lolApi.getJSONObject(nombre).getInt("summonerLevel");
     int id =lolApi.getJSONObject(nombre).getInt("id");
     //paso 3 mostrar información
     System.out.println("Id= "+ id+"\nNombre= "+name+"\nNivel "+level);
    }
}
