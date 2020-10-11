using System;

namespace Messenger.Domain
{
    public interface IMessage : IEntityWithId
    {
        string Id { get; }
        string Text { get; set; }
        ISender Sender { get; }
        IReceiver Receiver { get; }
        DateTime SentAt { get; }
    }
}