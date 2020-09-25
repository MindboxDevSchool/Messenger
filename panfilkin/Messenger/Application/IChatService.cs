using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        public IChatRepository ChatRepository { get; }
        public IMessageRepository MessageRepository { get; }

        public Guid CreatePrivateChat(IUser userActing, IUser userChatter);
        public Guid CreateGroupChat(IUser userActing);
        public Guid CreateChanel(IUser userActing);

        public void JoinChat(IChat chat, IUser userActing);

        public void LeaveChat(IChat chat, IUser userActing);

        public Guid SendMessage(IChat chat, IUser userActing, string messageText);

        public void DeleteMessage(IUser userActing, IMessage message);
        public void EditMessage(IUser userActing, IMessage message, string messageText);
    }
}