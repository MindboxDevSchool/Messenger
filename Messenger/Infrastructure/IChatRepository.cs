using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IChatRepository
    {
        void AddChat(IChat chat);
        void DeleteChat(Guid chatId);
        IChat GetChat(Guid chatId);
    }
}