
public class busquedaBinaria {
    public static int busquedaBinaria(int[] arreglo, int valor) {
        int izquierda = 0, derecha = arreglo.length - 1;
        while (izquierda <= derecha) {
            int medio = izquierda + (derecha - izquierda) / 2;

            if (arreglo[medio] == valor) {
                return medio;
            } else if (arreglo[medio] < valor) {
                izquierda = medio + 1;
            } else {
                derecha = medio - 1;
            }
        }
        return -1;
    }
}
