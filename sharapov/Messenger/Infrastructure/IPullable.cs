using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IPullable
    {

        IReadOnlyCollection<Message> PullMessageForClient(int roomId, int lastNumMessages);

    }
}