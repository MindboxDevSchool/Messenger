using System;

namespace Messenger.Domain
{
    public class ChannelChat : Chat
    {
        public User ChannelCreator { get; }
        public String ChatName { get; }

        public ChannelChat(User chatCreator, String chatName) : base(chatCreator, chatName)
        {
            ChannelCreator = chatCreator;
            ChatName = chatName;
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