namespace ShoppingFE
{
    internal class Program
    {
        void Calculate(Func<int, int, int> cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();

            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            int[] evenNumebrs = numbers.EvenCatch();
            foreach (int n in evenNumebrs)
                Console.WriteLine(n);
        }
    }

    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }

    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> evens = new List<int>();
            foreach (int n in nums)
            {
                if ((n & 1) == 0)
                    evens.Add(n);
            }
            return evens.ToArray();
        }
    }

}
