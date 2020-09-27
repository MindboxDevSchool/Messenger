using System;
using Domain.Chats;

namespace Domain.Repositories
{
    public interface IChatRepository
    {
        public void AddChat(IChat chat);
        public IChat GetChat(Guid id);
        public void UpdateChat(IChat chat);
        public void DeleteChat(Guid id);
    }
}