using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // ============================================================
    // EXCEEDING REQUIREMENTS - what was added beyond the core spec:
    //
    // 1. LIBRARY OF SCRIPTURES: instead of a single hardcoded verse,
    //    the program loads a whole library of scriptures from
    //    "scriptures.txt" and picks one at random each time it runs.
    //    If the file can't be found, it falls back to John 3:16 so
    //    the program still works.
    //
    // 2. ONLY HIDE UNHIDDEN WORDS (stretch challenge): when choosing
    //    random words to hide, the program only selects from words
    //    that are not already hidden, so the user never "wastes" a
    //    round on a word that's already gone.
    //
    // 3. RAMPING DIFFICULTY: the number of words hidden per round
    //    starts small (2 words) and increases by one each round,
    //    easing the user in instead of hiding a constant chunk of
    //    text right away.
    // ============================================================

    static void Main(string[] args)
    {
        List<Scripture> library = LoadScriptureLibrary("scriptures.txt");

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        int wordsToHidePerRound = 2;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to end: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsToHidePerRound);
            wordsToHidePerRound++;
        }
    }

    // Reads scriptures.txt and builds a list of Scripture objects.
    // Expected line format: Book|Chapter|StartVerse|EndVerse|Text
    // (StartVerse and EndVerse are the same number for a single verse.)
    private static List<Scripture> LoadScriptureLibrary(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Reference fallbackReference = new Reference("John", 3, 16);
            scriptures.Add(new Scripture(fallbackReference,
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."));
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');
            if (parts.Length != 5)
            {
                continue;
            }

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            Reference reference;
            if (startVerse == endVerse)
            {
                reference = new Reference(book, chapter, startVerse);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse, endVerse);
            }

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}