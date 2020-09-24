using System;

namespace Messenger.Domain
{
    public class PrivateChat:Group
    {
        public PrivateChat(IUser creator,IUser user2,
                           IMessageInGroupRepository messages, 
                           IUsersRepository users,Guid id) : base(creator, messages, users,id)
        {
            _memberRepository.CreateUser(user2);
        }

        protected override bool CanUserSendMessage(IUser user)
        {
            return true;
        }

        protected override bool CanUserEditMessage(IUser user, IMessage message)
        {
            return message.SenderId == user.Id;
        }

        protected override bool CanUserDeleteMessage(IUser user, IMessage message)
        {
            return message.SenderId == user.Id;
        }
    }
}