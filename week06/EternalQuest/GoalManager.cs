using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Player Info");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    DisplayPlayerInfo();
                    break;

                case "5":
                    SaveGoals();
                    break;

                case "6":
                    LoadGoals();
                    break;

                case "7":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
        Console.WriteLine($"Player Level: {GetPlayerLevel()}");
    }

    public void ListGoalNames() 
    { 
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        } 
    } 
    public void ListGoalDetails() 
    { 
        Console.WriteLine("The goals are:"); 

        for (int i = 0; i < _goals.Count; i++) 
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice (1-3): ");

        string choice = Console.ReadLine();

        Console.Write("Enter the short name of the goal: ");
        string shortName = Console.ReadLine();

        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (choice == "1")
        {
            goal = new SimpleGoal(shortName, description, points);
        }
        else if (choice == "2")
        {
            goal = new EternalGoal(shortName, description, points);
        }
        else if (choice == "3")
        {
            Console.Write("Enter the target number of completions: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter the bonus points for completing the checklist: ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(shortName, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal not created.");
            return;
        }
        
        AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    } 
    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Enter the number of the goal: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            choice--;

            if (choice >= 0 && choice < _goals.Count)
            {
                Goal selectedGoal = _goals[choice];
                int pointsEarned = selectedGoal.RecordEvent();
                _score += pointsEarned;

                Console.WriteLine(
                    $"Event recorded for goal: {selectedGoal.GetShortName()}. " +
                    $"Points earned: {pointsEarned}");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
     public void SaveGoals() 
    { 
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    } 
    public void LoadGoals() 
    { 
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            using (StreamReader inputFile = new StreamReader(filename))
            {
                _score = int.Parse(inputFile.ReadLine());
                _goals.Clear();

                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];
                    string shortName = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    Goal goal = null;

                    if (goalType == "SimpleGoal")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        goal = new SimpleGoal(shortName, description, points);
                        if (isComplete)
                        {
                            goal.RecordEvent(); // Mark as complete if it was complete
                        }
                    }
                    else if (goalType == "EternalGoal")
                    {
                        goal = new EternalGoal(shortName, description, points);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        goal = new ChecklistGoal(shortName, description, points, amountCompleted, target, bonus);
                    }

                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public string GetPlayerLevel()
    {
        if (_score >= 2000)
        {
            return "Eternal Master";
        }
        else if (_score >= 1000)
        {
            return "Champion";
        }
        else if (_score >= 500)
        {
            return "Adventurer";
        }
        else
        {
            return "Novice";
        }
    }
}