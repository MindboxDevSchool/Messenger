using System;

namespace Messenger.Domain
{
    public interface IMessage : IEntityWithId
    {
        public String Id { get; }
        public string Text { get; set; }
        public ISender Sender { get; }
        public IReceiver Receiver { get; }
        public DateTime SentAt { get; }
    }
}