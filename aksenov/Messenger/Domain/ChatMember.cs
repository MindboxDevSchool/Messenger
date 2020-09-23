namespace Messenger.Domain
{
    public class ChatMember
    {
        public IUser User { get; }
        
        public RoleType Role { get; private set; }

        public ChatMember(IUser user, RoleType role)
        {
            User = user;
            Role = role;
        }

        public void ChangeRole(RoleType newRole)
        {
            Role = newRole;
        }
    }
}