using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IGroupService
    {
        void SendMessage(IMessage newMessage);
        void DeleteMessage(IMessage message);
        void UpdateMessage(IMessage oldMessage, string newText);
        
        ICollection<IUserInGroup> Users { get; }
        ICollection<IMessage> Messages { get; }
        
        ICollection<IMessage> GetMessagesToShow(int amount);
    }
}