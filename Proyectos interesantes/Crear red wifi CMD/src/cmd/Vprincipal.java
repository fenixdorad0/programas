
package cmd;
import java.awt.Color;
import java.io.*;
public class Vprincipal extends javax.swing.JFrame {
    

    public Vprincipal() {
        initComponents();
        
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        ssid = new javax.swing.JTextField();
        pass = new javax.swing.JTextField();
        TextName = new javax.swing.JLabel();
        textPass = new javax.swing.JLabel();
        alternador = new javax.swing.JToggleButton();
        ledRed = new javax.swing.JTextField();
        autor = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        ssid.setText("default");
        ssid.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ssidActionPerformed(evt);
            }
        });

        pass.setText("123456789");
        pass.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                passActionPerformed(evt);
            }
        });

        TextName.setText("nombre");

        textPass.setText("contraseña");

        alternador.setForeground(new java.awt.Color(0, 0, 5));
        alternador.setText("iniciar RED");
        alternador.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                alternadorActionPerformed(evt);
            }
        });

        ledRed.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ledRedActionPerformed(evt);
            }
        });

        autor.setText("By fenixdorad0");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(16, 16, 16)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(ssid, javax.swing.GroupLayout.PREFERRED_SIZE, 79, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(18, 18, 18)
                                        .addComponent(pass, javax.swing.GroupLayout.PREFERRED_SIZE, 79, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(ledRed, javax.swing.GroupLayout.PREFERRED_SIZE, 20, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(18, 18, 18)
                                        .addComponent(alternador, javax.swing.GroupLayout.PREFERRED_SIZE, 89, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(37, 37, 37))))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(28, 28, 28)
                                .addComponent(TextName)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(textPass)
                                .addGap(12, 12, 12)))
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addComponent(autor)))
                .addGap(22, 22, 22))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(25, 25, 25)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(TextName, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(textPass)
                        .addGap(5, 5, 5)))
                .addGap(1, 1, 1)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(ssid, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(pass, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(2, 2, 2)))
                .addGap(9, 9, 9)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(alternador)
                    .addComponent(ledRed, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(autor)
                .addContainerGap())
        );

        pass.getAccessibleContext().setAccessibleParent(pass);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void ssidActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ssidActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_ssidActionPerformed

    private void passActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_passActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_passActionPerformed

    private void alternadorActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_alternadorActionPerformed
      
    String s = null;
    String textssid=ssid.getText();
    String textpass=pass.getText();
        if(alternador.isSelected()){
            
       alternador.setText("RED ON");
       autor.setText("Gracias por usar este programa");
       if (textssid.length()==0 || textssid.length()>20){
       alternador.setText("Cambie el SSID");
       }
       else if (textpass.length()<8 || textpass.length()>28){
       alternador.setText("Cambie el PASS");    
       }
       else{
           ledRed.setBackground(Color.green);
       
                try {

                        // Determinar en qué SO estamos
                        String so = System.getProperty("os.name");

                        String comando;
                        

                        // Comando para Linux
                        if (so.equals("Linux"))
                                comando = "ifconasdfig";

                        // Comando para Windows
                        else
                                comando = "cmd /c netsh wlan set hostednetwork ssid="+textssid+" key="+textpass +"&& netsh wlan start hostednetwork && echo acción";

                        // Ejcutamos el comando
                        Process p = Runtime.getRuntime().exec(comando);

                        BufferedReader stdInput = new BufferedReader(new InputStreamReader(
                                        p.getInputStream()));

                        BufferedReader stdError = new BufferedReader(new InputStreamReader(
                                        p.getErrorStream()));

                        // Leemos la salida del comando
                        System.out.println("Ésta es la salida standard del comando:\n");
                        while ((s = stdInput.readLine()) != null) {
                                System.out.println(s);
                        }

                        // Leemos los errores si los hubiera
                        System.out
                                        .println("Ésta es la salida standard de error del comando (si la hay):\n");
                        while ((s = stdError.readLine()) != null) {
                                System.out.println(s);
                        }

                        
                } catch (IOException e) {
                        System.out.println("Excepción: ");
                        e.printStackTrace();
                        
                }
        }
        }
        else {            
            alternador.setText("RED OFF");
            if (textssid.length()==0 || textssid.length()>20){
                alternador.setText("Cambie el SSID");
            }
            else if (textpass.length()<8 || textpass.length()>28){
            alternador.setText("Cambie el PASS");    
            }
            else{
                ledRed.setBackground(Color.red);
                try {

                        // Determinar en qué SO estamos
                        String so = System.getProperty("os.name");

                        String comando;

                        // Comando para Linux
                        if (so.equals("Linux"))
                                comando = "ifconasdfig";

                        // Comando para Windows
                        else
                                comando = "cmd /c netsh wlan stop hostednetwork";

                        // Ejcutamos el comando
                        Process p = Runtime.getRuntime().exec(comando);

                        BufferedReader stdInput = new BufferedReader(new InputStreamReader(
                                        p.getInputStream()));

                        BufferedReader stdError = new BufferedReader(new InputStreamReader(
                                        p.getErrorStream()));

                        // Leemos la salida del comando
                        System.out.println("Ésta es la salida standard del comando:\n");
                        while ((s = stdInput.readLine()) != null) {
                                System.out.println(s);
                        }

                        // Leemos los errores si los hubiera
                        System.out
                                        .println("Ésta es la salida standard de error del comando (si la hay):\n");
                        while ((s = stdError.readLine()) != null) {
                                System.out.println(s);
                        }

                        
                } catch (IOException e) {
                        System.out.println("Excepción: ");
                        e.printStackTrace();
                        
                }
        }
        }
    }//GEN-LAST:event_alternadorActionPerformed

    private void ledRedActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ledRedActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_ledRedActionPerformed

    public static void main(String args[]) {
        
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Vprincipal().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel TextName;
    private javax.swing.JToggleButton alternador;
    private javax.swing.JLabel autor;
    private javax.swing.JTextField ledRed;
    private javax.swing.JTextField pass;
    private javax.swing.JTextField ssid;
    private javax.swing.JLabel textPass;
    // End of variables declaration//GEN-END:variables
}
