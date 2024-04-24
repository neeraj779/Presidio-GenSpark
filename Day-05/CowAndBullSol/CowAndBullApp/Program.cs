namespace CowAndBullApp
{
    internal class Program
    {
        /// <summary>
        /// Checks the user's guess against the secret string and returns the number of cows and bulls.
        /// </summary>
        /// <param name="secret">The secret string that the user is trying to guess.</param>
        /// <param name="guess">The user's guess.</param>
        /// <returns>A tuple containing the number of cows and bulls. A cow is a correct character in the correct position. A bull is a correct character in the wrong position.</returns>
        (int cows, int bulls) CheckGuess(string secret, string guess)
        {
            int cows = 0;
            int bulls = 0;

            char[] secretChars = secret.ToCharArray();
            char[] guessChars = guess.ToCharArray();

            for (int i = 0; i < secret.Length; i++)
            {
                if (secretChars[i] == guessChars[i])
                {
                    cows++;
                    secretChars[i] = guessChars[i] = ' ';
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guessChars[i] != ' ')
                {
                    int index = Array.IndexOf(secretChars, guessChars[i]);
                    if (index != -1)
                    {
                        bulls++;
                        secretChars[index] = ' ';
                    }
                }
            }

            return (cows, bulls);
        }

        private static void Main(string[] args)
        {
            string secretWord = "golf";
            int attempts = 0;
            Program game = new Program();


            Console.WriteLine("Try to guess the secret 4-letter word. You have 10 attempts.");
            while (attempts < 10)
            {
                Console.Write("Enter your guess: ");
                string guess = Console.ReadLine().ToLower();

                if (guess.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-letter word.");
                    continue;
                }

                attempts++;

                (int cows, int bulls) result = game.CheckGuess(secretWord, guess);
                Console.WriteLine($"Cows: {result.cows}, Bulls: {result.bulls}");

                if (result.cows == 4)
                {
                    Console.WriteLine("Congratulations! You Won!!!");
                    break;
                }
            }

            if (attempts == 10)
                Console.WriteLine("You lost! The secret word was 'golf'.");
        }
    }
}
