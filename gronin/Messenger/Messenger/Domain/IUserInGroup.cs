namespace Messenger.Domain
{
    public interface IUserInGroup
    {
        string UserId { get; }
        string GroupId { get; }
        bool IsAdmin { get; }
        bool IsOwner { get; }
        IUser User { get; }
        IGroup Group { get; }
    }
}