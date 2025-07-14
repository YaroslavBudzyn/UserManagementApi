using Domain.Entities;
using Infrastructure.IRepositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private static int _idCounter = 1;

        public IEnumerable<User> GetAll() => _users;

        public User Add(User user)
        {
            user.Id = _idCounter++;
            _users.Add(user);
            return user;
        }

        public bool Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            _users.Remove(user);
            return true;
        }
    }
}
