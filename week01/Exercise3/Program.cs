using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101); // 1 to 100 inclusive
            int guess;
            int guessCount = 0;

            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
            guessCount++;

            while (guess != magicNumber)
            {
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }

                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;
            }

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }
    }
}