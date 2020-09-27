using System;
using Domain.Chats;

namespace Domain.Message
{
    public class Message : IMessage
    {
        public Message(Guid id, Guid authorId, IChat chat, DateTime timePosted, MessageContent content)
        {
            Id = id;
            AuthorId = authorId;
            Chat = chat;
            TimePosted = timePosted;
            Content = content;
        }

        public Guid Id { get; }
        public Guid AuthorId { get; }
        public IChat Chat { get; }
        public DateTime TimePosted { get; }
        public MessageContent Content { get; }
        
        public IMessage Edit(MessageContent newContent)
        {
            return new Message(Id, AuthorId, Chat, TimePosted, newContent);
        }
    }
}