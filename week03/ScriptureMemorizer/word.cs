public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Devuelve la palabra o guiones bajos si está oculta
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Reemplaza cada letra con un guión bajo
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}

