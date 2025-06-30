using System;

namespace EjerciciosListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ejercicios de Listas y Tuplas (C#) ===");
            Console.WriteLine("Selecciona el número de ejercicio a ejecutar:");
            Console.WriteLine("5 → Números en orden inverso");
            Console.WriteLine("6 → Asignaturas reprobadas");
            Console.WriteLine("7 → Abecedario sin posiciones múltiplos de 3");
            Console.WriteLine("8 → Verificar palíndromo");
            Console.WriteLine("9 → Contar vocales");
            Console.WriteLine("0 → Salir");

            while (true)
            {
                Console.Write("\nOpción: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion)) continue;
                if (opcion == 0) break;

                switch (opcion)
                {
                    case 5: new Ejercicio5().MostrarNumerosInversos(); break;
                    case 6: new Ejercicio6().FiltrarAsignaturas(); break;
                    case 7: new Ejercicio7().EliminarMultiploDeTres(); break;
                    case 8: new Ejercicio8().VerificarPalindromo(); break;
                    case 9: new Ejercicio9().ContarVocales(); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
        }
    }
}
