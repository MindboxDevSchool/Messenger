using System;

namespace Messenger.Domain
{
    public class Message
    {
        public int MessageCreatorId { get; }
        
        public string Text {
            set {
                Text = value ?? throw new ArgumentNullException(nameof(value));
                TimeLastModified = Optional<DateTime>.Some(NowTime());
            }
        }

        public bool WasEdited => TimeLastModified.HasValue;

        public DateTime TimePost { get; }
        
        public Optional<DateTime> TimeLastModified { get; private set; }

        public int MessageId { get; }
        
        public Message(string text, int messageId, int userId) {
            MessageCreatorId = userId;
            Text = text;
            TimePost = NowTime();
            TimeLastModified = Optional<DateTime>.None();
            MessageId = messageId;
        }
        
        private static DateTime NowTime() {
            return DateTime.Now;
        }
    }
}