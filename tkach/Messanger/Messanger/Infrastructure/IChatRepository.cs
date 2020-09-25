using System;
using Messanger.Domain.ChatModel;

namespace Messanger.Infrastructure
{
    public interface IChatRepository
    {
        IChat Load(Guid chatId);
        void Save(IChat chat);
    }
}