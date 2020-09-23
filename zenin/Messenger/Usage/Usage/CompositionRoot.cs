using Messenger;
using Messenger.Application;
using Messenger.Infrastructure;

namespace Usage
{
    public class CompositionRoot
    {
        public static CompositionRoot Create()
        {
            var chatRepository = new ChatRepository();
            var userRepository = new UserRepository();
            return new CompositionRoot()
            {
                ChatService = new ChatService(chatRepository),
                UserService = new UserService(userRepository)
            };
        }

        public IChatService ChatService { get; private set; }
        public IUserService UserService { get; private set; }
    }
}