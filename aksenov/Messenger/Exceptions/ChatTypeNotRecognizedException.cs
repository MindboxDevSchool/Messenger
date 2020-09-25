using System;
using Messenger.Domain;

namespace Messenger.Exceptions
{
    public class ChatTypeNotRecognizedException : Exception
    {
        public ChatTypeNotRecognizedException(ChatType chatType): 
            base($"The chat type \"{chatType}\" was not recognized.")
        {
            
        }

        public ChatTypeNotRecognizedException(string message): base(message)
        {
            
        }
    }
}