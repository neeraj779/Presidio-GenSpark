//4) Find the length of the given user's name

namespace ConsoleApp
{
    internal class Class4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string? name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                Console.WriteLine("No name was entered");

            else
                Console.WriteLine($"The length of your name is: {name.Length}");
        }
    }
}