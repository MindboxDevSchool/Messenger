using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public interface IChat : IEntity
    {
        public IReadOnlyCollection<IUser> Members { get; }
        public IReadOnlyCollection<IMessage> Messages { get; }
    }
}