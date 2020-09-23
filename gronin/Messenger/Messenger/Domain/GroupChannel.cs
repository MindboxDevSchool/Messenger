using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Messenger.Domain
{
    public class GroupChannel:Group,IGroup
    {
        public GroupChannel(Guid id, ICollection<IUserInGroup> users, ICollection<IMessage> messages ) 
            : base(id,users, messages)
        {
        }
        
        public override void NewMessage(IUserInGroup sender, IMessage newMessage)
        {
            if (sender.IsOwner)
            {
                Messages.Add(newMessage);
            }
        }

        public override void DeleteMessage(IUserInGroup caller, IMessage messageToDelete)
        {
            if (caller.IsOwner)
            {
                Messages.Remove(messageToDelete);
            }
            else
            {
                throw new ConstraintException("Only owner can delete messages");
            }
        }

        public override void UpdateMessage(IUserInGroup caller, IMessage OldMessage, string newText)
        {
            if (caller.IsOwner)
            {
                Messages.Single(msg => msg == OldMessage).Text = newText;
            }
            else
            {
                throw new ConstraintException("Only authors can edit messages");
            }
        }
    }
}