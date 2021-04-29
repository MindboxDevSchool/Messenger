using System;
using System.Collections.Generic;
using System.Linq;

namespace Crane.Domain
{
    public abstract class Chat : IChat
    {
        private readonly IIdentityProvider _idProvider;
        private readonly IRepo<IMessage> _messageRepo;

        public IEnumerable<IMessage> Messages => _messageRepo.Items;
        public abstract IEnumerable<IMember> Members { get; }
        public abstract IEnumerable<IRole> Roles { get; }
        public virtual string Name { get; }
        public int Id { get; }

        protected Chat(int id, IIdentityProvider idProvider, IRepo<IMessage> messageRepo)
        {
            _idProvider = idProvider;
            _messageRepo = messageRepo;
            Id = id;
        }
        
        public static Chat Parse(string representation)
        {
            throw new NotImplementedException();
        }
        
        public static string Render(Chat chat)
        {
            throw new NotImplementedException();
        }

        public bool TrySendMessage(IUser user, string body)
        {
            IMember member = Members.SingleOrDefault(m => m.User == user);
            if (body != null
                && member != null
                && member.Role.Permissions.Contains(Permission.Send))
            {
                _messageRepo.Add(new Message(_idProvider.NextId, DateTime.Now, user, this, body));
                return true;
            }
            return false;
        }

        public bool TryEditMessage(IUser user, int messageId, string body)
        {
            IMember member = Members.SingleOrDefault(m => m.User == user);
            if (body != null
                && member != null
                && member.Role.Permissions.Contains(Permission.EditOwn))
            {
                int recordsAffected = _messageRepo.Apply(
                    m => m.Id == messageId && m.Sender == member.User,
                    m => m.Body = body
                );
                return recordsAffected > 0;
            }
            return false;
        }

        public bool TryDeleteMessage(IUser user, int messageId)
        {
            IMember member = Members.SingleOrDefault(m => m.User == user);
            if (member != null
                && member.Role.Permissions.Contains(Permission.DeleteOwn))
            {
                bool canDeleteAny = member.Role.Permissions.Contains(Permission.DeleteAny);
                int recordsAffected = _messageRepo.Remove(
                    m => m.Id == messageId && (canDeleteAny || m.Sender == member.User)
                );
                return recordsAffected > 0;
            }
            return false;
        }
    }
}
