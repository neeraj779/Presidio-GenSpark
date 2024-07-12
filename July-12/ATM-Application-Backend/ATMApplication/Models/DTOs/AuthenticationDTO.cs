using System.ComponentModel.DataAnnotations;

namespace ATMApplication.Models.DTOs
{
    public class AuthenticationDTO
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Pin { get; set; }

    }
}
