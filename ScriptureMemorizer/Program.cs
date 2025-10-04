using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("--- ESTA ES MI PRUEBA ---");
        // --- Exceeding Requirements ---
        // 1. Scripture Library: The program loads a list of scriptures instead of just one.
        //    A random scripture is chosen each time the program runs.
        // 2. Hiding Logic: The program intelligently hides only words that are not already hidden,
        //    preventing it from trying to re-hide the same word.
        // 3. Varied Hiding: Hides a variable number of words (2 or 3) each time to make it more dynamic.

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
                // Hide 2 or 3 words randomly
                scripture.HideRandomWords(random.Next(2, 4)); 
            }
        }
        
        // Final display with all words hidden before exiting
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram ended.");
    }
}

