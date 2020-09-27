using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public interface IChat : IEntity
    {
        public IEnumerable<IUser> Members { get; }
        public IEnumerable<IMessage> Messages { get; }
    }
}