import java.util.HashMap;
import java.util.Map;
import java.util.Random;

public class Registros {
    private Map<Integer, MensajeFortuna> mensajes = new HashMap<>();

    public Registros() {
        mensajes.put(1, new MensajeFortuna("El verde es exito."));
        mensajes.put(2, new MensajeFortuna("A veces el dejar ir es bueno."));
        mensajes.put(3, new MensajeFortuna("Hoy es un gran dia."));
        mensajes.put(4, new MensajeFortuna("Confía en el proceso y sigue adelante."));
        mensajes.put(5, new MensajeFortuna("No te rindas."));
        mensajes.put(6, new MensajeFortuna("El éxito llega a quienes trabajan por él."));
    }

    public MensajeFortuna random() {
        Random random = new Random();
        Integer[] keys = mensajes.keySet().toArray(new Integer[0]);
        int randomKey = keys[random.nextInt(keys.length)];
        return mensajes.get(randomKey);
    }
}

