using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class UserNotActiveException : Exception
    {
        string _message;
        public UserNotActiveException()
        {
            _message = "User not active";
        }

        public override string Message => _message;
    }
}