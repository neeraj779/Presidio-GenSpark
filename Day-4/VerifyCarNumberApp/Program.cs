namespace VerifyCarNumber
{
    /// <summary>
    /// Contains methods for validating and verifying car numbers.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Checks if the provided car number is valid.
        /// </summary>
        /// <param name="carNumber">The car number to validate.</param>
        /// <returns>True if the car number is valid; otherwise, false.</returns>
        static bool IsValidCarNumber(string carNumber)
        {
            return carNumber.Length == 16 && IsNumeric(carNumber);
        }

        /// <summary>
        /// Checks if the provided string consists only of numeric characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string consists only of numeric characters; otherwise, false.</returns>
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

        /// <summary>
        /// Calculates the checksum of the provided car number.
        /// </summary>
        /// <param name="carNumber">The car number for which to calculate the checksum.</param>
        /// <returns>The calculated checksum.</returns>
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

        /// <summary>
        /// Verifies if the provided car number is valid by checking its checksum.
        /// </summary>
        /// <param name="carNumber">The car number to verify.</param>
        /// <returns>True if the car number is valid; otherwise, false.</returns>
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