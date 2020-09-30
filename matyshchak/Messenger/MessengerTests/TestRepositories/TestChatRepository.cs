using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Repository;

namespace MessengerTests.TestRepositories
{
    public class TestChatRepository : IRepository<IChat>
    {
        public TestChatRepository(IDictionary<Guid, IChat> chats) => Chats = chats;

        private IDictionary<Guid, IChat> Chats { get; }

        public void Add(IChat item) => Chats.Add(item.Id, item);
        
        public IChat Find(Guid id) => Chats[id];

        public void Update(IChat chat)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}