using System.Collections.Generic;

namespace Crane.Domain
{
    public abstract class Chat : IChat
    {
        public IEnumerable<IMessage> Messages { get; } = new List<IMessage>();
        public abstract IEnumerable<IMember> Members { get; }
        public abstract IEnumerable<IRole> Roles { get; }
        public virtual string Name { get; set; }
        public int Id { get; }
        
        public bool TrySendMessage(IMessage message)
        {
            return false;
        }
    }
}
