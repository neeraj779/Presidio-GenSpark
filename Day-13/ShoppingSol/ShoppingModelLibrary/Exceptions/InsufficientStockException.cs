namespace ShoppingModelLibrary.Exceptions
{
    public class InsufficientStockException : Exception
    {
        string message;
        public InsufficientStockException()
        {
            message = "Insufficient stock.";
        }
        public override string Message => message;
    }
}