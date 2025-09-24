using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("Alma", 37, 37), "Counsel with the Lord in all thy doings, and he will direct thee for good; yea, when thou liest down at night lie down unto the Lord, that he may watch over you in your sleep; and when thou risest in the morning let thy heart be full of thanks unto God; and if ye do these things, ye shall be lifted up at the last day.")
        };

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        string userInput = "";

        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish.");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(random.Next(2, 4)); 
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram ended.");
    }
}