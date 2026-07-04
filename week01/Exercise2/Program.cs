using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int percentage = Convert.ToInt32(Console.ReadLine());

        // Determine the letter grade
        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign based on the last digit
        int lastDigit = percentage % 10;
        string sign;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // There is no A+, only A and A-
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // There is no F+ or F-, only F
        if (letter == "F")
        {
            sign = "";
        }

        // Print the letter grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine pass/fail
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("You did not pass this time, but keep working hard for next time!");
        }
    }
}