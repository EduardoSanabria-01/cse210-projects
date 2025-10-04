// Note: To use the Json serialization, you'll need the Newtonsoft.Json package.
// You can add it to your project with the command: dotnet add package Newtonsoft.Json
using Newtonsoft.Json;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        // Using JSON for robust serialization that handles special characters.
        string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            _entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine($"Journal loaded from {filename}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}