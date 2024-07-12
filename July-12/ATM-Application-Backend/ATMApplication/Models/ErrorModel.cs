namespace ATMApplication.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorModel(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
