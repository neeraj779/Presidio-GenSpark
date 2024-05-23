using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "User id cannot be empty")]
        [Range(100, 999, ErrorMessage = "Invalid entry for employee ID")]
        public int UserId { get; set; }


        [MinLength(6, ErrorMessage = "Password has to be minmum 6 chars long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; } = string.Empty;
    }
}