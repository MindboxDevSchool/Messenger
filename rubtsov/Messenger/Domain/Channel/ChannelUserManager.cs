using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace Messenger.Domain.Channel
{
    public class ChannelUserManager
    {
        private Guid ChannelId { get; }
        private IUser Admin { get; set; }
        private HashSet<IUser> Users { get; set; }
        public ChannelUserManager(IChannel channel)
        {
            Admin = channel.Admin;
            Users = channel.Users;
            ChannelId = channel.ChannelId;
        }
        
        public void AddUsers(Guid initiatorId, IEnumerable<IUser> newUsers)
        {
            var errorMessage = "Only channel administrator is allowed to add new users";
            CheckAuthentication(initiatorId, errorMessage);
            foreach (var userToAdd in newUsers)
            {
                if (Users.All(user => user.Id != userToAdd.Id))
                {
                    userToAdd.LastSeenMessageInParticipatingCommunities.Add(ChannelId, new LastSeenMessage());
                }
            }
            Users.UnionWith(newUsers);
        }
        
        public void RemoveUsers(Guid initiatorId, IEnumerable<IUser> newUsers)
        {
            var errorMessage = "Only channel administrator is allowed to remove users";
            CheckAuthentication(initiatorId, errorMessage);
            foreach (var user in newUsers)
            {
                Users.Remove(user);
            }
        }

        public void LeaveChannel(Guid initiatorId)
        {
            if (initiatorId == Admin.Id)
            {
                throw new ArgumentException("Administrator cannot leave the channel");
            }
            var userToLeave = Users.SingleOrDefault(user => user.Id == initiatorId);
            if (userToLeave != null)
            {
                Users.Remove(userToLeave);
            }
        }

        public void ChangeAdmin(Guid initiatorId, Guid newAdmin)
        {
            var errorMessage = "Only channel administrator is allowed to change channel administrators";
            CheckAuthentication(initiatorId, errorMessage);
            Admin.Id = newAdmin;
        }

        private void CheckAuthentication(Guid initiatorId, string message)
        {
            if (initiatorId != Admin.Id)
            {
                throw new AuthenticationException(message);
            }
        }
    }
}