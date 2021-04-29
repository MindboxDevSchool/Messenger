namespace Crane.Domain
{
    public interface IMember
    {
        IRole Role { get; }
        IUser User { get; }
    }
}
