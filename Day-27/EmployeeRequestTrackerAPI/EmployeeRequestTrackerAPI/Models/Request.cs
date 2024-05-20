using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string? RequestMessage { get; set; }
        public string? RequestStatus { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? CloseDate { get; set; } = null;

        public int RaisedByEmployeeId { get; set; }
        [ForeignKey("RaisedByEmployeeId")]
        public Employee? RaisedByEmployee { get; set; }
    }
}