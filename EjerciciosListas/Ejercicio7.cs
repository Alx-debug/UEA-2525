using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosListas
{
    public class Ejercicio7
    {
        /// <summary>
        /// Elimina las letras que ocupen posiciones múltiplos de 3 en el abecedario.
        /// </summary>
        public void EliminarMultiploDeTres()
        {
            List<char> abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

            for (int i = abecedario.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0) // (i+1) porque el índice inicia en 0
                    abecedario.RemoveAt(i);
            }

            Console.WriteLine(string.Join(" ", abecedario));
        }
    }
}
