using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessagesRepository
    {
        OperationStatus AddMessage(Message addingMessage, int roomId);
        OperationStatus DeleteMessage(int messageId, int userId, int roomId);
        OperationStatus DeleteMessageNoUserIdCheck(int messageId, int roomId);
        OperationStatus EditMessage(int messageId, string textMessage, int userId, int roomId);
        public IReadOnlyCollection<Message> PullMessageForClient(int roomId, int lastNumMessages);
    }
}