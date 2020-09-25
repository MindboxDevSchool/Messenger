using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Guid Id { get; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; }
        public DateTime UpdatedTime { get; set; }
        public Guid UserId { get; }
        public Guid ChatId { get; }

        public Message(string content, Guid userId, Guid chatId)
        {
            Id = Guid.NewGuid(); 
            Content = content;
            CreatedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
            UserId = userId;
            ChatId = chatId;
        }

        public void UpdateMessageContent(string content)
        {
            this.Content = content;
            this.UpdatedTime = DateTime.Now;
        }
    }
}