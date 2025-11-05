using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StockMarketApplication.Models;
namespace StockMarketApplication.Models
{
    public class UserHoldings
    {
        [Key]
        public int HoldingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Stocks Stock { get; set; }
    }


}
