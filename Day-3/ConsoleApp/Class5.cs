//5) Create a application that will take username and password from user. check if username is "ABC" and passwod is "123". 
//Print error message if username or password is wrong
//Allow user 3 attemts.
//After 3rd attempt if user enters invalid credentials then print msg to intimate user taht he/she has exceeded the number of attempts and stop


namespace ConsoleApp
{
    internal class Class5
    {

        static bool checkPassword(string username, string password)
        {
            return username == "ABC" && password == "123";
        }
        static void Main(string[] args)
        {
            const int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Console.WriteLine("Enter your Username:");
                string? username = Console.ReadLine();

                Console.WriteLine("Enter your Password:");
                string? password = Console.ReadLine();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    Console.WriteLine("Username or password cannot be empty.");

                else
                {
                    bool isValid = checkPassword(username, password);

                    if (isValid)
                    {
                        Console.WriteLine("Welcome, " + username + "!");
                        break;
                    }
                    else
                        Console.WriteLine("Invalid username or password. Please try again.");
                }
                attempts++;
            }
            if (attempts == maxAttempts)
            {
                Console.WriteLine("Maximum number of login attempts reached. Please try again later.");
            }
        }
    }
}