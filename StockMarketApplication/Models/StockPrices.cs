using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockMarketApplication.Models
{
    public class StockPrices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // For IDENTITY column
        public int PriceId { get; set; }

        [ForeignKey("Stock")] // Reference to the Stocks table
        public int StockId { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Matches SQL DECIMAL(18,2)
        public decimal PriceValue { get; set; }

        public DateTime PriceDate { get; set; }

        // Navigation property for the foreign key relationship
        public virtual Stocks Stock { get; set; }
    }
}
