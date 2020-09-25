using System;
using Messenger.Domain;

namespace Messenger
{
    public interface IChatRepository
    {
        IChat Load(Guid chatId);
        void Save(IChat chat);
    }
}