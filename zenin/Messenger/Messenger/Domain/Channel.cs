using System;

namespace Messenger
{
    public class Channel : Chat
    {
        public User ChannelAuthor { get; private set; }

        public Channel(User user) : base(user)
        {
            ChannelAuthor = user;
        }
        
        public void AddNewMember(User user)
        {
            _members.Add(user);
        }

        protected override bool CanUserSendMessage(User user)
        {
            return user == ChannelAuthor;
        }

        protected override bool CanUserEditMessage(User user, Message message)
        {
            return user == ChannelAuthor;
        }

        protected override bool CanUserDeleteMessage(User user, Message message)
        {
            return user == ChannelAuthor;
        }
    }
}