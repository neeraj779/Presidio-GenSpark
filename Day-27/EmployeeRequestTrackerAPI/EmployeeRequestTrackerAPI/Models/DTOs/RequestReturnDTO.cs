namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RequestReturnDTO
    {
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }

    }
}