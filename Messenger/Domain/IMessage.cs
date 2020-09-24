using System;

namespace Messenger.Domain
{
    public interface IMessage
    {
        Guid MessageId { get; }
        DateTime CreatedDate { get; }
        Guid MessageCreator { get; }
        String MessageText { get; set; }
        
        bool MessageNotificationStatus { get; }
        
        String MessageNotification { get; }
    }
}