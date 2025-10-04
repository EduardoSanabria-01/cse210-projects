public class Entry
{
    // Public properties are used so the JSON serializer can access them.
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    // A constructor to easily create a new entry.
    public Entry(string date, string promptText, string entryText)
    {
        Date = date;
        PromptText = promptText;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"\nDate: {Date} - Prompt: {PromptText}");
        Console.WriteLine(EntryText);
    }
}