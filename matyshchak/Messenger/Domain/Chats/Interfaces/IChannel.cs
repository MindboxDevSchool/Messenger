using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Chat
{
    public interface IChannel : IChat
    {
        public Guid OwnerId { get; }
        public IReadOnlyCollection<Guid> SubscribersIds { get; }
    }
}