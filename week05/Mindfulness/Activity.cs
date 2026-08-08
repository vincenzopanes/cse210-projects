using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void StartActivity()
    {
        Console.WriteLine();
        Console.WriteLine($"Starting {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
    }

    public void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }

        Console.Write(" ");
        Console.Write("\b");
    }

    public void EndActivity()
    {
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity.");
    }

    public int GetDuration()
    {
        return _duration;
    }

}