using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        ICollection<IGroup> GroupsOfUser { get; }
    }
}