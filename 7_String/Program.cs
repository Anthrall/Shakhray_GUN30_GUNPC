using System;
using System.Text;

public class Program
{
    // Задание 1
    public static string ConcatenateStrings(string str1, string str2)
    {
        return str1 + str2;
    }

    // Задание 2
    public static string GreetUser(string name, int age)
    {
        return $"Hello, {name}!\nYou are {age} years old.";
    }

    // Задание 3
    public static string GetStringInfo(string input)
    {
        return $"{input.Length}: {input.ToUpper()}: {input.ToLower()}";
    }

    // Задание 4
    public static string GetFirstFiveChars(string input)
    {
        return input.Length >= 5 ? input.Substring(0, 5) : input;
    }

    // Задание 5
    public static StringBuilder BuildSentence(string[] words)
    {
        var sb = new StringBuilder();
        foreach (var word in words)
        {
            sb.Append(word).Append(' ');
        }
        return sb.Length > 0 ? sb.Remove(sb.Length - 1, 1) : sb;
    }

    // Задание 6
    public static string ReplaceWords(string input, string oldWord, string newWord)
    {
        return input.Replace(oldWord, newWord);
    }

    static void Main()
    {
    
        Console.WriteLine("Задание 1: " + ConcatenateStrings("Hello ", "World!"));

        Console.WriteLine("\nЗадание 2:\n" + GreetUser("Alice", 25));
       

        Console.WriteLine("\nЗадание 3: " + GetStringInfo("Капибара")); 

        Console.WriteLine("\nЗадание 4: " + GetFirstFiveChars("Компьютер"));

        var sentence = BuildSentence(new[] { "Я", "ненавижу", "понедельник" });
        Console.WriteLine("\nЗадание 5: " + sentence);

        Console.WriteLine("\nЗадание 6: " + ReplaceWords("Хочу пиццы", "пиццы", "суши"));
    }
}