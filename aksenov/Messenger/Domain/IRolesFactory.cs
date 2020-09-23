namespace Messenger.Domain
{
    public interface IRolesFactory
    {
        ChatRole Create(RoleType roleType);
    }
}