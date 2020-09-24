using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        Chat CreateChat(User chatCreator, String chatType);
        void DeleteChat(IChat chat);
    }
}