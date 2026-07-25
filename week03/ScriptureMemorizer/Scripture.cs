using System;
using System.Collections.Generic;
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] pieces = text.Split(' ');

        foreach (string piece in pieces)
        {
            _words.Add(new Word(piece));
        }
    }

    private Random _random = new Random();
    public void HideRandomWords(int count)
{
    int hiddenCount = 0;

    while (hiddenCount < count && !IsCompletelyHidden())
    {
        int index = _random.Next(_words.Count);

        if (!_words[index].IsHidden())
        {
            _words[index].Hide();
            hiddenCount++;
        }
    }
}

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + "\n\n";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        
        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    
    
}