using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio9
    {
        /// <summary>
        /// Cuenta el número de veces que aparece cada vocal en una palabra.
        /// </summary>
        public void ContarVocales()
        {
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine().Trim().ToLower();

            Dictionary<char, int> conteo = new()
            {
                ['a'] = 0, ['e'] = 0, ['i'] = 0, ['o'] = 0, ['u'] = 0
            };

            foreach (char c in palabra)
                if (conteo.ContainsKey(c))
                    conteo[c]++;

            Console.WriteLine("\nNúmero de veces que aparece cada vocal:");
            foreach (var (vocal, veces) in conteo)
                Console.WriteLine($"{vocal}: {veces}");
        }
    }
}
