using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vnesite XML značko:");
        string tag = Console.ReadLine();
        string closingTag = GetClosingTag(tag);
        if (closingTag != null)
        {
            Console.WriteLine("Za XML značko {0} je ustrezna zaključna značka: {1}", tag, closingTag);
        }
        else
        {
            Console.WriteLine("Neveljavna XML značka.");
        }
        Console.ReadKey();
    }

    static string GetClosingTag(string openingTag)
    {
        // Preveri, ali je značka pravilno oblikovana
        if (openingTag.StartsWith("<") && openingTag.EndsWith(">"))
        {
            string tagName = openingTag.Trim('<', '>');
            return "</" + tagName + ">";
        }
        else
        {
            return null; // Vrnemo null za neveljavno značko
        }
    }
}
