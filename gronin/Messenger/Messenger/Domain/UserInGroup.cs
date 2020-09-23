

using System;

namespace Messenger.Domain
{
    public class UserInGroup : IUserInGroup
    {
        public UserInGroup(string userId, string groupId, bool isAdmin, bool isOwner, User user, Group @group)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            GroupId = groupId ?? throw new ArgumentNullException(nameof(groupId));
            IsAdmin = isAdmin;
            IsOwner = isOwner;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Group = @group ?? throw new ArgumentNullException(nameof(@group));
        }

        public string UserId { get; }
        public string GroupId { get; }
        public bool IsAdmin { get; }
        public bool IsOwner { get; }

        public virtual User User { get; }
        public virtual Group Group { get; }
    }
}