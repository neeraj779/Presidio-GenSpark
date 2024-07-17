namespace ProductAPI.Core.Exceptions
{
    [Serializable]
    internal class NoProductsFoundException : Exception
    {
        string _message;
        public NoProductsFoundException()
        {
            _message = "No products found in the database.";
        }

        public override string Message => _message;
    }
}