

using System;

namespace Messenger.Domain
{
    public class UserInGroup : IUserInGroup
    {
        public UserInGroup(Guid userId, Guid groupId, bool isAdmin, bool isOwner, IUser user, IGroup @group)
        {
            UserId = userId;
            GroupId = groupId;
            IsAdmin = isAdmin;
            IsOwner = isOwner;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Group = @group ?? throw new ArgumentNullException(nameof(@group));
        }

        public Guid UserId { get; }
        public Guid GroupId { get; }
        public bool IsAdmin { get; }
        public bool IsOwner { get; }

        public virtual IUser User { get; }
        public virtual IGroup Group { get; }
    }
}