using System;
using System.Collections.Generic;
using System.Linq;

// Representa la escritura completa, incluyendo la referencia y el texto.
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor que recibe la referencia y el texto.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Separa el texto en palabras y crea objetos Word.
        string[] textWords = text.Split(' ');
        foreach (string word in textWords)
        {
            _words.Add(new Word(word));
        }
    }

    // Oculta un número determinado de palabras al azar.
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        
        // Obtenemos una lista de las palabras que todavía son visibles.
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        for (int i = 0; i < numberToHide; i++)
        {
            // Si ya no hay palabras para ocultar, nos detenemos.
            if (visibleWords.Count == 0)
            {
                break;
            }
            
            // Elegimos una palabra visible al azar para ocultarla.
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            
            // La removemos de la lista temporal para no volver a elegirla en este turno.
            visibleWords.RemoveAt(index);
        }
    }

    // Devuelve el texto completo de la escritura para mostrarlo en pantalla.
    public string GetDisplayText()
    {
        // Une todas las palabras (ya sean visibles o como guiones bajos).
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }

    // Verifica si todas las palabras de la escritura ya están ocultas.
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

