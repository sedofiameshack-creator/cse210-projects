using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JournalApp
{
    // Manages the full collection of journal entries, and handles displaying
    // them along with saving/loading them to and from a file.
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is currently empty.\n");
                return;
            }

            Console.WriteLine();
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine("-------------------------------------");
            }
        }

        // Saves the journal as a properly formatted CSV file, escaping quotes
        // and commas in the content so the file opens correctly in Excel
        // (this goes beyond the simplification of using a placeholder symbol
        // like | or ~ as a separator).
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Mood,Prompt,Response");
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(
                        $"{EscapeCsvField(entry.Date)},{EscapeCsvField(entry.Mood)}," +
                        $"{EscapeCsvField(entry.Prompt)},{EscapeCsvField(entry.Response)}"
                    );
                }
            }

            Console.WriteLine($"\nJournal saved to {filename}.\n");
        }

        // Loads the journal from a CSV file, replacing any entries currently
        // stored in memory.
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\nFile '{filename}' was not found.\n");
                return;
            }

            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            // Skip the header row.
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                List<string> fields = ParseCsvLine(lines[i]);

                if (fields.Count == 4)
                {
                    Entry entry = new Entry(fields[0], fields[2], fields[3], fields[1]);
                    loadedEntries.Add(entry);
                }
            }

            _entries = loadedEntries;
            Console.WriteLine($"\nJournal loaded from {filename}. {_entries.Count} entries loaded.\n");
        }

        // Wraps a field in quotes and doubles any internal quotes whenever the
        // field contains a comma, quote, or newline, following standard CSV rules.
        private string EscapeCsvField(string field)
        {
            if (field == null)
            {
                field = "";
            }

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }

            return field;
        }

        // Parses a single CSV line into its individual fields, correctly
        // handling quoted fields that may themselves contain commas or
        // escaped double-quotes.
        private List<string> ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            StringBuilder current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            current.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        fields.Add(current.ToString());
                        current.Clear();
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
            }

            fields.Add(current.ToString());
            return fields;
        }
    }
}