using System;
using System.Collections.Generic;


public class Video
{
    //Attributes (member variables)
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    //Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    //Methods
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public void DisplayVideo()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments: {GetCommentCount()}");

        foreach (Comment comment in _comments)
        {
            comment.Display();
        }

        Console.WriteLine();
    }
    public int GetCommentCount()
    {
        return _comments.Count;
    }
}