namespace Messenger.Domain
{
    public class ChannelChat : Chat
    {
        public User ChannelCreator { get; private set; }

        public ChannelChat(User chatCreator) : base(chatCreator)
        {
            ChannelCreator = chatCreator;
        }

        protected override bool MessageSendingPermission(User user)
        {
            return user == ChannelCreator;
        }

        protected override bool MessageDeletingPermission(User user)
        {
            return user == ChannelCreator;
        }

        protected override bool MessageEditingPermission(User user, Message message)
        {
            return user == ChannelCreator;
        }

        public void AddUserToChannel(User user)
        {
            _userRepository.AddUser(user);
        }
    }
}