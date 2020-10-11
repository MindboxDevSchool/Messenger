using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class GroupRepository : IGroupRepository
    {
        private List<IGroup> _groups;

        public GroupRepository()
        {
            _groups = new List<IGroup>();
        }
        
        public IGroup CreateGroup(IUser creator, string name)
        {
            var id = Guid.NewGuid().ToString("N");
            var group = new Group(id, name, creator);
            _groups.Add(group);
            return group;
        }

        public IGroup GetGroup(string groupId)
        {
            var group = _groups.FirstOrDefault(m => m.Id == groupId);
            if (group == null)
                throw new NotFoundException();
            return group;
        }

        public void EditGroup(string groupId, string newName)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteGroup(string groupId)
        {
            _groups.RemoveAll(c => c.Id == groupId);
        }
    }
}