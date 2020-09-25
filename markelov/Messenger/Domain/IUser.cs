using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        string Username { get; }
        string Password { get; }
        IEnumerable<Message> Messages { get; }
        IEnumerable<IChat> Chats { get; set; }
    }
}