using System;

namespace Messenger2.Domain
{
    public class Message : IMessage
    {
        public string MessageContent { get; }
        public DateTime CreationDate { get; }
        public readonly Guid Author;

        public Message(Guid authorId, string message)
        {
            Author = authorId;
            MessageContent = message;
            CreationDate = DateTime.Now;
        }
    }
}