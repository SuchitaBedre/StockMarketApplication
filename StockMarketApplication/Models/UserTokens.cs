namespace StockMarketApplication.Models
{
    public class UserTokens
    {
        public int TokenId { get; set; }

        // Foreign Key referencing Users table
        public int UserId { get; set; }

        // Token string
        public string Token { get; set; }

        // Expiry date and time
        public DateTime Expiry { get; set; }

        // Indicates if the token is revoked
        public bool IsRevoked { get; set; } = false; // Default value set to false
    }
}
