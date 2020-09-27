using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Repositories;
using Domain.User;

namespace Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Guid Register(UserName userName, PhoneNumber phoneNumber)
        {
            var id = new Guid();
            var chats = new List<IChat>();
            var user = new User(id, userName, phoneNumber, chats);
            _repository.AddUser(user);
            return id;
        }

        public IUser GetUser(Guid id)
        {
            return _repository.GetUser(id);
        }
    }
}