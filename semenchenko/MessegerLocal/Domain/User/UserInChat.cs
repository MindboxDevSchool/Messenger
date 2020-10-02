using System;

namespace Messeger.Domain
{
    public class UserInChat
    {
        public Role.Role Role { get; private set; }
        public string UserName { get; private set; }
        public ProfilePicture ProfilePicture { get; private set; }

        public UserInChat(User originUser, Role.Role role)
        {
            throw new NotImplementedException();
        }
    }
}