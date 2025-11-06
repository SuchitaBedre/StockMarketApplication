using StockMarketApplication.Models;

namespace StockMarketApplication.Service
{
    public interface WatchListInterface
    {


        IEnumerable<Watchlist> GetAllWatchlist();
        Watchlist GetWatchlistById(int id);
        void CreateWatchlist(Watchlist watchlist);
        void UpdateWatchlist(Watchlist watchlist);
        void DeleteWatchlist(int id);
    }
}
