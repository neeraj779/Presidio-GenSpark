using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class NoSuchPizzaException : Exception
    {
        string _message;
        public NoSuchPizzaException()
        {
            _message = "Pizza not found";
        }

        public override string Message => _message;
    }
}