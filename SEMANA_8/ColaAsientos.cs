using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ColaAsientosApp
{
    // Gestiona la cola de personas y la asignación de asientos
    public class ColaAsientos
    {
        private readonly Queue<Persona> _fila;
        private readonly List<Asiento> _asientos;
        private readonly StreamWriter _logWriter;

        public ColaAsientos(int totalAsientos, string rutaLogCsv)
        {
            _fila = new Queue<Persona>();
            _asientos = new List<Asiento>();
            for (int i = 1; i <= totalAsientos; i++)
                _asientos.Add(new Asiento(i));

            _logWriter = new StreamWriter(rutaLogCsv, append: false);
            _logWriter.WriteLine("Timestamp,Persona,Asiento");
        }

        public void Encolar(Persona p)
        {
            _fila.Enqueue(p);
        }

        // Saca el primero de la fila y le asigna el primer asiento libre
        public (Persona, Asiento) DesencolarYAsignar()
        {
            if (_fila.Count == 0)
                throw new InvalidOperationException("No hay más personas en la fila.");

            var persona = _fila.Dequeue();
            var asientoLibre = _asientos.FirstOrDefault(a => !a.Ocupado);
            if (asientoLibre == null)
                throw new InvalidOperationException("No quedan asientos libres.");

            asientoLibre.Ocupar();

            // Registro en CSV
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _logWriter.WriteLine($"{timestamp},{persona.Nombre},{asientoLibre.Numero}");
            _logWriter.Flush();

            return (persona, asientoLibre);
        }

        public void MostrarEstado()
        {
            Console.WriteLine();
            Console.Write("Asientos libres: ");
            Console.WriteLine(string.Join(", ",
                _asientos.Where(a => !a.Ocupado).Select(a => a.Numero)));

            Console.Write("Asientos ocupados: ");
            Console.WriteLine(string.Join(", ",
                _asientos.Where(a => a.Ocupado).Select(a => a.Numero)));

            Console.Write("Personas en espera: ");
            Console.WriteLine(string.Join(", ",
                _fila.Select(p => p.Nombre)));
            Console.WriteLine();
        }

        public void CerrarLog()
        {
            _logWriter?.Close();
        }
    }
}
