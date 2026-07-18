// Represents a single word within a scripture. Each word knows its own
// text and whether it is currently hidden, and knows how to display
// itself (either as normal text or as underscores).
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hides this word (it will now display as underscores).
    public void Hide()
    {
        _isHidden = true;
    }

    // Reveals this word again.
    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the text to display for this word: either the original word,
    // or a string of underscores matching its length if it is hidden.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}