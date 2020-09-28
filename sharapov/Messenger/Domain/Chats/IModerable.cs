namespace Messenger.Domain.Chats
{
    public interface IModerable
    {
        public void AddModerator(IModerator moderator);
        public void RemoveModerator(IModerator moderator);
    }
}