using StockMarketApplication.Models;

namespace StockMarketApplication.Service
{
    public interface StockPriceInterface
    {

        IEnumerable<StockPrice> GetAllStockPrice();
        StockPrice GetStockPriceById(int id);
        void CreateStockPrice(StockPrice stock);
        void UpdateStockPrice(StockPrice stock);
        void DeleteStockPrice(int id);
    }
}
