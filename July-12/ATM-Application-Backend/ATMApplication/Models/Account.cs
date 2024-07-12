using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMApplication.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; } 
        public string AccountNo { get; set; }
        public double Balance { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("Id")]
        public Customer customer { get; set; }
    }
}
