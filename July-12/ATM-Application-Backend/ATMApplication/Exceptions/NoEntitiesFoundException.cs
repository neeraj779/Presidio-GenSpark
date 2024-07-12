using System.Runtime.Serialization;

namespace ATMApplication.Exceptions
{
    public class NoEntitiesFoundException : Exception
    {
        public NoEntitiesFoundException()
        {
        }

        public NoEntitiesFoundException(string? message) : base(message)
        {
        }
    }
}