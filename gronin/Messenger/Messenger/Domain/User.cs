using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Name { get; set; }
        
    }
}