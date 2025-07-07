using System;
using ListasEnlazadas.Collections;

namespace ListasEnlazadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = new ListaSimple();
            lista.InsertarFinal(10);
            lista.InsertarFinal(20);
            lista.InsertarFinal(30);

            Console.WriteLine("Lista original:");
            lista.DibujarLista();

            // Ejercicio 1
            Console.WriteLine($"\nNúmero de elementos: {lista.ContarElementos()}");

            // Ejercicio 2
            lista.Invertir();
            Console.WriteLine("\nLista invertida:");
            lista.DibujarLista();

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
