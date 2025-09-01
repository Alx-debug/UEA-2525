using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Generate 500 citizens
        List<string> citizens = new List<string>();
        for (int i = 1; i <= 500; i++)
        {
            citizens.Add($"Ciudadano {i}");
        }

        Random rand = new Random();
        HashSet<string> pfizer = new HashSet<string>();
        HashSet<string> astrazeneca = new HashSet<string>();

        // 75 vaccinated with Pfizer
        while (pfizer.Count < 75)
        {
            pfizer.Add(citizens[rand.Next(citizens.Count)]);
        }

        // 75 vaccinated with AstraZeneca
        while (astrazeneca.Count < 75)
        {
            astrazeneca.Add(citizens[rand.Next(citizens.Count)]);
        }

        // Citizens with both doses
        HashSet<string> both = new HashSet<string>(pfizer);
        both.IntersectWith(astrazeneca);

        // Citizens only vaccinated with Pfizer
        HashSet<string> onlyPfizer = new HashSet<string>(pfizer);
        onlyPfizer.ExceptWith(astrazeneca);

        // Citizens only vaccinated with AstraZeneca
        HashSet<string> onlyAstra = new HashSet<string>(astrazeneca);
        onlyAstra.ExceptWith(pfizer);

        // Citizens not vaccinated
        HashSet<string> vaccinated = new HashSet<string>(pfizer);
        vaccinated.UnionWith(astrazeneca);
        HashSet<string> unvaccinated = new HashSet<string>(citizens);
        unvaccinated.ExceptWith(vaccinated);

        // Print results
        Console.WriteLine($"Total ciudadanos: {citizens.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {astrazeneca.Count}");
        Console.WriteLine($"No vacunados: {unvaccinated.Count}");
        Console.WriteLine($"Ambas vacunas: {both.Count}");
        Console.WriteLine($"Solo Pfizer: {onlyPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {onlyAstra.Count}");

        // Display lists
        PrintSet("No vacunados", unvaccinated);
        PrintSet("Ambas vacunas", both);
        PrintSet("Solo Pfizer", onlyPfizer);
        PrintSet("Solo AstraZeneca", onlyAstra);
    }

    static void PrintSet(string title, HashSet<string> set)
    {
        Console.WriteLine($"\n{title} ({set.Count}):");
        foreach (var c in set)
        {
            Console.WriteLine(c);
        }
    }
}

