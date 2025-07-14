using Domain.Entities;

namespace Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Add(User user);
        bool Delete(int id);
    }
}
