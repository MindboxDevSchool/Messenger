using System;
using System.Collections.Generic;

namespace Domain.Chat
{
    public class PrivateChat : IPrivateChat
    {
        public PrivateChat(Guid id, IReadOnlyCollection<Guid> messagesIds, Tuple<Guid, Guid> membersIds)
        {
            Id = id;
            MessagesIds = messagesIds;
            MembersIds = membersIds;
        }
        
        public Guid Id { get; }
        public IReadOnlyCollection<Guid> MessagesIds { get; }
        public Tuple<Guid, Guid> MembersIds { get; }
        public bool UserHasPermissionsToPost(Guid userId) =>
            MembersIds.Item1 == userId
            || MembersIds.Item2 == userId;
    }
}