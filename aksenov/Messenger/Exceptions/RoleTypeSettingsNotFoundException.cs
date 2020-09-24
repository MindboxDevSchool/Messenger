using System;

namespace Messenger.Domain
{
    public class RoleTypeSettingsNotFoundException : Exception
    {
        public RoleTypeSettingsNotFoundException(RoleType roleType): 
            base($"Settings for role type \"{roleType}\" not found.")
        {
            
        }

        public RoleTypeSettingsNotFoundException(string message): base(message)
        {
            
        }
    }
}