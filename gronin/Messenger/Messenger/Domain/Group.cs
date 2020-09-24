using System;

namespace Messenger.Domain
{
    
        public abstract class Group : IGroup
        {
            public Guid Id { get; }
            public string Name { get; set; }
            public IUser CreatedBy { get; protected set; }
            protected readonly IMessageInGroupRepository _messageRepository;
            protected readonly IUsersRepository _memberRepository;

            public Group(IUser creator,IMessageInGroupRepository messages,IUsersRepository users)
            {
                Id = Guid.NewGuid();
                CreatedBy = creator;
                _messageRepository = messages;
                _memberRepository = users;
                _memberRepository.CreateUser(creator);
            }
            public void AddNewMember(User user)
            {
                _memberRepository.CreateUser(user);
            }
            protected abstract bool CanUserSendMessage(IUser user);
            protected abstract bool CanUserEditMessage(IUser user, IMessage message);
            protected abstract bool CanUserDeleteMessage(IUser user, IMessage message);
        
            public Guid SendMessage(IUser user, string text)
            {
                Message newMessage = new Message(text, user.Id,Id);
                if (!(CanUserSendMessage(user) && _memberRepository.GetUser(user.Id) != null))
                {
                    throw new ArgumentException("Can't send message");
                }
                _messageRepository.CreateMessage(newMessage);
                return newMessage.Id;
            }

            public IMessage GetMessage(Guid messageId)
            {
                return _messageRepository.GetMessage(messageId);
            }

            public void EditMessage(IUser user, IMessage message, string newText)
            {
                if (CanUserEditMessage(user, message) && _memberRepository.GetUser(user.Id) != null)
                {
                    message.Text = newText;
                    _messageRepository.UpdateMessage(message.Id, message);
                }
            }
        
            public void DeleteMessage(IUser user, IMessage message)
            {
                if (CanUserDeleteMessage(user, message) && _memberRepository.GetUser(user.Id) != null)
                    _messageRepository.DeleteMessage(message.Id);
            }
        }
    
}