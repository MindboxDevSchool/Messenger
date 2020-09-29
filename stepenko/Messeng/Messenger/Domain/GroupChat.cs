using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class GroupChat : Chat
    {
        public List<IUser> _groupAdministrators = new List<IUser>();
        public String ChatName { get; }
        
        public GroupChat(IUser chatCreator, String chatName) : base(chatCreator, chatName)
        {
            _groupAdministrators.Add(chatCreator);
            ChatName = chatName;
        }

        public void AddGroupAdministrator(IUser user)
        {
            _groupAdministrators.Add(user);
        }
        
        protected override bool MessageSendingPermission(IUser user)
        {
            return true;
        }

        protected override bool MessageDeletingPermission(IUser user)
        {
            return _groupAdministrators.Contains(user);
        }

        protected override bool MessageEditingPermission(IUser user, IMessage message)
        {
            return user.UserId == message.MessageCreator;
        }

        public void AddUserToGroup(IUser user)
        {
            _userRepository.AddUser(user);
        }
        
    }
}