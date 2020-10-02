using System.Collections.Generic;

namespace Messeger.Domain.Chat
{
    public abstract class MultipleUsersChat : IChat
    {
        public string Title { get; set; }
        public ProfilePicture Picture { get; }
        public IEnumerable<UserInChat> ChatMembers { get; }
    }
}