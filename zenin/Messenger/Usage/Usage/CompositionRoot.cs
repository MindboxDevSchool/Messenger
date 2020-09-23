using Messenger;

namespace Usage
{
    public class CompositionRoot
    {
        public static CompositionRoot Create()
        {
            return new CompositionRoot()
            {
                ChatService = new Messenger.ChatService(),
                UserService = new Messenger.UserService()
            };
        }

        public IChatService ChatService { get; private set; }
        public IUserService UserService { get; private set; }
    }
}