namespace Messenger.Domain
{
    public class Moderator : Chatter
    {
        public Moderator(string userName, int userId) : base(userName, userId)
        {
        }
    }
}