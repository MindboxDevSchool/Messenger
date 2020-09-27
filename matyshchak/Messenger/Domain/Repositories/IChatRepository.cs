using System;
using Domain.Chats;

namespace Domain.Repositories
{
    public interface IChatRepository
    {
        IChat AddChat(IChat chat);
        IChat GetChat(Guid id);
        IChat UpdateChat(IChat chat);
        IChat DeleteChat(Guid id);
    }
}