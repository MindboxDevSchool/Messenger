using System;
using Messanger.Domain.MessageModel;

namespace Messanger.Infrastructure
{
    public interface IMessageRepository
    {
        IMessage Load(Guid messageId);
        void Save(IMessage message);
    }
}