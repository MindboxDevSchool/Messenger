using System;

namespace Messenger.Domain
{
    public interface IChat
    {
        Guid ChatId { get; }
        IUser ChatCreator { get; }
        DateTime CreatedDate { get; }
        String ChatName { get; }

        Guid SendMessage(IUser user, String messageText);
        IMessage GetMessage(Guid messageId);
        void EditMessage(IUser user, IMessage message, String newMessageText);
        void DeleteMessage(IUser user, IMessage message);

    }
}