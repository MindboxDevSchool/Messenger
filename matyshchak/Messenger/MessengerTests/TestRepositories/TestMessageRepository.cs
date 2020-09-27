using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.Repositories;

namespace MessengerTests.TestRepositories
{
    public class TestMessageRepository : IMessageRepository
    {
        public TestMessageRepository(Dictionary<Guid, IMessage> messages) => Messages = messages;

        private Dictionary<Guid, IMessage> Messages { get; }
        
        public void AddMessage(IMessage message) => Messages.Add(message.Id, message);

        public IMessage GetMessage(Guid id) => Messages[id];

        public void UpdateMessage(IMessage message) => Messages[message.Id] = message;

        public void DeleteMessage(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}