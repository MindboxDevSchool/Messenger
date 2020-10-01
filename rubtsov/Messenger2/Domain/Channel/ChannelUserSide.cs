using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Messenger2.Domain.Channel
{
    public class ChannelUserSide : IChannelUserSide
    {
        private Guid ChannelId { get; }
        public IUser Admin { get; set;  }
        public List<IMessage> Messages { get; }
        public HashSet<IUser> Users { get; }
        public ChannelUserSide(IAuthenticated channel, List<IMessage> messages)
        {
            Messages = messages;
            Users = channel.Users;
            ChannelId = channel.Id;
            Admin = channel.Admin;
        }
       
        public IReadOnlyCollection<IMessage> GetAllMessages(IUser user)
        {
            if (Messages.Count == 0)
            {
                throw new DataException("There are no messages on the channel yet");
            }
            var lastSeenMessage  = user.LastSeenMessageInParticipatingCommunities[ChannelId];
            lastSeenMessage.Content = Messages[^1].MessageContent;
            lastSeenMessage.HaveNewMessages = false;
            return Messages;
        }
        
        public IReadOnlyCollection<IMessage> GetUnreadMessages(IUser user)
        {
            var lastSeenMessage = GetLastSeenMessage(user);
            //
            switch (lastSeenMessage.Content)
            {
                case null when Messages.Count == 0:
                    lastSeenMessage.HaveNewMessages = false;
                    throw new ArgumentException("The user have no unread messages on the channel");
                case null:
                    UpdateUserLastMessage(lastSeenMessage);
                    return Messages;
            }
            var indexOfLastSeenMessage = 
                Messages.FindIndex(mes => mes.MessageContent == lastSeenMessage.Content);
            var numberOfNewMessages = Messages.Count - indexOfLastSeenMessage - 1;
            UpdateUserLastMessage(lastSeenMessage);
            return Messages.GetRange(indexOfLastSeenMessage + 1, numberOfNewMessages);
        }
        
        private LastSeenMessage GetLastSeenMessage(IUser user)
        {
            var lastSeenMessage  = user.LastSeenMessageInParticipatingCommunities[ChannelId];
            if(!lastSeenMessage.HaveNewMessages) 
            {
                throw new ArgumentException("The user have no unread messages on the channel");
            }
            return lastSeenMessage;
        }
        
        private void UpdateUserLastMessage(LastSeenMessage lastSeenMessage)
        {
            lastSeenMessage.Content = Messages[^1].MessageContent;
            lastSeenMessage.HaveNewMessages = false;
        }

        public IReadOnlyCollection<IMessage> FindMessage(string searchString)
        {
            return Messages
                .Where(message => message.MessageContent.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
        
        public void LeaveChannel(IUser userToLeave)
        {
            if (Admin.Id == userToLeave.Id)
            {
                throw new ArgumentException("Admin cannot leave the channel");
            }
            Users.Remove(userToLeave);
        }
    }
}