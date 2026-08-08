using System;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private string _prompt;

    public ListingActivity(int duration)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by listing as many things as you can.",
            duration)
    {
        _prompt = GetRandomPrompt();
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        Pause(5);
        Console.WriteLine();
        Console.WriteLine();

        int count = 0;
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < GetDuration())
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                count++;
            }
        }

        stopwatch.Stop();

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");

        Pause(3);
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        string[] prompts =
        {
            "Who are people that you appreciate?",
            "What are things that make you happy?",
            "What are things you are grateful for?",
            "Who are people that have helped you?",
            "What are things that you are looking forward to?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);

        return prompts[index];
    }
}