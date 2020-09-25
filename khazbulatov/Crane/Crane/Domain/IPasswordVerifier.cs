namespace Crane.Domain
{
    public interface IPasswordHandler
    {
        void SetPassword(string password);
        bool VerifyPassword(string password);
    }
}
