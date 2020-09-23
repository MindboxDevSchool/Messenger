using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IChatRepository
    {
        void CreateChat(IChat chat);
        IChat GetChat(Guid chatId);
        void DeleteChat(Guid chatId);
    }
}