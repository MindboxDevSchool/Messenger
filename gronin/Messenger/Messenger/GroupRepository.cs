using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class GroupRepository:IGroupRepository
    {
        private readonly Dictionary<Guid, IGroup> _chatDictionary = new Dictionary<Guid, IGroup>();
        
        public void CreateGroup(IGroup @group)
        {
            _chatDictionary.Add(group.Id,group);
        }

        public IGroup GetGroup(Guid groupId)
        {
            return _chatDictionary[groupId];
        }

        public void DeleteGroup(Guid groupId)
        {
            _chatDictionary.Remove(groupId);
        }
    }
}