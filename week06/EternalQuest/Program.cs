// W06 Project: Eternal Quest Program
// Program.cs
// Author: [Your Name]

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
To exceed the requirements, I have added a "Leveling" system.
1. The GoalManager tracks the player's current level.
2. After an event is recorded and points are awarded, the system checks if the new score
   is high enough to advance to the next level.
3. The level thresholds increase exponentially, making it more challenging to level up over time.
4. When the player levels up, a congratulatory message is displayed.
5. The current level is displayed along with the score.
This adds a simple but effective gamification element that encourages continued progress.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        Console.Clear();
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine();

        string choice = "";
        while (choice != "6")
        {
            goalManager.DisplayPlayerInfo();
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.ListGoalDetails();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using the Eternal Quest Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                    break;
            }
            Console.WriteLine(); // Add a blank line for better readability
        }
    }
}