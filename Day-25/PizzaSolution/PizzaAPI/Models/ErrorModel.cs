namespace EmployeeRequestTrackerAPI.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string? Message { get; set; }

        public ErrorModel()
        {
        }

        public ErrorModel(int statusCode, string message)
        {
            ErrorCode = statusCode;
            Message = message;
        }

    }
}
