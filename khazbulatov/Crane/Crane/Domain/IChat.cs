using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IChat : IIdentified
    {
        IEnumerable<IMessage> Messages { get; }
        IEnumerable<IMember> Members { get; }
        IEnumerable<IRole> Roles { get; }
        string Name { get; }

        bool TrySendMessage(IMessage message);
    }
}
