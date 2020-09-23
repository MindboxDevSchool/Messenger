using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Message(string text, Guid senderId)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get;  }
        public Guid SenderId { get; }
        public string Text { get; set; }
        
    }
}