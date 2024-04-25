namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        string message;
        public NoCustomerWithGiveIdException()
        {
            message = "No customer with the given ID was found.";
        }
        public override string Message => message;
    }
}