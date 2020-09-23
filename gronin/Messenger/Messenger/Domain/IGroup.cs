using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroup
    {
        Guid Id { get; set; }
        string Name { get; set; }
        ICollection<IMessage> Messages { get; }
        ICollection<IUserInGroup> UsersInGroup { get; }
        IEnumerable<IUser> GetAdmin();
        IUser GetOwner();

        void NewMessage(IUserInGroup sender,IMessage newMessage);

        void DeleteMessage(IUserInGroup caller, IMessage messageToDelete);
        
        void UpdateMessage(IUserInGroup author, IMessage OldMessage, string newText);
    }
}