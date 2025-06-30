using System;
using System.Linq;

namespace EjerciciosListas
{
    public class Ejercicio8
    {
        /// <summary>
        /// Verifica si la palabra ingresada es un palíndromo.
        /// </summary>
        public void VerificarPalindromo()
        {
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine().Trim().ToLower();
            string inversa = new string(palabra.Reverse().ToArray());

            Console.WriteLine(palabra == inversa
                ? "Es un palíndromo."
                : "No es un palíndromo.");
        }
    }
}
