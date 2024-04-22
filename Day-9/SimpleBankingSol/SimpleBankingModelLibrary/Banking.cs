namespace SimpleBankingModelLibrary
{
    /// <summary>
    /// Represents a user in the banking system.
    /// </summary>
    public class User
    {
        public string? Username { get; set; }
        public double Balance { get; set; }
        public string? Password { get; set; }
    }

    /// <summary>
    /// Represents a transaction between two users in the banking system.
    /// </summary>
    public class Transaction
    {
        public string? SenderUsername { get; set; }
        public string? ReceiverUsername { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
