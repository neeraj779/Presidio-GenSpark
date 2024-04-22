namespace SimpleBankingBLLibrary
{
    public class InsufficientFundsException : Exception
    {
        private readonly string _message;
        public InsufficientFundsException()
        {
            _message = "Insufficient funds. Cannot complete transaction.";
        }
        public override string Message => _message;
    }
}