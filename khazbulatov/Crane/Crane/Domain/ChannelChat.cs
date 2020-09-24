using System.Collections.Generic;

namespace Crane.Domain
{
    public class ChannelChat : Chat
    {
        public override IEnumerable<IMember> Members { get; } = new List<IMember>();
        public override IEnumerable<IRole> Roles { get; } = new IRole[]
        {
            Role.Nobody,
            Role.Viewer,
            Role.Author
        };
    }
}
