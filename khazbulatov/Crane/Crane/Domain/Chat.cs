using System.Collections.Generic;

namespace Crane.Domain
{
    public abstract class Chat : IChat
    {
        public IEnumerable<IMessage> Messages { get; } = new List<IMessage>();
        public virtual string Name { get; set; }
        public abstract IEnumerable<IMember> Members { get; }
        public abstract IEnumerable<IRole> Roles { get; }
    }
}
