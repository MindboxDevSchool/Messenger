using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IGroup
    {
        Guid Id { get; }
        string Name { get; }
        IUser CreatedBy { get; }
        
        Guid SendMessage(IUser sender, string text);
        IMessage GetMessage(Guid messageId);
        void EditMessage(IUser caller, IMessage message, string newText);
        void DeleteMessage(IUser caller, IMessage message);
    }
}