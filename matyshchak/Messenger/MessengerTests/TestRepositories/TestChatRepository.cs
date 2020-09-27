using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Chats;
using Domain.Repositories;

namespace MessengerTests.TestRepositories
{
    public class TestChatRepository : IChatRepository
    {
        public TestChatRepository(IDictionary<Guid, IChat> chats) => Chats = chats;

        private IDictionary<Guid, IChat> Chats { get; }

        public void AddChat(IChat chat) => Chats[chat.Id] = chat;

        public IChat GetChat(Guid id) => Chats[id];

        public void UpdateChat(IChat chat)
        {
            throw new NotImplementedException();
        }

        public void DeleteChat(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}