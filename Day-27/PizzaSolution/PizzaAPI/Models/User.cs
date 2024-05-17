namespace PizzaAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
