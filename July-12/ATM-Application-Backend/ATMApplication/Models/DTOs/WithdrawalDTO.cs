using System.ComponentModel.DataAnnotations;

namespace ATMApplication.Models.DTOs
{
    public class WithdrawalDTO
    {
        public AuthenticationDTO AuthDetails { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
