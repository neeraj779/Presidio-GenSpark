using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMApplication.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public TransactionTypeEnum.TransactionType Type { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
