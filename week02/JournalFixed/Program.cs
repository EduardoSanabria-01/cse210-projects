// To exceed requirements, this program saves and loads the journal using the
// JSON (JavaScript Object Notation) format. This is a robust, human-readable
// format that easily handles special characters like commas and quotes without
// the complexity of manual CSV parsing. This is achieved using the popular
// Newtonsoft.Json library.
// To use this, you would need to add the package to your project by running:
// dotnet add package Newtonsoft.Json

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(randomPrompt);
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, randomPrompt, entryText);
                    theJournal.AddEntry(newEntry);
                    break;

                case "2":
                    // Display the journal
                    theJournal.DisplayAll();
                    break;

                case "3":
                    // Load the journal from a file
                    Console.WriteLine("What is the filename?");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    // Save the journal to a file
                    Console.WriteLine("What is the filename?");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    // Quit the program
                    Console.WriteLine("Goodbye!\n");
                    return;

                default:
                    Console.WriteLine("Sorry, that is not a valid option. Please try again.");
                    break;
            }
        }
    }
}