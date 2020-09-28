using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get;  }
        Guid SenderId { get; }
        string Text { get; set; }
        Guid GroupId { get; }
    }
}