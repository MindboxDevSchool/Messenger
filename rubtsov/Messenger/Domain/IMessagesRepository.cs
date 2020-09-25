using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessagesRepository
    {
        public List<Message> MessagesHistory { get; set; }
    }
}