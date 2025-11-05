namespace StockMarketApplication.Models
{
    public class Stocks
    {

        public int StockId { get; set; }

        // Unique and non-nullable
        public string TickerSymbol { get; set; } = string.Empty;

        // Nullable by default
        public string? CompanyName { get; set; }

        // Nullable by default
        public string? Sector { get; set; }

        // Nullable by default
        public string? Exchange { get; set; }
    }

}

