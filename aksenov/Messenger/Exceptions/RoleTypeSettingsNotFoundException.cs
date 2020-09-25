using System;
using Messenger.Domain;

namespace Messenger.Exceptions
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