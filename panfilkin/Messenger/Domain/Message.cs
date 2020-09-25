using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Guid Id { get; }
        public IUser Sender { get; }
        public IChat Chat { get; }
        public string Text { get; set; }
        public DateTime DateTime { get; }


        public Message(IUser sender, string text, IChat chat, Guid id)
        {
            Sender = sender ?? throw new ArgumentNullException(nameof(sender));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Chat = chat ?? throw new ArgumentNullException(nameof(chat));
            Id = id;
            DateTime = DateTime.Now;
        }
    }
}