using System;

namespace Crane.Domain
{
    public class Message : IMessage
    {
        private static int _nextId = 0;
        
        public DateTime TimeSent { get; }
        public ISender Sender { get; }
        public IChat Chat { get; }
        public string Body { get; }
        public int Id { get; }

        public Message(ISender sender, IChat chat, string body)
        {
            Sender = sender;
            Chat = chat;
            Body = body;
            Id = _nextId++;
        }
    }
}
