using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get; }
        IUser Sender { get; }
        string Text { get; set; }
        IChat Chat { get; }
        DateTime DateTime { get; }
    }
}