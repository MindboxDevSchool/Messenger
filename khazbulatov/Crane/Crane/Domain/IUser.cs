using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IUser : ISender, IIdentified
    {
        IPasswordHandler PasswordHandler { get; }
        IEnumerable<IChat> Chats { get; }
    }
}
