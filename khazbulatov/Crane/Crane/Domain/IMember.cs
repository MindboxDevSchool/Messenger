namespace Crane.Domain
{
    public interface IMember
    {
        IChat Chat { get; }
        IRole Role { get; }
        IUser User { get; }
    }
}
