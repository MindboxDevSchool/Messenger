using System;

namespace Messenger.Domain
{
    public class ChatNotFoundException: Exception
    {
        public ChatNotFoundException(Guid chatId): base($"Chat with Id [{chatId}] not found.")
        {
            
        }

        public ChatNotFoundException(string message): base(message)
        {
            
        }
    }
}