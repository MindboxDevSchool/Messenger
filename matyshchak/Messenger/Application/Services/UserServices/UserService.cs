using System;
using Domain.Repository;
using Domain.User;

namespace Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<IUser> _repository;

        public UserService(IRepository<IUser> repository) => 
            _repository = repository;

        public Guid Register(UserName userName, PhoneNumber phoneNumber)
        {
            var id = Guid.NewGuid();
            var user = User.Create(id, userName, phoneNumber);
            _repository.Add(user);
            return id;
        }

        public IUser GetUser(Guid id) =>
            _repository.Find(id);
    }
}