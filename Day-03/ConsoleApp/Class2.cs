//2)  create an application that will find the greatest of the given numbers. Take input until the user enters a negative number

namespace ConsoleApp
{
    internal class Class2
    {
        static double FindGreatestNumber()
        {
            double max = double.MinValue;
            double num;

            Console.WriteLine("Enter numbers: ");

            while (true)
            {
                try
                {
                    num = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                if (num < 0) break;

                if (num > max)
                    max = num;
            }

            return max;
        }
        static void Main(string[] args)
        {
            double max = FindGreatestNumber();
            if (max == double.MinValue)
                Console.WriteLine("No valid numbers entered.");
            else
                Console.WriteLine($"The greatest number entered is: {max}");
        }
    }
}
