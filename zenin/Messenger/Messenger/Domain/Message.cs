using System;

namespace Messenger
{
    public class Message
    {
        public Guid CreatedBy { get; }
        public DateTime CreatedAt { get; }
        public string Text { get; set; }

        public Message(User user, string text)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (text == "") throw new ArgumentNullException(nameof(text));
            CreatedAt = DateTime.Now;
            CreatedBy = user.Id;
            Text = text;
        }
    }
}