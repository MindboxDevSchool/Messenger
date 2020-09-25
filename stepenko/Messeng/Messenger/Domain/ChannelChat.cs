using System;

namespace Messenger.Domain
{
    public class ChannelChat : Chat
    {
        public IUser ChannelCreator { get; }
        public String ChatName { get; }

        public ChannelChat(IUser chatCreator, String chatName) : base(chatCreator, chatName)
        {
            ChannelCreator = chatCreator;
            ChatName = chatName;
        }

        protected override bool MessageSendingPermission(IUser user)
        {
            return user == ChannelCreator;
        }

        protected override bool MessageDeletingPermission(IUser user)
        {
            return user == ChannelCreator;
        }

        protected override bool MessageEditingPermission(IUser user, IMessage message)
        {
            return user == ChannelCreator;
        }

        public void AddUserToChannel(IUser user)
        {
            _userRepository.AddUser(user);
        }
    }
}