using Domain.User;

namespace Domain.Chats
{
    public interface IHasOwner
    {
        public IUser Owner { get; }
    }
}