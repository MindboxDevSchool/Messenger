using System;

namespace Messenger
{
    public interface IChatService
    {
        Guid CreateNewChat(IChat chat);
    }
}