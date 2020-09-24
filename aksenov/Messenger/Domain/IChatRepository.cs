using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatRepository
    {
        IChat GetBy(Guid chatId);
        void Update(IChat chat);
        void Save(IChat chat);
        void Delete(Guid chatId);
    }
}