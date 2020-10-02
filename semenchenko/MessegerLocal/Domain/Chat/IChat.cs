using System.Collections.Generic;

namespace Messeger.Domain.Chat
{
    public interface IChat
    {
        string Title { get; }
        ProfilePicture Picture { get; }
        IEnumerable<UserInChat> ChatMembers { get; }
    }
}