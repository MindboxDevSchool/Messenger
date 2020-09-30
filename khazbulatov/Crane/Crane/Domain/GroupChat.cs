using System.Collections.Generic;

namespace Crane.Domain
{
    public class GroupChat : Chat
    {
        private readonly IRepo<IMember> _memberRepo;

        public override IEnumerable<IMember> Members => _memberRepo.Items;
        public override IEnumerable<IRole> Roles { get; }

        public GroupChat(int id,
            IIdentityProvider idProvider,
            IRepo<IMessage> messageRepo,
            IRepo<IMember> memberRepo,
            IEnumerable<IRole> roles = null)
            : base(id, idProvider, messageRepo)
        {
            _memberRepo = memberRepo;
            Roles = roles ?? new List<IRole>()
            {
                Role.Nobody,
                Role.Participant,
                Role.Administrator
            };
        }
    }
}
