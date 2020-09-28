using System;
using System.Collections.Generic;
using System.Xml.Schema;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChanelService
    {
        IChanel CreateChanel(String creatorId, string name);
        void AddMember(String memberId, String channelId);
        void RemoveMember(String memberId, String channelId);
        IReadOnlyCollection<IUser> GetMembers(String channelId);

        IMessage SendMessage(String senderId, String channelId, string text);
        void EditMessage(String messageId, String editorId, string newText);
        void DeleteMessage(String messageId, String editorId);
        IReadOnlyCollection<IMessage> GetAllMessages(String memberId, String channelId); // add pagination
        bool CanEditorAccessMessage(string messageId, string editorId);
    }
}