using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IUser : IIdentified
    {
        IPasswordHandler PasswordHandler { get; }
        IEnumerable<IChat> Chats { get; }
        string Name { get; }
    }
}
