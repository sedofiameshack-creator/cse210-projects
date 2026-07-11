using System;

namespace JournalApp
{
    // Represents a single journal entry: the date it was written, the prompt
    // the user was given, their response, and the mood they were in.
    // Member variables are kept private to demonstrate abstraction - other
    // classes only interact with an Entry through its public properties.
    public class Entry
    {
        private string _date;
        private string _prompt;
        private string _response;
        private string _mood;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }

        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public string Mood
        {
            get { return _mood; }
            set { _mood = value; }
        }

        public Entry(string date, string prompt, string response, string mood)
        {
            _date = date;
            _prompt = prompt;
            _response = response;
            _mood = mood;
        }

        // Formats the entry nicely for display on screen.
        public override string ToString()
        {
            return $"Date: {_date}\nMood: {_mood}\nPrompt: {_prompt}\nResponse: {_response}\n";
        }
    }
}