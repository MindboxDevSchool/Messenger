using System.Collections.Generic;

namespace Crane.Domain
{
    public class PrivateChat : Chat
    {
        private readonly IMember _peer;

        public override IEnumerable<IMember> Members { get; }
        public override IEnumerable<IRole> Roles { get; }
        public override string Name => _peer.User.Name;

        public PrivateChat(int id, IIdentityProvider idProvider,
            IRepo<IMessage> messageRepo, IUser self, IUser peer)
            : base(id, idProvider, messageRepo)
        {
            _peer = new Member(peer, Role.Participant);
            Members = new IMember[] {new Member(self, Role.Participant), _peer};
            Roles = new IRole[] 
            {
                Role.Nobody,
                Role.Participant
            };
        }
    }
}
