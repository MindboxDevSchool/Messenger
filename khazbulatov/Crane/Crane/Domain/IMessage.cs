using System;

namespace Crane.Domain
{
    public interface IMessage
    {
        DateTime TimeSent { get; }
        ISender Sender { get; }
        IChat Chat { get; }
        string Body { get; }
    }
}
