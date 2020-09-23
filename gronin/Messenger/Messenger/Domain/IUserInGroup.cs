namespace Messenger.Domain
{
    public interface IUserInGroup
    {
        string UserId { get; }
        string GroupId { get; }
        bool IsAdmin { get; }
        bool IsOwner { get; }
        User User { get; }
        Group Group { get; }
    }
}