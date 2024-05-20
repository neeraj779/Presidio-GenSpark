using System.Globalization;
using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoEmployeesFoundException : Exception
    {
        String _message;
        public NoEmployeesFoundException()
        {
            _message = "No employees found";
        }
        public override string Message => _message;
    }
}