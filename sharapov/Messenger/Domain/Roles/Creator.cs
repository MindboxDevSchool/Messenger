namespace Messenger.Domain.Roles
{
    public class Creator : ICreator
    {
        public string UserName { get; }
        public int UserId { get; }
        
        public Creator(string userName, int userId)
        {
            UserName = userName;
            UserId = userId;
        }
    }
}