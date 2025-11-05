using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockMarketApplication.Models
{
    public class WatchList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WatchlistId { get; set; } // Primary Key with Identity

        [ForeignKey("User")]
        public int UserId { get; set; } // Foreign Key referencing Users table

        [ForeignKey("Stock")]
        public int StockId { get; set; } // Foreign Key referencing Stocks table

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AddedDate { get; set; } = DateTime.Now; // Default to GETDATE()

        // Navigation properties (optional, for relationships)
        public virtual User User { get; set; }
        public virtual Stocks Stock { get; set; }
    }
}
