using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}