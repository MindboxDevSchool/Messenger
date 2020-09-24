using System;
using System.Dynamic;

namespace Messenger.Domain
{
    public class Message
    {
        public Guid Id { get; }
        
        public Guid UserId { get; }
        
        public string Content { get; private set; }

        public DateTime DepartureDate { get; }

        public Message(Guid id, Guid userId, string content, DateTime departureDate)
        {
            UserId = userId;
            Content = content;
            DepartureDate = departureDate;
            Id = id;
        }

        public static Message Create(Guid userId, string content, DateTime departureDate)
        {
            return new Message(Guid.NewGuid(), userId, content, departureDate);
        }

        public void ChangeContent(string newContent)
        {
            Content = newContent;
        }
    }
}