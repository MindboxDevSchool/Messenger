using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class MessagesRepository : IMessagesRepository, IPullable
    {
        //key group id 

        private readonly Dictionary<int, IList<Message>> _messages = new Dictionary<int, IList<Message>>();

        public OperationStatus AddMessage(Message addingMessage, int groupId)
        {
            if (_messages.ContainsKey(groupId))
            {
                var messages = _messages[groupId];
                messages.Add(addingMessage);
            }
            else
            {
                _messages[groupId] = new List<Message>();
                var messages = _messages[groupId];
                messages.Add(addingMessage);
            }

            return OperationStatus.Success;
        }

        //bad traverse
        public OperationStatus DeleteMessage(int messageId, int userId, int roomId)
        {
            var messages = _messages[roomId];
            messages.Remove(messages.First(msg => msg.MessageId == messageId &&  msg.MessageCreatorId == userId));
            return OperationStatus.Success;
        }

        //bad traverse
        public OperationStatus DeleteMessageNoUserIdCheck(int messageId, int roomId)
        {
            var messages = _messages[roomId];
            messages.Remove(messages.First(msg => msg.MessageId == messageId && msg.MessageCreatorId == messageId));
            return OperationStatus.Success;
        }

        //bad traverse `
        public OperationStatus EditMessage(int messageId, string textMessage, int userId, int roomId)
        {
            try
            {
                foreach (var list in _messages.Select(entry => entry.Value))
                {
                    var messageForEdit =
                        list.First(msg => msg.MessageId == messageId && msg.MessageCreatorId == userId);
                    if (messageForEdit != null)
                    {
                        messageForEdit.Text = textMessage;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " Can't delete message");
                return OperationStatus.Failure;
            }

            return OperationStatus.Success;
        }


        private List<Message> GetLastNumMessages(int roomId, int lastNumMessages)
        {
            return _messages[roomId]
                .Skip(Math.Max(0, _messages.Count - lastNumMessages))
                .ToList();
        }

        public IReadOnlyCollection<Message> PullMessageForClient(int roomId, int lastNumMessages)
        {
            var pullMessages = new ReadOnlyCollection<Message>(GetLastNumMessages(roomId, lastNumMessages));
            return pullMessages;
        }
    }
}