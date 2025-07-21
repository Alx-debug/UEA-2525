namespace ColaAsientosApp
{
    // Representa un asiento en la atracción
    public class Asiento
    {
        public int Numero { get; }
        public bool Ocupado { get; private set; }

        public Asiento(int numero)
        {
            Numero = numero;
            Ocupado = false;
        }

        public void Ocupar()
        {
            if (Ocupado)
                throw new InvalidOperationException($"El asiento #{Numero} ya está ocupado.");
            Ocupado = true;
        }

        public void Liberar()
        {
            Ocupado = false;
        }
    }
}
