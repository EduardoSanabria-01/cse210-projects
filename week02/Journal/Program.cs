// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        /*
        * Exceeding Requirements:
        * - Implemented classes (Entry and Journal) in separate files to demonstrate good design principles and abstraction.
        * - Used a List<string> to store the prompts, making them easy to modify or expand.
        * - Included comprehensive error handling for file operations (FileNotFoundException and IOException) to prevent crashes and provide helpful user feedback.
        */
        
        Journal myJournal = new Journal();
        
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is a goal I am working on, and what did I do today to get closer to it?",
            "Describe something beautiful you saw today."
        };

        Random random = new Random();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Journal Program Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Please enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(prompt, response);
                    break;
                case "2":
                    Console.WriteLine("\n--- Your Journal Entries ---");
                    myJournal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g., myjournal.txt): ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load from (e.g., myjournal.txt): ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Thank you for using the journal program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}