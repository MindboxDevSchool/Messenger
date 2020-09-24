using System;

namespace Messenger.Exceptions
{
    public class ChatMemberNotFoundException : Exception
    {
        public ChatMemberNotFoundException(Guid memberId): base($"Chat member with Id [{memberId}] not found.")
        {
            
        }

        public ChatMemberNotFoundException(string message): base(message)
        {
            
        }
    }
}