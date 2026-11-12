
using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();

        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        englishToGerman.AddWord("Book", "Buch");
        englishToGerman.AddWord("Water", "Wasser");
        englishToGerman.AddWord("Food", "Essen");
        englishToGerman.AddWord("Dog", "Hund");
        englishToGerman.AddWord("Cat", "Katze");

        Console.WriteLine(englishToGerman.Translate("Car"));   // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'.
    /// For example, in an English to German dictionary:
    /// my_translator.AddWord("book", "buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation.
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        if (_words.TryGetValue(fromWord, out string translation))
        {
            return translation;
        }

        return "???";
    }
}
