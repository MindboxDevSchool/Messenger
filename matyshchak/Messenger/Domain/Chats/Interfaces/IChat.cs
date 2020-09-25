using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Chat
{
    public interface IChat
    {
        public Guid Id { get; }
        public IReadOnlyCollection<Guid> MessagesIds { get; }
        public bool UserHasPermissionsToPost(Guid userId);
        public bool UserHasPermissionsToEditMessage(Guid userId, Guid messageId);
        
    }
}