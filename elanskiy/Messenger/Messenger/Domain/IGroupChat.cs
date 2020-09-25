using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroupChat
    {
        Guid Id { get; }
        string Name { get; set; }
        List<Guid> Users { get; set; }
        List<Guid> Admins { get; set; }
        DateTime CreatedOn { get; }
    }
}