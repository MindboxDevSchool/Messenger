using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<IChat> Chats { get; set; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Messages = new List<Message>();
            Chats = new List<IChat>();
        }
    }
}