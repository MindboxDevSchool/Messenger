using System;
using Domain.User;

namespace Domain.Repositories
{
    public interface IMessageRepository
    {
        public void AddMessage(IMessage message);
        public IMessage GetMessage(Guid id);
        public void UpdateMessage(IMessage message);
        public void DeleteMessage(Guid id);
    }
}