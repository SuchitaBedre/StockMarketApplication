namespace StockMarketApplication.Service;

using global::StockMarketApplication.Models;


public class WatchListServices : WatchListInterface
{

    private readonly StockmarketContext _context;
    public WatchListServices(StockmarketContext context)
    {
        _context = context;
    }

    public IEnumerable<Watchlist> GetAllWatchlist() =>
        _context.Watchlists.ToList();

    public Watchlist GetWatchlistById(int id) =>
        _context.Watchlists.FirstOrDefault(s => s.WatchlistId == id);

    public void CreateWatchlist(Watchlist watchlist)
    {
        _context.Watchlists.Add(watchlist);
        _context.SaveChanges();
    }


    public void UpdateWatchlist(Watchlist watchlist)
    {
        _context.Watchlists.Update(watchlist);  // Mark the student as modified
        _context.SaveChanges();  // Commit the changes to the database
    }

    public void DeleteWatchlist(int id)
    {
        var watchlist = GetWatchlistById(id);
        if (watchlist != null)
        {
            _context.Watchlists.Remove(watchlist);
            _context.SaveChanges();
        }
    }

}


