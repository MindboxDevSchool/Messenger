using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService:IUserService
    {
        private UserInGroupRepository _userInGroupRepository;
        
        public ICollection<IGroup> GroupsOfUser { get; }

        public UserService(Guid userId)
        {
            GroupsOfUser = _userInGroupRepository.LoadByUser(userId).Select(i=> i.Group).ToList();
        }

        public void SendMessage(IGroup group, string text)
        {
            var message = new Message(text,);
            group.NewMessage();
        }
    }
}