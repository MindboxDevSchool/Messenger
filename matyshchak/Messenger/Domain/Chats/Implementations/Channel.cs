using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Chat
{
    public class Channel : IChannel
    {
        public Channel(Guid id, Guid ownerId, IReadOnlyCollection<Guid> messagesIds, IReadOnlyCollection<Guid> subscribersIds)
        {
            Id = id;
            OwnerId = ownerId;
            MessagesIds = messagesIds;
            SubscribersIds = subscribersIds;
        }
        
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public IReadOnlyCollection<Guid> MessagesIds { get; }
        public IReadOnlyCollection<Guid> SubscribersIds { get; }
        public bool UserHasPermissionsToPost(Guid userId) => OwnerId == userId;
    }
}