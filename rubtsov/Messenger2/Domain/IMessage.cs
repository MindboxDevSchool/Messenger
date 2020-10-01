using System;

namespace Messenger2.Domain
{
    public interface IMessage
    {
        public string MessageContent { get; }
        public DateTime CreationDate { get; }
    }
}