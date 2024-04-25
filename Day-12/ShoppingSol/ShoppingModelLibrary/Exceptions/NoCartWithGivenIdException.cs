namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGivenIdException : Exception
    {
        string message;
        public NoCartWithGivenIdException()
        {
            message = "No Cart with the given ID was found.";
        }
        public override string Message => message;
    }
}