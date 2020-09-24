using System;

namespace Messenger.Domain
{
    public interface IUser
    {
        Guid UserId { get; }
        String Login { get; }
    }
}