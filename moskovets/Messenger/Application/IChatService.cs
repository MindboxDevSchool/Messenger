using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        IMessage SendMessage(String senderId, String receiverId, string text);
        void EditMessage(String messageId, String editorId, string newText);
        void DeleteMessage(String messageId, String editorId);
        IReadOnlyCollection<IMessage> GetAllMessages(String senderId, String receiverId); // add pagination
        bool CanEditorAccessMessage(string messageId, string editorId);
    }
}