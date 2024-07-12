using System.ComponentModel.DataAnnotations;

namespace ATMApplication.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
