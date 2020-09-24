using System.Collections.Generic;

namespace Crane.Domain
{
    public class GroupChat : Chat
    {
        public override IEnumerable<IMember> Members { get; } = new List<IMember>();
        public override IEnumerable<IRole> Roles { get; } = new List<IRole>()
        {
            Role.Nobody,
            Role.Participant,
            Role.Administrator
        };
    }
}
