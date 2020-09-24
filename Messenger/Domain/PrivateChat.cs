namespace Messenger.Domain
{
    public class PrivateChat : Chat
    {
        public PrivateChat(User chatCreator, User secondUser) : base(chatCreator)
        {
            _userRepository.AddUser(secondUser);
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