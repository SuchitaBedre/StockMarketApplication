using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Xml;

namespace StockMarketApplication.Models
{
    public class User
    {

        private int UserId { get; set; }

        private string? Username { get; set; }
        private string? Email { get; set; }
        private string? PasswordHash { get; set; }
        private string? Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
