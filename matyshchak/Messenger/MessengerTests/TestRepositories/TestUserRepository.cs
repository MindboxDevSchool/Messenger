using System;
using System.Collections.Generic;
using Domain.Repository;
using Domain.User;

namespace MessengerTests.TestRepositories
{
    public class TestUserRepository : IRepository<IUser>
    {
        public TestUserRepository(Dictionary<Guid, IUser> users) => Users = users;
        private Dictionary<Guid, IUser> Users { get; }
        public void Add(IUser user) => Users[user.Id] = user;
        public void Update(IUser item)
            => Users[item.Id] = item;
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public IUser Find(Guid id) => Users[id];
    }
}