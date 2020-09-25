using System;
using Messenger.Domain;

namespace Messenger.Exceptions
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