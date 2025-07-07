using ListasEnlazadas.Models;
using System;

namespace ListasEnlazadas.Collections
{
    public class ListaSimple
    {
        private Nodo? head;

        public ListaSimple()
        {
            head = null;
        }

        public void InsertarInicio(int dato)
        {
            var nuevo = new Nodo(dato);
            nuevo.Next = head;
            head = nuevo;
        }

        public void InsertarFinal(int dato)
        {
            var nuevo = new Nodo(dato);
            if (head == null)
                head = nuevo;
            else
            {
                Nodo actual = head;
                while (actual.Next != null)
                    actual = actual.Next;
                actual.Next = nuevo;
            }
        }

        public void DibujarLista()
        {
            Console.Write("head --> ");
            for (Nodo? actual = head; actual != null; actual = actual.Next)
            {
                Console.Write($"[ {actual.Data} | * ]");
                if (actual.Next != null) Console.Write(" --> ");
            }
            Console.WriteLine(" --> null");
        }

        // Ejercicio 1: contar elementos
        public int ContarElementos()
        {
            int contador = 0;
            for (Nodo? actual = head; actual != null; actual = actual.Next)
                contador++;
            return contador;
        }

        // Ejercicio 2: invertir lista
        public void Invertir()
        {
            Nodo? anterior = null;
            Nodo? actual = head;
            while (actual != null)
            {
                Nodo? siguiente = actual.Next;
                actual.Next = anterior;
                anterior = actual;
                actual = siguiente;
            }
            head = anterior;
        }
    }
}
