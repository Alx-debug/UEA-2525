// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

/// <summary>
/// Clase principal de la aplicación de gestión de catálogo de revistas.
/// </summary>
public class Program
{
    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// </summary>
    /// <param name="args">Argumentos de la línea de comandos (no se utilizan).</param>
    public static void Main(string[] args)
    {
        // Crear y poblar el catálogo de revistas con al menos 10 títulos.
        List<string> catalogoDeRevistas = new List<string>
        {
            "National Geographic",
            "Scientific American",
            "Time",
            "The New Yorker",
            "Vogue",
            "Wired",
            "Forbes",
            "Harvard Business Review",
            "Muy Interesante",
            "PC World",
            "Hobby Consolas",
            "Ciencia Hoy"
        };

        // Bucle principal para mantener el menú interactivo en ejecución.
        while (true)
        {
            Console.Clear(); // Limpia la consola para una presentación más limpia.
            Console.WriteLine("======================================");
            Console.WriteLine("   CATÁLOGO DE REVISTAS v1.0");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Buscar Título de Revista");
            Console.WriteLine("2. Salir");
            Console.WriteLine("======================================");
            Console.Write("Seleccione una opción: ");

            // Capturar la opción del usuario.
            char opcion = Console.ReadKey(true).KeyChar;
            Console.WriteLine(); // Salto de línea después de la selección.

            // Evaluar la opción seleccionada por el usuario.
            switch (opcion)
            {
                case '1':
                    // Llamar a la función de búsqueda y mostrar el resultado.
                    bool fueEncontrado = BuscarTituloIterativo(catalogoDeRevistas);
                    Console.ForegroundColor = fueEncontrado ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(fueEncontrado ? "\n>> Resultado: Encontrado" : "\n>> Resultado: No encontrado");
                    Console.ResetColor();
                    break;

                case '2':
                    // Salir de la aplicación.
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    // Manejar una opción no válida.
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    Console.ResetColor();
                    break;
            }

            // Pausa para que el usuario pueda leer el resultado antes de que el menú se vuelva a mostrar.
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Realiza una búsqueda iterativa de un título en el catálogo de revistas.
    /// La búsqueda no distingue entre mayúsculas y minúsculas.
    /// </summary>
    /// <param name="catalogo">La lista de títulos de revistas donde se buscará.</param>
    /// <returns>Verdadero si el título se encuentra, de lo contrario, falso.</returns>
    public static bool BuscarTituloIterativo(List<string> catalogo)
    {
        Console.Write("\nIngrese el título de la revista a buscar: ");
        string tituloBuscado = Console.ReadLine();

        // Validar que el usuario haya ingresado texto.
        if (string.IsNullOrWhiteSpace(tituloBuscado))
        {
            Console.WriteLine("El término de búsqueda no puede estar vacío.");
            return false;
        }

        // Bucle 'foreach' que recorre cada elemento del catálogo (búsqueda iterativa).
        foreach (string revista in catalogo)
        {
            // Comparamos el título actual con el buscado, ignorando mayúsculas/minúsculas.
            if (string.Equals(revista, tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si se encuentra, devolvemos 'true' y la función termina.
            }
        }

        // Si el bucle termina y no se encontró el título, devolvemos 'false'.
        return false;
    }
}
