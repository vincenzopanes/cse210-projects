using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            duration)
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            Console.Write("Breathe in...");
            Pause(4);
            Console.WriteLine();

            if ((DateTime.Now - startTime).TotalSeconds >= GetDuration())
            {
                break;
            }

            Console.Write("Breathe out...");
            Pause(4);
            Console.WriteLine();
        }

        EndActivity();
    }
}