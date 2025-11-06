using StockMarketApplication.Models;

namespace StockMarketApplication.Service
{
    public interface StockInterface
    {

        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void CreateStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(int id);
    }
}
