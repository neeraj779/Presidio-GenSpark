namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartItemWithGivenProductIdException : Exception
    {
        string message;
        public NoCartItemWithGivenProductIdException()
        {
            message = "No cart item with the given product ID was found.";
        }
        public override string Message => message;
    }
}