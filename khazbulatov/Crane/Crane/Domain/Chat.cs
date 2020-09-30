using System;
using System.Collections.Generic;
using System.Linq;

namespace Crane.Domain
{
    public abstract class Chat : IChat
    {
        private IIdentityProvider _idProvider;
        private readonly IRepo<IMessage> _messageRepo;

        public IEnumerable<IMessage> Messages => _messageRepo.Items;
        public abstract IEnumerable<IMember> Members { get; }
        public abstract IEnumerable<IRole> Roles { get; }
        public virtual string Name { get; set; }
        public int Id { get; }

        protected Chat(int id, IIdentityProvider idProvider, IRepo<IMessage> messageRepo)
        {
            _idProvider = idProvider;
            _messageRepo = messageRepo;
            Id = id;
        }

        public bool TrySendMessage(IUser user, string body)
        {
            IMember member = Members.SingleOrDefault(m => m.User == user);
            if (body != null && member != null
                && Members.Contains(member)
                && member.Role.Permissions.Contains(Permission.Send))
            {
                _messageRepo.AddItem(new Message(_idProvider.NextId, DateTime.Now, user, this, body));
            }
            return false;
        }

        public bool TryEditMessage(IUser user, IMessage message, string body)
        {
            throw new NotImplementedException();
        }
    }
}
