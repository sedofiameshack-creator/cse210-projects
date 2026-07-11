using System;

namespace JournalApp
{
    class Program
    {
        // Ways this program exceeds the core requirements:
        // 1. Each entry stores an extra "Mood" field capturing how the user felt
        //    when they wrote it, in addition to the required date/prompt/response.
        // 2. Saving and loading is done as proper CSV (with quotes and commas
        //    correctly escaped), so the file can be opened directly in Excel,
        //    rather than using a placeholder separator symbol like | or ~.
        // 3. Prompt selection is pulled out into its own PromptGenerator class,
        //    on top of the two required extra classes (Entry and Journal), to
        //    further demonstrate separation of concerns / abstraction.
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            Console.WriteLine("Welcome to your Journal!");

            while (running)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal, promptGenerator);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Enter a filename to save to (e.g. journal.csv): ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter a filename to load from (e.g. journal.csv): ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("That is not a valid choice. Please try again.");
                        break;
                }
            }
        }

        static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine($"\n{prompt}");
            Console.Write("> ");
            string response = Console.ReadLine();

            Console.Write("How would you describe your mood right now? ");
            string mood = Console.ReadLine();

            string date = DateTime.Now.ToShortDateString();

            Entry entry = new Entry(date, prompt, response, mood);
            journal.AddEntry(entry);

            Console.WriteLine("\nEntry saved!\n");
        }
    }
}