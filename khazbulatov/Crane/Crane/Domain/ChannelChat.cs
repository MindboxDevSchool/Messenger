using System.Collections.Generic;

namespace Crane.Domain
{
    public class ChannelChat : Chat
    {
        private readonly IRepo<IMember> _memberRepo;

        public override IEnumerable<IMember> Members => _memberRepo.Items;
        public override IEnumerable<IRole> Roles { get; } = new IRole[]
        {
            Role.Nobody,
            Role.Viewer,
            Role.Author
        };

        public ChannelChat(int id, IIdentityProvider idProvider, IRepo<IMessage> messageRepo, IRepo<IMember> memberRepo)
            : base(id, idProvider, messageRepo)
        {
            _memberRepo = memberRepo;
        }
    }
}
