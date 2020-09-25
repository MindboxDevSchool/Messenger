using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get; }
        string Content { get; set; }
        DateTime CreatedTime { get; }
        DateTime UpdatedTime { get; set; }
        Guid UserId { get; }
        Guid ChatId { get; }
        void UpdateMessageContent(string content);
    }
}