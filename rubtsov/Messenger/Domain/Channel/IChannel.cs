using System;
using System.Collections.Generic;

namespace Messenger.Domain.Channel
{
    public interface IChannel
    {
        public Guid ChannelId { get; }
        public IUser Admin { get; }
        public HashSet<IUser> Users { get; }
    }
}