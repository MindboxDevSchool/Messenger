using System;

namespace Messenger.Domain
{
    public interface IUser : IReceiver, ISender
    {
        String Id { get; }
        string Login { get; set; }
    }
}