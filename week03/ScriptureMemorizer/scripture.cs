using System;
using System.Collections.Generic;
using System.Linq;

// Represents a full scripture: a Reference plus the text, broken up into
// individual Word objects. This class is responsible for splitting the
// text into words, displaying the scripture, and hiding random words.
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordTexts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordsText}";
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> notYetHidden = _words.Where(w => !w.IsHidden()).ToList();

        int amountToHide = Math.Min(numberToHide, notYetHidden.Count);
        for (int i = 0; i < amountToHide; i++)
        {
            int index = _random.Next(notYetHidden.Count);
            notYetHidden[index].Hide();
            notYetHidden.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}