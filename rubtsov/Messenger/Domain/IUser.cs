using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        public Guid Id { get; set; }
        public Dictionary<Guid, LastSeenMessage> LastSeenMessageInParticipatingCommunities { get; set; }
    }
}