namespace StockMarketApplication.Service;
using StockMarketApplication.Models;

    public class UserServices : UserInterface
    {

        private readonly StockmarketContext _context;
        public UserServices(StockmarketContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers() =>
            _context.Users.ToList();

        public User GetUserById(int id) =>
            _context.Users.FirstOrDefault(s => s.UserId == id);

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);  // Mark the student as modified
            _context.SaveChanges();  // Commit the changes to the database
        }

        public void DeleteUser(int id)
        {
            var student = GetUserById(id);
            if (student != null)
            {
                _context.Users.Remove(student);
                _context.SaveChanges();
            }
        }

    }

