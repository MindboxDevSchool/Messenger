using System;

namespace Messenger.Domain
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException(RoleType role): 
            base($"The role \"{role}\" is not available for this type of chat.")
        {
            
        }

        public InvalidRoleException(string message): base(message)
        {
            
        }
    }
}