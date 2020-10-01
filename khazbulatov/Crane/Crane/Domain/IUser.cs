namespace Crane.Domain
{
    public interface IUser : IIdentified
    {
        IPasswordHandler PasswordHandler { get; }
        string Name { get; }
    }
}
