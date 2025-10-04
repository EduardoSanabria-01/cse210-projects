// To exceed requirements, I have enhanced the Reflection Activity.
// It now ensures that no random question is repeated until all questions
// from the list have been shown at least once in a single session.
// This is achieved by maintaining a temporary list of available questions
// and removing a question from it once it's displayed. When the list is empty,
// it is refilled from the master list, allowing the cycle to start again.

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!\n");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number from 1 to 4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}