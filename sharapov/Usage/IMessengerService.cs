using System.Collections.Generic;
using Messenger.Domain;

namespace Usage
{
    public interface IMessengerService
    {
        IReadOnlyCollection<Message> User1SendUser2AndPullFromRepo(string textForSending, int amountMessageForPull);
    }
}