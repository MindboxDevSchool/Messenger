using Messenger.Application;
using Messenger.Infrastructure;

namespace Usage
{
    public class CompositionRoot
    {
        public static CompositionRoot Create()
        {
            var channelChatRepository = new ChatRepository();
            var groupChatRepository = new ChatRepository();
            var privateChatRepository = new ChatRepository();
            var userRepository = new UserRepository();
            var messageRepository = new MessageRepository();
            return new CompositionRoot()
            {
                UserService = new UserService(userRepository),
                IChannelChatService = new ChannelChatService(channelChatRepository),
                IGroupChatService = new GroupChatService(groupChatRepository),
                IPrivateChatService = new PrivateChatService(privateChatRepository)
                
            };
        }

        public IUserService UserService { get; private set; }
        public IChatService IChannelChatService { get; private set; }
        public IChatService IGroupChatService { get; private set; }
        public IChatService IPrivateChatService { get; private set; }
    }
}