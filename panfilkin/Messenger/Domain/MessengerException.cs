using System;

namespace Messenger.Domain
{
    public abstract class MessengerException : Exception
    {
        protected MessengerException(string message) : base(message)
        {
        }
    }

    public class NoPermissionException : MessengerException
    {
        public NoPermissionException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : MessengerException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}