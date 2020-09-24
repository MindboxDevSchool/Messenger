using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Messenger.Domain;

namespace Messenger.Application
{
    public class GroupService:IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMessageInGroupRepository _messageInGroupRepository;

        public GroupService(IGroupRepository groupRepository, IUsersRepository usersRepository,
            IMessageInGroupRepository messageInGroupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _messageInGroupRepository = messageInGroupRepository ??
                                        throw new ArgumentNullException(nameof(messageInGroupRepository));
        }

        public void CreateChat(string name, IUser user)
        {
            var id = Guid.NewGuid();
            var chat = new Chat(user,_messageInGroupRepository,_usersRepository);
        }

        public void CreatePrivateChat(string name, IUser user1,IUser user2)
        {
            var id = Guid.NewGuid();
            var chat = new PrivateChat(user1, user2, _messageInGroupRepository, _usersRepository);
        }

        public void CreateChannel(string name, IUser user)
        {
            var id = Guid.NewGuid();
            var chat = new GroupChannel(user,_messageInGroupRepository,_usersRepository);
        }

        public void DeleteGroup(Guid id)
        {
            _groupRepository.DeleteGroup(id);
        }

        public IGroup GetGroup(Guid chatId)
        {
            return _groupRepository.GetGroup(chatId);
        }
    }
    
}