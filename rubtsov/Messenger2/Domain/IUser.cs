using System;
using System.Collections.Generic;
using Messenger2.Domain.Channel;

namespace Messenger2.Domain
{
    public interface IUser
    {
        public Guid Id { get; set; }
        public Dictionary<Guid, LastSeenMessage> LastSeenMessageInParticipatingCommunities { get; set; }
    }
}