using System;

public class Comment
{
    //Attributes (member variables)
    private string _name;
    private string _text;

    //Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    //Methods
    public void Display()
    {
        Console.WriteLine($"{_name}: {_text}");
    }
}