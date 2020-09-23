using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        void CreateChat(IChat chat);
        void DeleteChat(IChat chat);
    }
}