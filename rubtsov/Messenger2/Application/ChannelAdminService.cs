using System;
using System.Collections.Generic;
using Messenger2.Domain;
using Messenger2.Domain.Channel;

namespace Messenger2.Application
{
    public class ChannelAdminService
    {
        private ChannelAdminSide ChannelAdminSide { get; }
        public Guid ChannelId { get; }
        
        public ChannelAdminService(Guid channelId, ChannelAdminSide channelAdminSide)
        {
            ChannelId = channelId;
            ChannelAdminSide = channelAdminSide;
        }

        public void AddUsers(IReadOnlyCollection<IUser> newUsers)
        {
            ChannelAdminSide.AddUsers(newUsers);
        }
        public void RemoveUsers(IEnumerable<IUser> usersToRemove)
        {
            ChannelAdminSide.RemoveUsers(usersToRemove);   
        }
        public void ChangeAdmin(IUser newAdmin)
        {
            ChannelAdminSide.ChangeAdmin(newAdmin);
        }

        public void SendMessage(IMessage message)
        {
            ChannelAdminSide.SendMessage(message);
        }
        public void DeleteMessage(IMessage message)
        {
            ChannelAdminSide.DeleteMessage(message);
        }
        
    }
}