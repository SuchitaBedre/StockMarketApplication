using StockMarketApplication.Models;

namespace StockMarketApplication.Service
{
    public interface UserInterface
    {
            IEnumerable<User> GetAllUsers();
             User GetUserById(int id);
            void CreateUser(User user);
            void UpdateUser(User user);
            void DeleteUser(int id);

        }
    }

