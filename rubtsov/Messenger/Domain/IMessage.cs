using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        public string MessageContent { get; }
        public DateTime CreationDate { get; }
    }
}