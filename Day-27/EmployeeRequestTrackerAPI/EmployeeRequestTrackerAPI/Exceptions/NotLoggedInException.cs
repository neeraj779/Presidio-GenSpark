using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NotLoggedInException : Exception
    {
        public NotLoggedInException()
        {
        }

        public NotLoggedInException(string? message) : base(message)
        {
        }

        public NotLoggedInException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}