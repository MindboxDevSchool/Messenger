using Crane.Domain;

namespace Crane.Application
{
    public class MessageService
    {
        public bool TrySendMessage(IUser user, IChat chat, string body)
        {
            return chat.TrySendMessage(user, body);
        }
        
        public bool TryEditMessage(IUser user, IChat chat, IMessage message, string body)
        {
            return chat.TryEditMessage(user, message, body);
        }
    }
}
