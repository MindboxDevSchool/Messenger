using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Message;
using Domain.Repository;

namespace MessengerTests.TestRepositories
{
    public class TestMessageRepository : IRepository<IMessage>
    {
        public TestMessageRepository(Dictionary<Guid, IMessage> messages)
            => Messages = messages;

        private Dictionary<Guid, IMessage> Messages { get; }
        
        public void Add(IMessage message)
            => Messages.Add(message.Id, message);

        public IMessage Find(Guid id)
            => Messages[id];

        public void Update(IMessage message)
            => Messages[message.Id] = message;

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}