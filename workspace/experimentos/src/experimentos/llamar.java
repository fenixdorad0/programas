package experimentos;
import javax.swing.Icon;
import javax.swing.JOptionPane;

public class llamar {

	public static void main(String[] args) {
		
		
		int asd = JOptionPane.showConfirmDialog(null, "Que tal le parecio perro");
		Icon icon = null;
		JOptionPane.showConfirmDialog(null, "que tal", "asd", asd, asd, icon);
		JOptionPane.showMessageDialog(null, asd);
		
	}
}

