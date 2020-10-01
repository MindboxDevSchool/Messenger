using System.Collections.Generic;
using Domain.Chats;

namespace Domain.User
{
    public interface IUser : IEntity
    {
        public UserName Name { get; }
        public PhoneNumber PhoneNumber { get; }
        public IEnumerable<IChat> Chats { get; }
    }
}