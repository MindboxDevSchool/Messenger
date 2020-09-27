using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Domain.User;

namespace MessengerTests.TestRepositories
{
    public class TestUserRepository : IUserRepository
    {
        public TestUserRepository(Dictionary<Guid, IUser> users) => Users = users;

        private Dictionary<Guid, IUser> Users { get; }
        public void AddUser(IUser user) => Users[user.Id] = user;

        public IUser GetUser(Guid id) => Users[id];
    }
}