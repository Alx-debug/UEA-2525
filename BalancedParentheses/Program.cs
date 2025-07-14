using System;
using System.Collections.Generic;

class Program
{
    static bool IsBalanced(string expr)
    {
        var stack = new Stack<char>();

        foreach (char c in expr)
        {
            // Si es un paréntesis de apertura, lo apilamos
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // Si es un paréntesis de cierre, comprobamos el tope
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                    return false; // No hay apertura que casar

                char top = stack.Pop();

                // Verificamos que el par coincida
                if ((top == '(' && c != ')') ||
                    (top == '{' && c != '}') ||
                    (top == '[' && c != ']'))
                {
                    return false;
                }
            }
            // Ignoramos cualquier otro carácter
        }

        // Al final debe estar vacía para estar balanceada
        return stack.Count == 0;
    }

    static void Main()
    {
        Console.Write("Expr: ");
        string input = Console.ReadLine();
        bool balanced = IsBalanced(input);
        Console.WriteLine(balanced
            ? "Fórmula balanceada."
            : "Fórmula NO balanceada.");
    }
}
