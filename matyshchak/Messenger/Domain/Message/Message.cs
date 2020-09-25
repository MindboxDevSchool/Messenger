using System;

namespace Domain
{
    public class Message : IMessage
    {
        public Message(Guid id, Guid authorId, Guid chatId, DateTime timePosted, string content)
        {
            Id = id;
            ChatId = chatId;
            AuthorId = authorId;
            TimePosted = timePosted;
            Content = content;
        }
        
        public Guid Id { get; }
        public Guid ChatId { get; }
        public Guid AuthorId { get; }
        public DateTime TimePosted { get; }
        public string Content { get; }
    }
}