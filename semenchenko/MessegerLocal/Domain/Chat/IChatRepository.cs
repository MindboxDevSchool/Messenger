using System;
using System.Collections.Generic;

namespace Messeger.Domain
{
    public interface IChatRepository
    {
        IEnumerable<Message> GetLatestMessages();

        void PushMessage(Message message);

        void DeleteMessage(Guid messageId);

        void EditMessage(Guid messageId);
    }
}