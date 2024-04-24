namespace RequestTrackerApplication
{
    internal class Program
    {
        /// <summary>
        /// Represents the method for understanding sequence statements.
        /// </summary>
        void UnderstandingSequenceStatments()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hi");
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }

        /// <summary>
        /// Represents the method for understanding selection with if statement.
        /// </summary>
        void UnderstandingSelectionWithIf()
        {
            string strName = "Ramu";
            if (strName == "Ramu")
            {
                Console.WriteLine("Welcome Ramu. you are authorized");
                Console.WriteLine("Bingo!!");
            }
            else if (strName == "Somu")
                Console.WriteLine("You are Somu not Ramu. Only Basic access");
            else
                Console.WriteLine("I don't know who you are. Get out...");
        }

        /// <summary>
        /// Represents the method for understanding switch case statements.
        /// </summary>
        void UnderstandingSwithCase()
        {
            int choice = 2;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Oops, you entered an invalid number");
                    break;
            }
        }

        /// <summary>
        /// Represents the method for understanding iteration with for loop.
        /// </summary>
        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"Hello {i}");
            }
        }

        /// <summary>
        /// Represents the method for understanding iteration with while loop.
        /// </summary>
        void UnderstandingIterationWithWhile()
        {
            int i = 0;
            while (i < 8)
            {
                Console.WriteLine($"Hello {i}");
                i++;
            }
        }

        /// <summary>
        /// Represents the method for understanding iteration with do while loop.
        /// </summary>
        void UnderstandingIterationWithDoWhile()
        {
            int i = 0;
            do
            {
                Console.WriteLine($"Hello {i}");
                i = Convert.ToInt32(Console.ReadLine());
            } while (i > 0);
        }

        /// <summary>
        /// method for understanding array and finding the repeating numbers.
        /// </summary>
        void UnderstandingArray()
        {
            int[] numbers = { 20, 67, 90, 77, 66, 68 };
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber, secondNumber;
                firstNumber = numbers[i] / 10;
                secondNumber = numbers[i] % 10;
                if (firstNumber == secondNumber)
                    countOfRepeatingNumbers++;
            }
            Console.WriteLine("The numbe rof repeating numbers is " + countOfRepeatingNumbers);
        }

        /// <summary>
        /// method for finding the elements having same three digits.
        /// </summary>
        void ElementsHavingSameThreeDigits()
        {
            int[] numbers = { 123, 456, 789, 234, 111, 890, 345, 777, 901 };
            int countOfNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber, secondNumber, thirdNumber;
                firstNumber = numbers[i] / 100;
                secondNumber = numbers[i] % 100 / 10;
                thirdNumber = numbers[i] % 10;
                if (firstNumber == secondNumber && secondNumber == thirdNumber)
                    countOfNumbers++;
            }
            Console.WriteLine("The number of elements having same three digits is " + countOfNumbers);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            // program.UnderstandingSequenceStatments();
            // program.UnderstandingSelectionWithIf();
            // program.UnderstandingSwithCase();
            // program.UnderstandingIterationWithFor();
            // program.UnderstandingIterationWithWhile();
            // program.UnderstandingIterationWithDoWhile();
            program.ElementsHavingSameThreeDigits();
        }
    }
}
