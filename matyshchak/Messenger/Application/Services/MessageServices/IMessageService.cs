using System;
using System.Collections.Generic;
using Domain.Message;

namespace Application.Services.MessageServices
{
    public interface IMessageService
    {
        public Guid AddMessage(Guid chatId, string content);
        public IMessage GetMessage(Guid messageId);
        public IReadOnlyList<IMessage> GetLastMessages(Guid chatId, int numberOfMessages);
        public void EditMessage(Guid messageId, string newContent);
        public void DeleteMessage(Guid messageId);
    }
}