using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Group
    {
        public Group(IReadOnlyList<IUserInGroup> users,IReadOnlyList<IMessage> messages, string name)
        {
            Id = Guid.NewGuid();
            UsersInGroup = users;
            Messages = messages;
            Name = name;
        }

        //private IUsersInGroupRepository _usersInGroupRepository;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  IReadOnlyList<IMessage> Messages { get; }
        public  IReadOnlyList<IUserInGroup> UsersInGroup { get; }

        public IEnumerable<User> GetAdmin()
        {
            return UsersInGroup.Where(i => i.IsAdmin).Select(i => i.User);
        }

        public User GetOwner()
        {
            return UsersInGroup.Where(i => i.IsOwner).Select(i => i.User).FirstOrDefault();
        }

        public int GetMembersCount()
        {
            return UsersInGroup.Select(i => i.User).Count();
        } 
    }
}