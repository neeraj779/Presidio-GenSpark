using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoRequestFoundException : Exception
    {
        public NoRequestFoundException()
        {
        }

        public NoRequestFoundException(string? message) : base(message)
        {
        }

        public NoRequestFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoRequestFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}