using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class DuplicateUserException : Exception
    {
        string _message;
        public DuplicateUserException()
        {
            _message = "User already exists";
        }

        public override string Message => _message;
    }
}