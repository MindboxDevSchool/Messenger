using System;

namespace Messenger.Domain
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
            _memberRepository.CreateUser(user);
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