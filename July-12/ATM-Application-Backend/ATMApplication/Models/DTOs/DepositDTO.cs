using System.ComponentModel.DataAnnotations;

namespace ATMApplication.Models.DTOs
{
    public class DepositDTO
    {
        [Required]
        public AuthenticationDTO authDetails { get; set;  }
        [Required]
        public int amount { get; set; }
    }
}