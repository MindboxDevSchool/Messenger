using System;

namespace Messenger
{
    public interface IChat
    {
        Guid Id { get; }
        string Name { get; }
        User CreatedBy { get; }
        DateTime CreatedAt { get; }

        void SendMessage(User user, string text);
        void EditMessage(User user, Message message, string newText);
        void DeleteMessage(User user, Message message);

    }
}