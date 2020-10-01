using System;

namespace Crane.Domain
{
    public class Message : IMessage
    {
        public DateTime TimeSent { get; }
        public IUser Sender { get; }
        public IChat Chat { get; }
        public string Body { get; set; }
        public int Id { get; }

        public static Message Parse(string representation)
        {
            throw new NotImplementedException();
        }
        
        public static string Render(Message message)
        {
            throw new NotImplementedException();
        }

        public Message(int id, DateTime timeSent, IUser sender, IChat chat, string body)
        {
            Id = id;
            TimeSent = timeSent;
            Sender = sender ?? throw new ArgumentNullException(nameof(sender));
            Chat = chat ?? throw new ArgumentNullException(nameof(chat));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }
    }
}
