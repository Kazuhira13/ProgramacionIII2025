import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Main extends JFrame {
    private JLabel mensajelabel;
    private JButton generarboton;
    private Registros registros = new Registros();

    public Main(){
        setTitle("Galleta de Fortuna");
        setSize(300, 200);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());

        mensajelabel = new JLabel("Presiona para saber tu fortuna",SwingConstants.CENTER);
        generarboton = new JButton("Obtener Fortuna");

        generarboton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e){
                MensajeFortuna mensaje = registros.random();
                mensajelabel.setText(mensaje.getMensaje());
            }
        });
        add(mensajelabel, BorderLayout.CENTER);
        add(generarboton, BorderLayout.SOUTH);
    }
    public static void main(String[] args) {
        SwingUtilities.invokeLater(()->{
            Main frame = new Main();
            frame.setVisible(true);
        });
    }
}