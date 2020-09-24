using System;

namespace Messenger.Exceptions
{
    public class MemberLimitExceededException : Exception
    {
        public MemberLimitExceededException(int memberLimit): 
            base($"The limit for the number of chat members ({memberLimit}) has been exceeded.")
        {
            
        }

        public MemberLimitExceededException(string message): base(message)
        {
            
        }
    }
}