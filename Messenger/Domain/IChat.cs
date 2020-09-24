using System;

namespace Messenger.Domain
{
    public interface IChat
    {
        Guid ChatId { get; }
        User ChatCreator { get; }
        DateTime CreatedDate { get; }
        String ChatName { get; }

        Guid SendMessage(User user, String messageText);
        Message GetMessage(Guid messageId);
        void EditMessage(User user, Message message, String newMessageText);
        void DeleteMessage(User user, Message message);
        // void ResendMessage(User startUser, User endUser, Message message, String comment);

    }
}