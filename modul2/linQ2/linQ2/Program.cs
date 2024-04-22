using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var badWords = new string[] { "shit", "fuck", "idiot" };
        var FilterBadWords = CreateWordReplacerFn(badWords, "kage");
        Console.WriteLine(FilterBadWords("Sikke en gang idiot")); // Udskriver: "Sikke en gang kage"
    }

    static Func<string, string> CreateWordFilterFn(string[] words)
    {
        return (text) =>
        {
            return string.Join(" ", text.Split(' ')
                .Where(word => !words.Contains(word)));
        };
    }

    static Func<string, string> CreateWordReplacerFn(string[] words, string replacementWord)
    {
        return (text) =>
        {
            return string.Join(" ", text.Split(' ')
                .Select(word => words.Contains(word) ? replacementWord : word));
        };
    }
}