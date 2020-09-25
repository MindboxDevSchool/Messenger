using System;

namespace Messenger.Domain
{
    public class PrivateChat : Chat
    {
        public String ChatName { get; }
        public PrivateChat(User chatCreator, User secondUser, String chatName) : base(chatCreator, chatName)
        {
            _userRepository.AddUser(secondUser);
            ChatName = chatName;
        }

        protected override bool MessageSendingPermission(User user)
        {
            return true;
        }

        protected override bool MessageDeletingPermission(User user)
        {
            return true;
        }

        protected override bool MessageEditingPermission(User user, Message message)
        {
            return user.UserId == message.MessageCreator;
        }
    }
}