using System.Collections.Generic;

namespace Messenger.Domain
{
    public class ChatRole
    {
        private readonly Dictionary<AccessType, bool> _credentials;

        public ChatRole(Dictionary<AccessType, bool> accesses)
        {
            _credentials = accesses;
        }

        public bool GetAccessFor(AccessType accessType)
        {
            return _credentials[accessType];
        }
    }
}