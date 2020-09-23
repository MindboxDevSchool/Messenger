using System;

namespace Messenger.Domain
{
    public interface IUser
    {
        string Name { get; }
        Guid Id { get; }
    }
}