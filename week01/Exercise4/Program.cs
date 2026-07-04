using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        Console.Write("Enter number: ");
        number = Convert.ToInt32(Console.ReadLine());

        while (number != 0)
        {
            numbers.Add(number);
            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
        }

        // Core: sum, average, max
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        double average = (double)sum / numbers.Count;

        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch 1: smallest positive number
        int? smallestPositive = null;
        foreach (int n in numbers)
        {
            if (n > 0)
            {
                if (smallestPositive == null || n < smallestPositive)
                {
                    smallestPositive = n;
                }
            }
        }

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There were no positive numbers.");
        }

        // Stretch 2: sort and display
        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}