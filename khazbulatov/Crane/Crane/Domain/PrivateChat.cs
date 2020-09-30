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
            IRepo<IMessage> messageRepo, IMember self, IMember peer)
            : base(id, idProvider, messageRepo)
        {
            _peer = peer;
            Members = new IMember[] {self, _peer};
            Roles = new IRole[] 
            {
                Role.Nobody,
                Role.Participant
            };
        }
    }
}
