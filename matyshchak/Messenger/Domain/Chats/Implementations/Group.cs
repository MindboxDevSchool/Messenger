using System;
using System.Collections.Generic;
using System.Linq;
using Domain.User;

namespace Domain.Chat
{
    public class Group : IGroup
    {
        public Guid Id { get; }
        public IReadOnlyCollection<Guid> MessagesIds { get; }
        public IReadOnlyCollection<Guid> AdminsIds { get; }
        public IReadOnlyCollection<Guid> MembersIds { get; }
        public bool UserHasPermissionsToPost(Guid userId) => MembersIds.Any(id => id == userId);
    }
}