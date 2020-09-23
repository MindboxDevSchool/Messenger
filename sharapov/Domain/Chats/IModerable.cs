namespace Messenger.Domain.Chats
{
    public interface IModerable
    {
        public void AddModerator(Moderator moderator);
        public void RemoveModerator(Moderator moderator);
    }
}