namespace ConsoleAppExcercise2
{
    internal class Program
    {
        static bool IsValidCarNumber(string carNumber)
        {
            return carNumber.Length == 16 && IsNumeric(carNumber);
        }

        static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static int CalculateChecksum(string carNumber)
        {
            int sum = 0;
            for (int i = carNumber.Length - 1; i >= 0; i--)
            {
                int digit = carNumber[i] - '0';
                if ((carNumber.Length - i) % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = digit % 10 + digit / 10;
                    }
                }
                sum += digit;
            }
            return sum;
        }

        static bool VerifyCarNumber(string carNumber)
        {
            return CalculateChecksum(carNumber) % 10 == 0;
        }

        static void Main(string[] args)
        {
            string? carNumber;
            do
            {
                Console.WriteLine("Please enter the car Number:");
                carNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(carNumber))
                {
                    Console.WriteLine("Car Number cannot be empty. Please enter the car number:");
                }
                else if (!IsValidCarNumber(carNumber))
                {
                    Console.WriteLine("Invalid car number. Please enter a 16-digit numeric car number:");
                }
            } while (string.IsNullOrEmpty(carNumber) || !IsValidCarNumber(carNumber));

            bool isValid = VerifyCarNumber(carNumber);

            if (isValid)
                Console.WriteLine("Given car number is valid");
            else
                Console.WriteLine("Given car number is not valid");
        }
    }
}