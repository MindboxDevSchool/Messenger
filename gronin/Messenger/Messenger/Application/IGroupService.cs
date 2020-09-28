using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IGroupService
    {
        void CreateChat(string name, IUser user);
        void CreatePrivateChat(string name, IUser user,IUser user2);
        void CreateChannel(string name, IUser user);
        void DeleteGroup(Guid groupId);
        IGroup GetGroup(Guid groupId);
    }
}