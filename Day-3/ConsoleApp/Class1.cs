// 1) Create a application that take 2 numbers and find its sum, product and divide the first by second, also supract the second from the first. 
// Include another method to find the remainder when the first number is divided by second

namespace ConsoleApp
{
    internal class Class1
    {
        static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Product(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            if (num2 != 0)
                return num1 / num2;
            else
            {
                Console.WriteLine("Cannot divide by zero");
                return double.NaN;
            }
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Remainder(double num1, double num2)
        {
            if (num2 != 0)
                return num1 % num2;
            else
            {
                Console.WriteLine("Cannot find remainder when dividing by zero");
                return double.NaN;
            }
        }

        static void Main(string[] args)
        {
            double num1, num2;
            Console.WriteLine("Enter two numbers");

            while (true)
            {
                try
                {
                    num1 = Convert.ToDouble(Console.ReadLine());
                    num2 = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                    continue;
                }
            }

            Console.WriteLine("Sum of two numbers is: " + Sum(num1, num2));
            Console.WriteLine("Product of two numbers is: " + Product(num1, num2));
            Console.WriteLine("Division of two numbers is: " + Divide(num1, num2));
            Console.WriteLine("Subtraction of two numbers is: " + Subtract(num1, num2));
            Console.WriteLine("Remainder of two numbers is: " + Remainder(num1, num2));
        }
    }
}
