using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class NonSuchUserException : Exception
    {
        public NonSuchUserException()
        {
        }

        public NonSuchUserException(string? message) : base(message)
        {
        }

        public NonSuchUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NonSuchUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}