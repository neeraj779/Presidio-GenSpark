using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class PizzaNotAvailableException : Exception
    {
        string _message;
        public PizzaNotAvailableException()
        {
            _message = "Pizza not available";
        }

        public override string Message => _message;
    }
}