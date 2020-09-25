using System;
using Messenger.Domain;

namespace Messenger
{
    public interface IMessageRepository
    {
        IMessage Load(Guid messageId);
        public void Save(IMessage message);
    }
}