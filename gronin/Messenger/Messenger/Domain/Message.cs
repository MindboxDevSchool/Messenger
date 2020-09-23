using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Message(string text)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get;  }
        public string SenderId { get; }
        public string Text { get; set; }

        public virtual IUserInGroup Sender { get; }
    }
}