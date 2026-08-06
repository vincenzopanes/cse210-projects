using System;

public class MathAssignment : Assignment
{
    private int _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, int textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}