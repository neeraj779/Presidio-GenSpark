namespace SimpleBankingBLLibrary
{
    public class UserNotFoundException : Exception
    {
        private readonly string _message;
        public UserNotFoundException()
        {
            _message = "User not found.";
        }
        public override string Message => _message;
    }
}