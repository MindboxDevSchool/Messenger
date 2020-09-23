using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class UserInGroupRepository:IUsersInGroupRepository
    {
        public ICollection<IUserInGroup> LoadByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        
        public ICollection<IUserInGroup> LoadByUser(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public void Save(IReadOnlyList<IUserInGroup> users)
        {
            throw new NotImplementedException();
        }
    }
}