using System.Collections.Generic;

namespace Messenger2.Domain.Channel
{
    public interface IChannelUserSide
    {
        public List<IMessage> Messages { get; }
        public IUser Admin { get; set;  }
    }
}