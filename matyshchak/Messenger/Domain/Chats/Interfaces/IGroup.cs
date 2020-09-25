using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Chat
{
    public interface IGroup : IChat
    {
        public IReadOnlyCollection<Guid> AdminsIds { get; }
        public IReadOnlyCollection<Guid> MembersIds{ get; }
    }
}