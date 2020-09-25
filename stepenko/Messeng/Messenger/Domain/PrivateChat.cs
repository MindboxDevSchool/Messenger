using System;

namespace Messenger.Domain
{
    public class PrivateChat : Chat
    {
        public String ChatName { get; }
        public PrivateChat(IUser chatCreator, IUser secondUser, String chatName) : base(chatCreator, chatName)
        {
            _userRepository.AddUser(secondUser);
            ChatName = chatName;
        }

        protected override bool MessageSendingPermission(IUser user)
        {
            return true;
        }

        protected override bool MessageDeletingPermission(IUser user)
        {
            return true;
        }

        protected override bool MessageEditingPermission(IUser user, IMessage message)
        {
            return user.UserId == message.MessageCreator;
        }
    }
}