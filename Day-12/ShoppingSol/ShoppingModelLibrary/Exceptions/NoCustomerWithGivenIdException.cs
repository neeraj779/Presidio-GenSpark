namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGivenIdException : Exception
    {
        string message;
        public NoCustomerWithGivenIdException()
        {
            message = "No customer with the given ID was found.";
        }
        public override string Message => message;
    }
}