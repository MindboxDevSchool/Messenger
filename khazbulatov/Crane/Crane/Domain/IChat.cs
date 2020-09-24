using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IChat
    {
        IEnumerable<IMessage> Messages { get; }
        IEnumerable<IMember> Members { get; }
        IEnumerable<IRole> Roles { get; }
        string Name { get; }
    }
}
