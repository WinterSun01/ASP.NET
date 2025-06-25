using OnlineStore.Data;
using OnlineStore.Models.Domain;

namespace OnlineStore.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByEmailAndPassword(string email, string passwordHash)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == passwordHash);
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
