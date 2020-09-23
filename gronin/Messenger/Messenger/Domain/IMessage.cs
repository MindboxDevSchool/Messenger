using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid Id { get;  }
        string SenderId { get;  }
        string Text { get; set; }
        IUserInGroup Sender { get;  }
    }
}