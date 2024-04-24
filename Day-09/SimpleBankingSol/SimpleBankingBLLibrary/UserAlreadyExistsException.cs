namespace SimpleBankingBLLibrary
{
    public class UserAlreadyExistsException : Exception
    {
        private readonly string _message;
        public UserAlreadyExistsException()
        {
            _message = "User already exists. Please choose a different username.";
        }
        public override string Message => _message;
    }
}