namespace ShoppingModelLibrary.Exceptions
{
    public class CartCapacityExceededException : Exception
    {
        string message;
        public CartCapacityExceededException()
        {
            message = "Cart capacity exceeded.";
        }
        public override string Message => message;
    }
}