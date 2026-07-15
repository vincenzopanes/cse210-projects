// Creativity:
// This program exceeds the core requirements by allowing the user
// to record and save their mood with each journal entry.
// The mood is displayed when viewing entries and is also saved
// and restored when loading the journal from a file.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.WriteLine("Select a choice from the menu:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine();
                    Console.WriteLine(prompt);
                    Console.Write("> ");

                    string answer = Console.ReadLine();

                    Entry entry = new Entry();

                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = answer;

                   Console.Write("Mood today: ");
                    entry._mood = Console.ReadLine();

                    journal.AddEntry(entry);

                    break;

                case 2:
                    journal.DisplayAll();

                    break;

                case 3:
                    Console.WriteLine("Filename:");
                    string filename = Console.ReadLine();

                    journal.LoadFromFile(filename);

                    Console.WriteLine("Journal loaded.");

                    break;

                case 4:
                    Console.WriteLine("Filename: ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);

                    Console.WriteLine("Journal saved.");

                    break;

                case 5:
                    Console.WriteLine("Goodbye!");

                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");

                    break;
            }
        }
    }
}