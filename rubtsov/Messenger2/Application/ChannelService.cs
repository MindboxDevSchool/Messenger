using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Messenger2.Domain;
using Messenger2.Domain.Channel;

namespace Messenger2.Application
{
    public class ChannelService
    {
        public Guid ChannelId { get; }
        private ChannelAuthentication ChannelAuthentication { get; }
        private IAuthenticated ChannelAuthenticated { get; }
        private ChannelAdminSide ChannelAdminSide { get; }
        private ChannelUserSide ChannelUserSide { get; }

        public ChannelService(IUser admin, Guid channelId, HashSet<IUser> users, List<IMessage> messages)
        {
            ChannelId = channelId;
            var channelAuthentication = 
                new ChannelAuthentication(admin, channelId, users);
            ChannelAuthentication = channelAuthentication;
            ChannelAuthenticated = channelAuthentication;
            ChannelUserSide = new ChannelUserSide(ChannelAuthenticated, messages);
            ChannelAdminSide = new ChannelAdminSide(ChannelAuthenticated, ChannelUserSide);
        }

        public ChannelAdminService AuthenticateAsAdmin(IUser initiator)
        {
            ChannelAuthentication.AuthenticateAdmin(initiator);
            return new ChannelAdminService(ChannelId, ChannelAdminSide); 
        }

        public ChannelUserService AuthenticateAsUser(IUser initiator)
        {
            ChannelAuthentication.AuthenticateUser(initiator);
            return new ChannelUserService(ChannelId, ChannelUserSide, initiator);
        }
    }
}