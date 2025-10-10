// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level; // For creativity feature

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    // Displays the player's current score and level
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"You are Level {_level}.");
    }

    // Lists the names of all goals for selection
    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    // Lists the full details of all goals
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    
    // Guides the user through creating a new goal
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }
    
    // Records an event for a selected goal
    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            if (!_goals[goalIndex].IsComplete())
            {
                int pointsEarned = _goals[goalIndex].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");
                CheckLevelUp(); // Check for level up after earning points
            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    
    // Saves goals and score to a file
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score},{_level}"); // Save score and level
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename}.");
    }

    // Loads goals and score from a file
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            // First line contains score and level
            string[] scoreParts = lines[0].Split(',');
            _score = int.Parse(scoreParts[0]);
            if (scoreParts.Length > 1)
            {
                _level = int.Parse(scoreParts[1]);
            }

            // Subsequent lines contain goals
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string goalData = parts[1];

                string[] dataParts = goalData.Split(',');

                string name = dataParts[0];
                string description = dataParts[1];
                int points = int.Parse(dataParts[2]);

                Goal goal = null;
                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(dataParts[3]);
                    goal = new SimpleGoal(name, description, points, isComplete);
                }
                else if (goalType == "EternalGoal")
                {
                    goal = new EternalGoal(name, description, points);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(dataParts[3]);
                    int bonus = int.Parse(dataParts[4]);
                    int amountCompleted = int.Parse(dataParts[5]);
                    goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
            Console.WriteLine($"Goals loaded from {filename}.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    
    // Creativity: Checks if the player has earned enough points to level up
    private void CheckLevelUp()
    {
        int nextLevelThreshold = 1000 * (int)Math.Pow(2, _level - 1);
        if (_score >= nextLevelThreshold)
        {
            _level++;
            Console.WriteLine("***********************************");
            Console.WriteLine($"** LEVEL UP! You are now Level {_level}! **");
            Console.WriteLine("***********************************");
        }
    }
}