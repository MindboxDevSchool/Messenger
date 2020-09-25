using System;
using Domain.Chat;

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