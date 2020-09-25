using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Channel : Chat
    {
        private IEnumerable<IUser> _admins;
        public Channel(string chatName, IEnumerable<IUser> chatUsers, IEnumerable<IUser> chatAdmins,
            IEnumerable<IMessage> chatMessages, ChatTypes _chatTypes) : base(chatName, chatUsers, chatAdmins,
            chatMessages, ChatTypes.Channel)
        {
            _admins = chatAdmins;
        }

        public override bool CanUserSendMessages(IUser user) => _admins.Contains(user);

        public override bool CanUserUpdateMessages(IUser user, IMessage message)
        {
            return (message.UserId == user.Id);
        }

        public override bool CanUserDeleteMessages(IUser user, IMessage message) => message.UserId == user.Id;
    }
}