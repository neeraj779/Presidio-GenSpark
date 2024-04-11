
//3) Find the avearage of all the numbers that are divisible by 7. Take input until the user enters a negative number

namespace ConsoleApp
{
    internal class Class3
    {
        static double FindAverageOfNumbersDivisibleBy7()
        {
            double sum = 0, count = 0;
            double input;

            Console.WriteLine("Enter numbers");

            while (true)
            {
                try
                {
                    input = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                if (input < 0) break;

                if (input % 7 == 0)
                {
                    sum += input;
                    count++;
                }
            }

            if (count == 0)
                return 0;
         
            else
                return sum / count;
            
        }

        static void Main(string[] args)
        {
            double average = FindAverageOfNumbersDivisibleBy7();
            if(average != 0)
                Console.WriteLine($"The average of numbers divisible by 7 is: {average}");
            else
                Console.WriteLine("No numbers divisible by 7 entered.");

        }
    }
}