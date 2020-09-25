namespace Messenger.Domain
{
    public class Chatter : IChatRole, IChatter
    {
        public string UserName { get; }
        public int UserId { get; }

        public Chatter(string userName, int userId)
        {
            UserName = userName;
            UserId = userId;
        }
    }
}