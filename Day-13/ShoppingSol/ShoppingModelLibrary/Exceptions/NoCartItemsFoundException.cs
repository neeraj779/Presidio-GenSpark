namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartItemsFoundException : Exception
    {
        string message;
        public NoCartItemsFoundException()
        {
            message = "No Cart Items were found.";
        }
        public override string Message => message;
    }
}