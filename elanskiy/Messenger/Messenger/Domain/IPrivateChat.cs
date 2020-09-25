using System;

namespace Messenger.Domain
{
    public interface IPrivateChat
    {
        Guid Id { get; }
        Guid[] Users { get; }
        DateTime CreatedOn { get; }
    }
}