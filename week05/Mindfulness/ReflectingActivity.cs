using System;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private string _prompt;
    private string[] _questions;

    public ReflectingActivity(int duration)
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.",
            duration)
    {
        _prompt = GetRandomPrompt();

        _questions = new string[]
        {
            "Why was this experience meaningful to you?",
            "What did you learn from this experience?",
            "How did you feel when it happened?",
            "What did you learn about yourself?",
            "How did this experience change you?",
            "How can you use what you learned in the future?"
        };
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompt} ---");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to your experience.");
        Console.WriteLine();

        Stopwatch stopwatch = Stopwatch.StartNew();
        int questionIndex = 0;

        while (stopwatch.Elapsed.TotalSeconds < GetDuration())
        {
            Console.Write($"> {_questions[questionIndex]} ");
            ShowSpinner(5);
            Console.WriteLine();

            questionIndex++;

            if (questionIndex >= _questions.Length)
            {
                questionIndex = 0;
            }
        }

        stopwatch.Stop();

        Console.WriteLine();
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        string[] prompts =
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you overcame a challenge.",
            "Think of a time when you accomplished something important."
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);

        return prompts[index];
    }
}