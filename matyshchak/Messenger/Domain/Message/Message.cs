using System;
using Domain.Chats;
using Domain.User;

namespace Domain.Message
{
    public class Message : IMessage
    {
        public static IMessage Create(Guid id, IUser author, IChat chat, MessageContent content) => 
            new Message(id, author, chat, content, DateTime.Now);

        private Message(Guid id, IUser author, IChat chat, MessageContent content, DateTime timePosted)
        {
            Id = id;
            Author = author;
            Chat = chat;
            Content = content;
            TimePosted = timePosted;
        }
        
        public Guid Id { get; }
        public IUser Author { get; }
        public IChat Chat { get; }
        public MessageContent Content { get; }
        public DateTime TimePosted { get; }
        public IMessage Edit(MessageContent newContent)
        {
            throw new NotImplementedException();
        }
    }
}