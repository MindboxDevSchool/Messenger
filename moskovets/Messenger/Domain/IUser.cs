using System;

namespace Messenger.Domain
{
    public interface IUser : IReceiver, ISender
    {
        public String Id { get; }
        public string Login { get; set; }
    }
}