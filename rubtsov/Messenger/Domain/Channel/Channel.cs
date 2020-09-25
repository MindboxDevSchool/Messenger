using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Authentication;

namespace Messenger.Domain.Channel
{
    public class Channel : IChannel
    {
        public Guid ChannelId { get; }
        public IUser Admin { get; }
        private List<IMessage> Messages { get; }
        public HashSet<IUser> Users { get; }

        public Channel(IUser admin, Guid channelId, IEnumerable<IUser> users)
        {
            Admin = admin;
            ChannelId = channelId;
            Messages = new List<IMessage>();
            Users = new HashSet<IUser>();
            Users.UnionWith(users);
            Users.UnionWith(new []{admin});
            foreach (var user in Users)
            {
                user.LastSeenMessageInParticipatingCommunities.Add(ChannelId, new LastSeenMessage());
            }
        }

        public void SendMessage(Guid initiatorId, IMessage message)
        {
            var errorMessage = "Only channel administrator is allowed to send messages";
            CheckAdminAuthentication(initiatorId, errorMessage);
            Messages.Add(message);
            NotifyAboutNewMessage();
        }

        public void DeleteMessage(Guid initiatorId, IMessage message)
        {
            var errorMessage = "Only channel administrator is allowed to delete messages";
            CheckAdminAuthentication(initiatorId, errorMessage);
            if (Messages.Contains(message))
            {
                Messages.Remove(message);
            }
        }

        public IReadOnlyCollection<IMessage> GetAllMessages(Guid initiatorId)
        {
            CheckChannelMemberAuthentication(initiatorId);
            var initiator = Users.Single(user => user.Id == initiatorId);
            var lastSeenMessage  = initiator.LastSeenMessageInParticipatingCommunities[ChannelId];
            if (Messages.Count == 0)
            {
                throw new NullReferenceException("There are no messages on the channel yet");
            }
            lastSeenMessage.Content = Messages[^1].MessageContent;
            lastSeenMessage.HaveNewMessages = false;
            return Messages;
        }
        public IReadOnlyCollection<IMessage> GetUnreadMessages(Guid initiatorId)
        {
            var lastSeenMessage = GetLastSeenMessage(initiatorId);
            if (lastSeenMessage.Content == null)
            {
                UpdateUserLastMessage(lastSeenMessage);
                return Messages;
            }
            var indexOfLastSeenMessage = 
                Messages.FindIndex(mes => mes.MessageContent == lastSeenMessage.Content);
            var numberOfNewMessages = Messages.Count - indexOfLastSeenMessage - 1;
            UpdateUserLastMessage(lastSeenMessage);
            return Messages.GetRange(indexOfLastSeenMessage + 1 , numberOfNewMessages);
        }

        private LastSeenMessage GetLastSeenMessage(Guid initiatorId)
        {
            CheckChannelMemberAuthentication(initiatorId);
            var initiator = Users.Single(user => user.Id == initiatorId);
            var lastSeenMessage  = initiator.LastSeenMessageInParticipatingCommunities[ChannelId];
            if(!lastSeenMessage.HaveNewMessages) 
            {
                throw new ArgumentException("The user have no unread messages on the channel");
            }
            return lastSeenMessage;
        }
        
        public IReadOnlyCollection<IMessage> FindMessage(string searchString)
        {
            return Messages
                .Where(message => message.MessageContent.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
        
        private void UpdateUserLastMessage(LastSeenMessage lastSeenMessage)
        {
            lastSeenMessage.Content = Messages[^1].MessageContent;
            lastSeenMessage.HaveNewMessages = false;
        }

        private void NotifyAboutNewMessage()
        {
            foreach (var user in Users)
            {
                user.LastSeenMessageInParticipatingCommunities[ChannelId].HaveNewMessages = true;
            }
        }
        
        private void CheckAdminAuthentication(Guid initiatorId, string message)
        {
            if (initiatorId != Admin.Id)
            {
                throw new AuthenticationException(message);
            }
        }
        
        private void CheckChannelMemberAuthentication(Guid initiatorId)
        {
            var errorMessage = "Only channel member can read messages";
            if (initiatorId != Admin.Id && Users.All(user => user.Id != initiatorId))
            {
                throw new AuthenticationException(errorMessage);
            }
        }
    }
}