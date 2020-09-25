using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Dialogue : Chat
    {
        private IEnumerable<IUser> _admins;
        private IEnumerable<IUser> _users;
        public Dialogue(string chatName, IEnumerable<IUser> chatUsers, 
            IEnumerable<IUser> chatAdmins, IEnumerable<IMessage> chatMessages, 
            ChatTypes _chatType) : base(chatName, chatUsers, 
            chatAdmins, chatMessages, ChatTypes.Dialogue)
        {
            _admins = chatAdmins;
            _users = chatUsers;
        }

        public override bool CanUserSendMessages(IUser user) => _users.Contains(user);

        public override bool CanUserUpdateMessages(IUser user, IMessage message) => message.UserId == user.Id;

        public override bool CanUserDeleteMessages(IUser user, IMessage message) => message.UserId == user.Id || _admins.Contains(user);
    }
}