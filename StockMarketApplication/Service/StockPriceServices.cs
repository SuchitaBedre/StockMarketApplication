using StockMarketApplication.Models;

namespace StockMarketApplication.Service;

    public class StockPriceServices : StockPriceInterface
{

    private readonly StockmarketContext _context;
    public StockPriceServices(StockmarketContext context)
    {
        _context = context;
    }

    public IEnumerable<StockPrice> GetAllStockPrice() =>
        _context.StockPrices.ToList();

    public StockPrice GetStockPriceById(int id) =>
        _context.StockPrices.FirstOrDefault(s => s.PriceId == id);

    public void CreateStockPrice(StockPrice stockPrice)
    {
        _context.StockPrices.Add(stockPrice);
        _context.SaveChanges();
    }


    public void UpdateStockPrice(StockPrice stockPrice)
    {
        _context.StockPrices.Update(stockPrice);  // Mark the student as modified
        _context.SaveChanges();  // Commit the changes to the database
    }

    public void DeleteStockPrice(int id)
    {
        var stockPrice = GetStockPriceById(id);
        if (stockPrice != null)
        {
            _context.StockPrices.Remove(stockPrice);
            _context.SaveChanges();
        }
    }
}


