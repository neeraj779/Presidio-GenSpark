namespace SimpleBankingModelLibrary
{
    /// <summary>
    /// Represents a user in the banking system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the balance of the user's account.
        /// </summary>
        public double Balance { get; set; }
    }

    /// <summary>
    /// Represents a transaction between two users in the banking system.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the username of the sender.
        /// </summary>
        public string SenderUsername { get; set; }

        /// <summary>
        /// Gets or sets the username of the receiver.
        /// </summary>
        public string ReceiverUsername { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the transaction.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
