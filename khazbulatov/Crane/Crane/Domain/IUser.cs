using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IUser : ISender
    {
        public IEnumerable<IChat> Chats { get; }
    }
}
