using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoSuchEmployeeException : Exception
    {
        string _message;
        public NoSuchEmployeeException()
        {
            _message = "No such employee found";
        }
        public override string Message => _message;
    }
}