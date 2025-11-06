namespace StockMarketApplication.Service;

using global::StockMarketApplication.Models;

public class StockServices : StockInterface
{

    private readonly StockmarketContext _context;
    public StockServices(StockmarketContext context)
    {
        _context = context;
    }

    public IEnumerable<Stock> GetAllStocks() =>
        _context.Stocks.ToList();

    public Stock GetStockById(int id) =>
        _context.Stocks.FirstOrDefault(s => s.StockId == id);

    public void CreateStock(Stock stock)
    {
        _context.Stocks.Add(stock);
        _context.SaveChanges();
    }


    public void UpdateStock(Stock stock)
    {
        _context.Stocks.Update(stock);  // Mark the student as modified
        _context.SaveChanges();  // Commit the changes to the database
    }

    public void DeleteStock(int id)
    {
        var stock = GetStockById(id);
        if (stock != null)
        {
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
        }
    }

}

