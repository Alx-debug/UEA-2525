using System;

namespace ColaAsientosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int totalAsientos = 30;
            const string rutaLog = "asignaciones.csv";

            var cola = new ColaAsientos(totalAsientos, rutaLog);

            Console.WriteLine("=== Simulación de asignación de asientos ===");
            Console.WriteLine($"Se crearán {totalAsientos} asientos y se encolarán {totalAsientos} personas.");
            Console.WriteLine();

            // Encolar usuarios
            for (int i = 1; i <= totalAsientos; i++)
            {
                Console.Write($"Ingrese nombre de la persona #{i}: ");
                string nombre = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(nombre))
                    nombre = $"Usuario {i}";

                cola.Encolar(new Persona(i, nombre));
            }

            cola.MostrarEstado();

            // Desencolar y asignar
            while (true)
            {
                try
                {
                    var (persona, asiento) = cola.DesencolarYAsignar();
                    Console.WriteLine($"Persona {persona.Nombre} asignada al asiento #{asiento.Numero}.");
                    cola.MostrarEstado();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Todos los asientos han sido asignados.");
                    break;
                }
            }

            cola.CerrarLog();
            Console.WriteLine($"Registro de asignaciones guardado en '{rutaLog}'.");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
