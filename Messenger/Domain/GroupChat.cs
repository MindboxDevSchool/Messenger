using System.Collections.Generic;

namespace Messenger.Domain
{
    public class GroupChat : Chat
    {
        public List<User> _groupAdministrators = new List<User>();
        
        public GroupChat(User chatCreator) : base(chatCreator)
        {
            _groupAdministrators.Add(chatCreator);
        }

        public void AddGroupAdministrator(User user)
        {
            _groupAdministrators.Add(user);
        }
        
        protected override bool MessageSendingPermission(User user)
        {
            return true;
        }

        protected override bool MessageDeletingPermission(User user)
        {
            return _groupAdministrators.Contains(user);
        }

        protected override bool MessageEditingPermission(User user, Message message)
        {
            return user.UserId == message.MessageCreator;
        }

        public void AddUserToGroup(User user)
        {
            _userRepository.AddUser(user);
        }
        
    }
}