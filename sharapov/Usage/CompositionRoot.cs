
using Messenger.Infrastructure;

namespace Usage
{
    public class CompositionRoot
    {
        public IMessengerService MessengerService { get; private set; }
        
        public IMessengerService UserService { get; private set; }
        
        public static CompositionRoot Create() {
            return new CompositionRoot
            {
                MessengerService = new MessengerService(
                     new ChatterFactory(), 
                 new PrivateChatFactory(),
                 new GroupChatFactory(), 
                 new ChannelFactory(), 
                 new MessagesRepositoryFactory())
            };
        }
    }
}
