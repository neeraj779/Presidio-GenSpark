namespace ShoppingModelLibrary.Exceptions
{
    public class DuplicateCartException : Exception
    {
        string message;
        public DuplicateCartException()
        {
            message = "Cart already exists.";
        }
        public override string Message => message;
    }
}