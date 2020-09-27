using Domain.User;

namespace Domain.Chats
{
    public interface IChannel : IChat
    {
        public IUser Owner { get; }
    }
}