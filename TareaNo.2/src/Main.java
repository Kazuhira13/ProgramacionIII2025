import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] numeros = {2, 4, 6, 8, 10, 12, 14, 16, 18};
        System.out.println("Array: " + Arrays.toString(numeros));
        System.out.print("Ingrese el número que desea buscar: ");
        int valorBuscado = sc.nextInt();

        int resultado = busquedaBinaria.busquedaBinaria(numeros,valorBuscado);
        if (resultado != -1) {
            System.out.println("Búsqueda Binaria: El número " + valorBuscado + " se encuentra en la posición " + resultado);
        } else {
            System.out.println("Búsqueda Binaria: El número " + valorBuscado + " no está en el array.");
        }

        int resultado2 = busquedaSecuencial.busquedaSecuencial(numeros,valorBuscado);
        if(resultado2 != -1){
            System.out.println("Búsqueda Secuencial: El número " + valorBuscado + " se encuentra en la posición " + resultado2);
        }else {
            System.out.println("Búsqueda Secuencial: El número "+ valorBuscado +" no está en el array.");
        }
    }
}