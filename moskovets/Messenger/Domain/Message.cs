using System;

namespace Messenger.Domain
{
    public class Message : IMessage
    {
        public Message(String id, string text, ISender sender, IReceiver receiver, DateTime sentAt)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            if (text == "")
                throw new EmptyTextException();
            Sender = sender ?? throw new ArgumentNullException(nameof(sender));
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            SentAt = sentAt;
        }
        public String Id { get; }
        public string Text { get; set; }
        public ISender Sender { get; }
        public IReceiver Receiver { get; }
        public DateTime SentAt { get; }
    }
}