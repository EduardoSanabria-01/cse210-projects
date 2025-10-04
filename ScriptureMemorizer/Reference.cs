public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse; // Puede ser nulo para versículos únicos

    // Constructor para un solo versículo (ej. "Juan 3:16")
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    // Constructor para un rango de versículos (ej. "Proverbios 3:5-6")
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Devuelve el formato de texto de la referencia
    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}

