using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        IMessage SendMessage(String senderId, String receiverId, string text);
        void EditMessage(String messageId, string newText);
        void DeleteMessage(String messageId);
        IReadOnlyCollection<IMessage> GetAllMessages(String senderId, String receiverId); // add pagination
    }
}