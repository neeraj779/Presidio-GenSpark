using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ATMApplication.Models.DTOs
{
    public class ReturnTransactionDTO
    {
        public Guid Id { get; set; }
        public string AccountNo { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}
