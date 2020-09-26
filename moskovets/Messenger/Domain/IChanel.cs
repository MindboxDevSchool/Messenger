using System;

namespace Messenger.Domain
{
    public interface IChanel : IReceiver
    {
        public String Id { get; }
        public string Name { get; set; }
        public IUser User { get; }
    }
}