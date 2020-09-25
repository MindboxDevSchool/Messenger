using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChatRepository
    {
        IChat GetBy(Guid chatId);
        void Update(IChat chat);
        void Save(IChat chat);
        void Delete(Guid chatId);
        IEnumerable<Message> LoadNewFor(Guid chatId);
    }
}