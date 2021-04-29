namespace Crane.Domain
{
    public interface IPasswordHandler
    {
        string GetToken(object o);
        void SetPassword(string password);
        bool VerifyPassword(string password);
    }
}
