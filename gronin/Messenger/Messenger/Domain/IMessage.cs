using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get; set; }
        string SenderId { get; set; }
        string Text { get; set; }
        User Sender { get; set; }
    }
}