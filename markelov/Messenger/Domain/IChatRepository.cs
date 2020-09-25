using System;

namespace Messenger.Domain
{
    public interface IChatRepository
    {
        IChat GetChat(Guid chatId);
        void SaveChat(IChat chat);
        void DeleteChat(Guid chatId);
    }
}