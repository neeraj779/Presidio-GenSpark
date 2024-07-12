using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMApplication.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("Id")]
        public Customer customer { get; set; }
        public string Pin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
