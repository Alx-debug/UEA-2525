using System;
using System.Collections.Generic;

class Program
{
    static bool IsBalanced(string expr)
    {
        // Aquí irá la lógica (ver pseudocódigo más abajo)
        return false;
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
