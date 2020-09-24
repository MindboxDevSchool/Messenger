using System.Collections.Generic;

namespace Crane.Domain
{
    public class PrivateChat : Chat
    {
        private const int PeerIndex = 1;
        private const int MemberCount = 2;
        
        private readonly IMember[] _members = new IMember[MemberCount];
        private readonly IRole[] _roles = new IRole[] 
        {
            Role.Nobody,
            Role.Participant
        };

        public override IEnumerable<IMember> Members => _members;
        public override IEnumerable<IRole> Roles => _roles;
        public override string Name => _members[PeerIndex].User.Name;
    }
}
