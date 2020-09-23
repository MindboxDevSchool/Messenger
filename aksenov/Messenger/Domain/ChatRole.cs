using System.Collections.Generic;

namespace Messenger.Domain
{
    public class ChatRole
    {
        private readonly Dictionary<AccessType, bool> _accesses;

        public ChatRole(Dictionary<AccessType, bool> accesses)
        {
            _accesses = accesses;
        }

        public bool GetAccessFor(AccessType accessType)
        {
            return _accesses[accessType];
        }
    }
}