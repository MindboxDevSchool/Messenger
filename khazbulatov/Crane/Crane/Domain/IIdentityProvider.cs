namespace Crane.Domain
{
    public interface IIdentityProvider
    {
        int NextId { get; }
    }
}
