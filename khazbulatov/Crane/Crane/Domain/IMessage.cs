using System;

namespace Crane.Domain
{
    public interface IMessage : IIdentified
    {
        DateTime TimeSent { get; }
        IUser Sender { get; }
        IChat Chat { get; }
        string Body { get; set; }
    }
}
