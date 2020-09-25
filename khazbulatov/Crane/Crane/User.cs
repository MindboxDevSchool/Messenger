using System.Collections.Generic;
using Crane.Domain;

namespace Crane
{
    public class User : IUser
    {
        public IPasswordHandler PasswordHandler { get; } = new SHA256PasswordHandler();
        public IEnumerable<IChat> Chats { get; } = new List<IChat>();
        public string Name { get; set; }
        public int Id { get; }
    }
}
