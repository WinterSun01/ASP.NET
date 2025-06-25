using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IUserService
    {
        User? GetById(int id);
        User? GetByEmailAndPassword(string email, string passwordHash);
        void Register(User user);
    }
}
