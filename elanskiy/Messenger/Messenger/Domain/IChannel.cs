using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChannel
    {
        Guid Id { get; }
        string Name { get; }
        DateTime CreatedOn { get; }
        List<Guid> Admins { get; set; }
        List<Guid> Users { get; set; }
    }
}