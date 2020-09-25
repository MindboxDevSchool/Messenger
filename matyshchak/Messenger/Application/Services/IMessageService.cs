using System;
using Domain;
using Domain.User;

namespace Application.Services
{
    public interface IMessageService
    {
        public Guid AddMessage(Guid authorId, Guid chatId, string content);
        public IMessage GetMessage(Guid id);
        public void UpdateMessage(Guid id, string content);
        public void DeleteMessage(Guid id);
    }
}