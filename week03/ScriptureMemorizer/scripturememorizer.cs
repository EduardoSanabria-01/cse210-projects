using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Divide el texto en palabras y crea objetos Word
        string[] wordArray = text.Split(' ');
        foreach (var wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Oculta un número determinado de palabras al azar
    public void HideRandomWords(int numberToHide)
    {
        // Encuentra todas las palabras que aún no están ocultas
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        if (!visibleWords.Any())
        {
            return; // No hay más palabras para ocultar
        }
        
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            if (!visibleWords.Any()) break; // Detente si ya no hay palabras visibles
            
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            // Remueve la palabra de la lista temporal para no volver a ocultarla en este turno
            visibleWords.RemoveAt(index);
        }
    }

    // Genera el texto completo para mostrar (con palabras ocultas)
    public string GetDisplayText()
    {
        string text = "";
        foreach (var word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {text.Trim()}";
    }

    // Verifica si todas las palabras están ocultas
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
