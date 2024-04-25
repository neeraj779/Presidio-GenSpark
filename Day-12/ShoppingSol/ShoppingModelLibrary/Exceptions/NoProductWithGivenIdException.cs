namespace ShoppingModelLibrary.Exceptions
{
    public class NoProductWithGivenIdException : Exception
    {
        string message;
        public NoProductWithGivenIdException()
        {
            message = "No Product with the given ID was found.";
        }
        public override string Message => message;
    }
}