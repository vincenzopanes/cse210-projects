// Creativity:
// I added a session counter that keeps track of how many
// mindfulness activities the user completes during the program.

using System;

class Program
{
    static void Main(string[] args)
    {
        int sessionsCompleted = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine($"Sessions completed: {sessionsCompleted}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness Program.");
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                continue;
            }

            Console.Write("How long, in seconds, would you like for your session? ");

            int duration;

            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a positive number: ");
            }

            Console.Clear();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity(duration);
                breathing.Run();
                sessionsCompleted++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity(duration);
                reflecting.Run();
                sessionsCompleted++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity(duration);
                listing.Run();
                sessionsCompleted++;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}