using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Create(User user);
        bool Delete(int id);
    }
}
