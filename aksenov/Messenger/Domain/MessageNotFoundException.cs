using System;

namespace Messenger.Domain
{
    public class MessageNotFoundException: Exception
    {
        public MessageNotFoundException(Guid messageId): base($"Message with Id [{messageId}] not found.")
        {
            
        }

        public MessageNotFoundException(string message) : base(message)
        {
            
        }
    }
}