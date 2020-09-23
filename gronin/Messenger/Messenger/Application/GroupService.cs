using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Messenger.Domain;

namespace Messenger.Application
{
    public class GroupService:IGroupService
    {
        private readonly IUsersInGroupRepository _usersInGroupRepository;
        private readonly IMessageInGroupRepository _messageInGroupRepository;
        private readonly IGroup _group;

        public GroupService(IUsersInGroupRepository usersInGroupRepository,
                            IMessageInGroupRepository messageInGroupRepository,
                            Guid groupId)
        {
            _usersInGroupRepository = usersInGroupRepository;
            _messageInGroupRepository = messageInGroupRepository;
            
            var users = _usersInGroupRepository.LoadByGroup(groupId);
            var messages = _messageInGroupRepository.Load(groupId);
            
            _group = new Group(groupId,users,messages);
        }

        public void SendMessage(IMessage newMessage)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMessage(IMessage message)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMessage(IMessage oldMessage, string newText)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<IUserInGroup> Users { get; }
        public ICollection<IMessage> Messages { get; }
        public ICollection<IMessage> GetMessagesToShow(int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}