using System.Collections.Generic;

namespace Messenger.Domain.Chats
{
    public interface IChannel
    {
        IEnumerable<Message> GetLastMessages(int num);
        OperationStatus AddMessage(ICreator creatorChannel, string textMessage);
        OperationStatus DeleteMessage(ICreator channelCreator, int messageId);                          //TODO redundant method. Method is not described by task constraint
        OperationStatus EditMessage(ICreator channelCreator, int messageId, string textForReplace);     //TODO redundant method. Method is not described by task constraint 
    }
}