using Application.Interfaces;
using Domain.Entities;
using Domain.Validators;
using Infrastructure.IRepositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAll() => _repository.GetAll();

        public User Create(User user)
        {
            UserValidator.Validate(user);
            return _repository.Add(user);
        }

        public bool Delete(int id) => _repository.Delete(id);
    }
}
