namespace StockMarketApplication.Service;
using global::StockMarketApplication.Models;


public class UserHoldingServices : UserHoldingInterface
{

    private readonly StockmarketContext _context;
    public UserHoldingServices(StockmarketContext context)
    {
        _context = context;
    }

    public IEnumerable<UserHolding> GetAllUserHolding() =>
        _context.UserHoldings.ToList();

    public UserHolding GetUserHoldingById(int id) =>
        _context.UserHoldings.FirstOrDefault(s => s.HoldingId == id);

    public void CreateUserHolding(UserHolding userHolding)
    {
        _context.UserHoldings.Add(userHolding);
        _context.SaveChanges();
    }


    public void UpdateUserHolding(UserHolding userHolding)
    {
        _context.UserHoldings.Update(userHolding);  // Mark the student as modified
        _context.SaveChanges();  // Commit the changes to the database
    }

    public void DeleteUserHolding(int id)
    {
        var userHolding = GetUserHoldingById(id);
        if (userHolding != null)
        {
            _context.UserHoldings.Remove(userHolding);
            _context.SaveChanges();
        }
    }

}



