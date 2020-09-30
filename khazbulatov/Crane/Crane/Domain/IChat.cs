using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IChat : IIdentified
    {
        IEnumerable<IMessage> Messages { get; }
        IEnumerable<IMember> Members { get; }
        IEnumerable<IRole> Roles { get; }
        string Name { get; }
        
        bool TrySendMessage(IUser user, string body);
        bool TryEditMessage(IUser user, IMessage message, string body);
    }
}
