using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Message()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }

        public virtual User Sender { get; set; }
    }
}