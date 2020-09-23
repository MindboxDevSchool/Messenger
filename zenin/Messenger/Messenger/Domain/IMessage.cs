using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get; }
        Guid CreatedBy { get; }
        DateTime CreatedAt { get; }
        string Text { get; set; }
    }
}