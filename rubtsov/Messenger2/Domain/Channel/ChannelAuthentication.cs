using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace Messenger2.Domain.Channel 
{
    public class ChannelAuthentication: IAuthenticated
    {
        public Guid Id { get; }
        public IUser Admin { get; set; }
        public HashSet<IUser> Users { get; }

        public ChannelAuthentication(IUser admin, Guid channelId, HashSet<IUser> users)
        {
            Admin = admin;
            Id = channelId;
            Users = users;
            Users.UnionWith(new []{admin});
            // foreach (var user in Users)
            // {
            //     user.LastSeenMessageInParticipatingCommunities.Add(Id, new LastSeenMessage());
            // }
        }

        public void AuthenticateAdmin(IUser initiator)
        {
            if (Admin.Id != initiator.Id)
            {
                throw new AuthenticationException("Only admin is allowed to make this action");
            }
        }
        
        public void AuthenticateUser(IUser initiator)
        {
            if (Users.All(user => user.Id != initiator.Id ))
            {
                throw new AuthenticationException("Only channel member can read messages");
            }
        }
    }
}