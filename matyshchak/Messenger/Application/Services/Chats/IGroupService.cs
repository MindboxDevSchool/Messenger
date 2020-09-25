using System;

namespace Application.Services.Chats
{
    public interface IGroupService
    {
        public Guid CreateGroup(GroupName groupName);
        
    }
}