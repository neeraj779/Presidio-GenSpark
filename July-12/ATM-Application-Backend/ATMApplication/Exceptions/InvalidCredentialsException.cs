using System.Runtime.Serialization;

namespace ATMApplication.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string? message) : base(message)
        {
        }
    }
}