using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Messenger.Domain
{
    public enum ChatTypes
    {
        Channel, Group, Dialogue    
    }
    public abstract class Chat : IChat
    {
        public Guid Id { get; }
        public string Name { get; }
        public IEnumerable<IUser> Users { get; set; }
        public IEnumerable<IUser> Admins { get; set; }
        public IEnumerable<IMessage> Messages { get; set; }
        public ChatTypes ChatType { get; }

        internal Chat(string chatName, IEnumerable<IUser> chatUsers,
            IEnumerable<IUser> chatAdmins, IEnumerable<IMessage> chatMessages, ChatTypes chatType)
        {
            Id = Guid.NewGuid();
            Name = chatName;
            Users = chatUsers;
            Admins = chatAdmins;
            Messages = chatMessages;
            ChatType = chatType;
        }

        public abstract bool CanUserSendMessages(IUser user);
        public abstract bool CanUserUpdateMessages(IUser user, IMessage message);
        public abstract bool CanUserDeleteMessages(IUser user, IMessage message);

        public bool CanUserMakeAdmins(IUser user) => Admins.Contains(user);

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}