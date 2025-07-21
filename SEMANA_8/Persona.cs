namespace ColaAsientosApp
{
    // Representa a una persona en la fila
    public class Persona
    {
        public int Id { get; }
        public string Nombre { get; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
