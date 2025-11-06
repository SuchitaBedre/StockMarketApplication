using StockMarketApplication.Models;

namespace StockMarketApplication.Service
{
    public interface UserHoldingInterface
    {

        IEnumerable<UserHolding> GetAllUserHolding();
        UserHolding GetUserHoldingById(int id);
        void CreateUserHolding(UserHolding userHolding);
        void UpdateUserHolding(UserHolding userHolding);
        void DeleteUserHolding(int id);

    }
}
