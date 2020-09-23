using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public User()
        {
            Id = Guid.NewGuid();
            UserGroups = new List<UserInGroup>();
        }

        
        public Guid Id { get; }
        public Guid Name { get; }
        public virtual ICollection<UserInGroup> UserGroups { get; }
    }
}