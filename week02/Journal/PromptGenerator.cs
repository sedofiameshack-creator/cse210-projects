using System;
using System.Collections.Generic;

namespace JournalApp
{
    // Owns the list of possible journal prompts and knows how to pick one at
    // random. Keeping this logic in its own class means the Journal and
    // Program classes don't need to know how prompts are stored or chosen.
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _random;

        public PromptGenerator()
        {
            _random = new Random();
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is something new I learned today?",
                "What am I most grateful for today?",
                "What challenge did I overcome today?",
                "What is one thing I want to accomplish tomorrow?"
            };
        }

        public string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}