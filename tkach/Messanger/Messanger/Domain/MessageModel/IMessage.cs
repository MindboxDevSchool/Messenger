using System;

namespace Messanger.Domain.MessageModel
{
    public interface IMessage
    {
        public Guid Id { get; }
        public object Content { get; set; }
        public DateTime CreationDateTime { get; }
        public DateTime EditDateTime { get; }
    }
}