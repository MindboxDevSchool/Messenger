using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Message(string text, Guid senderId, Guid groupId)
        {
            Id = Guid.NewGuid();
            Text = text;
            SenderId = senderId;
        }

        public Guid Id { get;  }
        public Guid SenderId { get; }
        public string Text { get; set; }
        public Guid GroupId { get;  }
    }
}