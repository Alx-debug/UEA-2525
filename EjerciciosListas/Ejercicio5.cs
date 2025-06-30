using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosListas
{
    public class Ejercicio5
    {
        /// <summary>
        /// Muestra los números del 1 al 10 en orden inverso separados por comas.
        /// </summary>
        public void MostrarNumerosInversos()
        {
            List<int> numeros = Enumerable.Range(1, 10).Reverse().ToList();
            Console.WriteLine(string.Join(", ", numeros));
        }
    }
}
