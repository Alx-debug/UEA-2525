using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto"},
        {"government", "gobierno"},
        {"company", "compañía"},
        {"number", "número"},
        {"group", "grupo"},
        {"problem", "problema"},
        {"fact", "hecho"},
        {"be", "ser"},
        {"have", "tener"},
        {"do", "hacer"},
        {"say", "decir"},
        {"get", "obtener"},
        {"make", "hacer"},
        {"go", "ir"},
        {"know", "saber"},
        {"will", "voluntad"},
        {"would", "haría"},
        {"can", "poder"},
        {"like", "gustar"},
        {"horse", "caballo"}
    };

    static Dictionary<string, string> spanishToEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    static Program()
    {
        foreach (var pair in englishToSpanish)
        {
            if (!spanishToEnglish.ContainsKey(pair.Value))
            {
                spanishToEnglish.Add(pair.Value, pair.Key);
            }
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("3. Salir");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TranslateMenu();
                    break;
                case "2":
                    AddWord();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void TranslateMenu()
    {
        Console.WriteLine("Seleccione la dirección de traducción:");
        Console.WriteLine("1. Español a Inglés");
        Console.WriteLine("2. Inglés a Español");
        Console.Write("Opción: ");
        string dir = Console.ReadLine();

        Dictionary<string, string> dict;
        if (dir == "1")
        {
            dict = spanishToEnglish;
        }
        else if (dir == "2")
        {
            dict = englishToSpanish;
        }
        else
        {
            Console.WriteLine("Dirección no válida.");
            return;
        }

        Console.Write("Ingrese la frase: ");
        string phrase = Console.ReadLine();
        string translated = TranslatePhrase(phrase, dict);
        Console.WriteLine("Traducción: " + translated);
    }

    static string TranslatePhrase(string phrase, Dictionary<string, string> dict)
    {
        char[] punctuation = { ',', '.', ';', ':', '!', '?', '¿', '¡' };
        string[] words = phrase.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            string leading = "";
            string trailing = "";

            while (word.Length > 0 && punctuation.Contains(word[0]))
            {
                leading += word[0];
                word = word.Substring(1);
            }
            while (word.Length > 0 && punctuation.Contains(word[word.Length - 1]))
            {
                trailing = word[word.Length - 1] + trailing;
                word = word.Substring(0, word.Length - 1);
            }

            string lower = word.ToLowerInvariant();
            if (dict.TryGetValue(lower, out string translated))
            {
                if (word.Length > 0 && char.IsUpper(word[0]))
                {
                    translated = char.ToUpper(translated[0]) + translated.Substring(1);
                }
                words[i] = leading + translated + trailing;
            }
            else
            {
                words[i] = leading + word + trailing;
            }
        }
        return string.Join(" ", words);
    }

    static void AddWord()
    {
        Console.Write("Palabra en inglés: ");
        string en = Console.ReadLine();
        Console.Write("Palabra en español: ");
        string es = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(en) || string.IsNullOrWhiteSpace(es))
        {
            Console.WriteLine("Entrada no válida.");
            return;
        }

        englishToSpanish[en.ToLowerInvariant()] = es.ToLowerInvariant();
        if (!spanishToEnglish.ContainsKey(es.ToLowerInvariant()))
        {
            spanishToEnglish[es.ToLowerInvariant()] = en.ToLowerInvariant();
        }

        Console.WriteLine("Palabra agregada correctamente.");
    }
}

