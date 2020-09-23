using System;
using Domain.User;

namespace Domain.Repositories
{
    public interface IMessageRepository
    {
        IUser AddMessage(IMessage message);
        IUser GetMessageById(Guid id);
        IUser UpdateMessage(IMessage message);
    }
}