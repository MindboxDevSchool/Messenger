using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Messenger.Domain
{
    public class Group : IGroup
    {
        public Group(Guid id,ICollection<IUserInGroup> users,ICollection<IMessage> messages)
        {
            Id = id;
            UsersInGroup = users;
            Messages = messages;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  ICollection<IMessage> Messages { get; }
        public  ICollection<IUserInGroup> UsersInGroup { get; }

        public IEnumerable<IUser> GetAdmin()
        {
            return UsersInGroup.Where(i => i.IsAdmin).Select(i => i.User);
        }

        public IUser GetOwner()
        {
            return UsersInGroup.Where(i => i.IsOwner).Select(i => i.User).FirstOrDefault();
        }

        public virtual void NewMessage(IUserInGroup sender, IMessage newMessage)
        {
            Messages.Add(newMessage);
        }

        public virtual void DeleteMessage(IUserInGroup caller, IMessage messageToDelete)
        {
            if (caller.UserId == messageToDelete.SenderId || caller.IsAdmin)
            {
                Messages.Remove(messageToDelete);
            }
            else
            {
                throw new ConstraintException("Only admins and authors can delete messages");
            }
        }

        public virtual void UpdateMessage(IUserInGroup caller, IMessage OldMessage, string newText)
        {
            if (caller.UserId == OldMessage.SenderId)
            {
                Messages.Single(msg => msg == OldMessage).Text = newText;
            }
            else
            {
                throw new ConstraintException("Only authors can edit messages");
            }
        }

        public int GetMembersCount()
        {
            return UsersInGroup.Select(i => i.User).Count();
        } 
    }
}