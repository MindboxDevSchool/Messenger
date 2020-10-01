using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Message;
using Domain.User;

namespace Application.Services.MessageServices
{
    public interface IMessageService
    {
        public Guid Post(Guid chatId, MessageContent messageContent);
        public IEnumerable<IMessage> Read(Guid chatId);
        public void Edit(Guid messageId, MessageContent newContent);
        public void Delete(Guid messageId);
    }
}