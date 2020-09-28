namespace Messenger.Domain
{
    public class Moderator : Chatter, IModerator
    {
        public Moderator(string userName, int userId) : base(userName, userId)
        {
        }
    }
}