using System.Collections.Generic;

namespace Crane.Domain
{
    public class User : IUser
    {
        public IPasswordHandler PasswordHandler { get; }
        public IEnumerable<IChat> Chats { get; }
        public string Name { get; set; }
        public int Id { get; }
    }
}
