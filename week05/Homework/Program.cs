using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("John Doe", "Algebra", 5, "1-10");
        
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();
        WritingAssignment writing = new WritingAssignment("Jane Smith", "History", "The American Revolution");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingDetails());
    }
}