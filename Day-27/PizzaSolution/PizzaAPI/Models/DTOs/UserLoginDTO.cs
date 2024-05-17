namespace PizzaAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
