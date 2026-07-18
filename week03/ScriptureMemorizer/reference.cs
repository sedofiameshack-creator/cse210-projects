using System;

// Represents a scripture reference, such as "John 3:16" or "Proverbs 3:5-6".
// This class is responsible only for knowing the book, chapter, and verse(s),
// and for producing a display-friendly string of itself.
public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;

    // Constructor for a single verse, e.g. Reference("John", 3, 16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a verse range, e.g. Reference("Proverbs", 3, 5, 6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Returns the reference formatted for display, e.g. "John 3:16" or "Proverbs 3:5-6"
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}