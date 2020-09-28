using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Message
    {
        public int MessageId { get; }
        public int MessageCreatorId { get; }
        public IReadOnlyCollection<int> ReceiversUserID { get; }
        
        public string Text {
            set {
                Text = value ?? throw new ArgumentNullException(nameof(value));
                TimeLastModified = Optional<DateTime>.Some(NowTime());
            }
        }

        public bool WasEdited => TimeLastModified.HasValue;

        public DateTime TimePost { get; }

        public Optional<DateTime> TimeLastModified { get; private set; }
        
        public Message(string text, int messageId, int creatorId, IReadOnlyCollection<int> receiversUserId) {
            MessageId = messageId;
            MessageCreatorId = creatorId;
            Text = text;
            TimePost = NowTime();
            TimeLastModified = Optional<DateTime>.None();
            ReceiversUserID = receiversUserId;
        }
        
        private static DateTime NowTime() {
            return DateTime.Now;
        }
    }
}