using Crane.Domain;

namespace Crane.Application
{
    public class ChatService
    {
        public void CreatePrivateChat()
        {
            PrivateChat _ = new PrivateChat();
        }

        public IChat GetChat(int id)
        {
            return null;
        }
    }
}
