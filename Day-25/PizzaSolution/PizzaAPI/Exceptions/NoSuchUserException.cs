using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class NoSuchUserException : Exception
    {
        string _message;
        public NoSuchUserException()
        {
            _message = "User not found";
        }

        public override string Message => _message;
    }
}