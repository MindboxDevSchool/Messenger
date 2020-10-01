using System;
using System.Collections.Generic;
using System.Linq;
using Messenger2.Domain;
using Messenger2.Domain.Channel;

namespace Messenger2.Application
{
    public class ChannelUserService
    {
        public Guid ChannelId { get; }
        private IUser User { get; }
        private ChannelUserSide ChannelUserSide { get; }

        public ChannelUserService(Guid channelId, ChannelUserSide channelUserSide, IUser user)
        {
            ChannelId = channelId;
            ChannelUserSide = channelUserSide;
            User = user;
        }

        public IReadOnlyCollection<IMessage> GetAllMessages()
        {
            return ChannelUserSide.GetAllMessages(User);
        }

        public IReadOnlyCollection<IMessage> GetUnreadMessages()
        {
            return ChannelUserSide.GetUnreadMessages(User);
        }

        public IReadOnlyCollection<IMessage> FindMessage(string searchString)
        {
            return ChannelUserSide.FindMessage(searchString);
        }

        public void LeaveChannel()
        {
            ChannelUserSide.LeaveChannel(User);
        }
        
        public IUser GetAdmin()
        {
            return ChannelUserSide.Admin;
        }
        
        public IReadOnlyList<IUser> GetUsers()
        {
            return ChannelUserSide.Users.ToList();
        }
    }
}