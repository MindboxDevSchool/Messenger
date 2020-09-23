using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class MessengerSettings
    {
        public Dictionary<RoleType, Dictionary<AccessType, bool>> Accesses { get; }

        public Dictionary<ChatType, int> MaxMembers { get; }
    }
}