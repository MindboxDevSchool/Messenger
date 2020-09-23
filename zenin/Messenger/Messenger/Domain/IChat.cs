using System;
using System.Collections.Immutable;

namespace Messenger.Domain
{
    public interface IChat
    {
        Guid Id { get; }
        string Name { get; }
        User CreatedBy { get; }
        DateTime CreatedAt { get; }

        Guid SendMessage(User user, string text);
        Message GetMessage(Guid messageId);
        void EditMessage(User user, Message message, string newText);
        void DeleteMessage(User user, Message message);
    }
}