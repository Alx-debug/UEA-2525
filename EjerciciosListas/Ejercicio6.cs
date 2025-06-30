using System;
using System.Collections.Generic;

namespace EjerciciosListas
{
    public class Ejercicio6
    {
        /// <summary>
        /// Solicita notas de asignaturas, elimina las aprobadas y muestra las que deben repetirse.
        /// </summary>
        public void FiltrarAsignaturas()
        {
            List<string> asignaturas = new() { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            List<string> reprobadas = new();

            foreach (var asignatura in asignaturas)
            {
                Console.Write($"Nota en {asignatura}: ");
                if (!int.TryParse(Console.ReadLine(), out int nota)) nota = 0;
                if (nota < 7) reprobadas.Add(asignatura);
            }

            Console.WriteLine("\nDebes repetir: " + (reprobadas.Count > 0
                ? string.Join(", ", reprobadas)
                : "¡Ninguna!"));
        }
    }
}
