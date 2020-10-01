using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger2.Domain.Channel
{
    public class ChannelAdminSide
    {
        private Guid ChannelId { get; }
        private IUser Admin { get; set; }
        private HashSet<IUser> Users { get; }
        private List<IMessage> Messages { get; }
        private IAuthenticated Channel { get; }
        private IChannelUserSide ChannelUserSide { get; }

        public ChannelAdminSide(IAuthenticated channel, IChannelUserSide channelUserSide)
        {
            Channel = channel;
            Admin = channel.Admin;
            Users = channel.Users;
            ChannelId = channel.Id;
            Messages = channelUserSide.Messages;
            ChannelUserSide = channelUserSide;
        }

        public void AddUsers(IReadOnlyCollection<IUser> newUsers)
        {
            CreateChannelRecordForNewUsers(newUsers);
            Users.UnionWith(newUsers);
        }

        private void CreateChannelRecordForNewUsers(IEnumerable<IUser> newUsers)
        {
            foreach (var userToAdd in newUsers)
            {
                if (Users.All(user => user.Id != userToAdd.Id))
                {
                    userToAdd.LastSeenMessageInParticipatingCommunities.Add(ChannelId, new LastSeenMessage());
                }
            }
        }
        public void RemoveUsers(IEnumerable<IUser> newUsers)
        {
            foreach (var user in newUsers)
            {
                Users.Remove(user);
            }
        }

        public void ChangeAdmin(IUser newAdmin)
        {
            Admin = newAdmin;
            ChannelUserSide.Admin = newAdmin;
            Channel.Admin = newAdmin;
            Users.Add(newAdmin);
        }

        public void SendMessage(IMessage message)
        {
            Messages.Add(message);
            NotifyAboutNewMessage();
        }

        private void NotifyAboutNewMessage()
        {
            foreach (var user in Users)
            {
                //О новых сообщениях на канале уведомляются все участники, кроме админа
                user.LastSeenMessageInParticipatingCommunities[ChannelId].HaveNewMessages = user.Id != Admin.Id;
            }
        }

        public void DeleteMessage(IMessage message)
        {
            if (Messages.Contains(message))
            {
                var i = Messages.IndexOf(message);
                Messages[i] = new Message(Admin.Id, "The message was deleted");
            }
        }
    }
}