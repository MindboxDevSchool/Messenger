using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain.Chats
{
    public class Channel : ISubject, IChannel
    {
        private readonly ICreator creator;
        private IList<Chatter> subscribers;
        private IList<Message> messages;
        public int ChannelId { get; }

        public Channel(ICreator channelCreator, int channelId)
        {
            ChannelId = channelId;
            channelCreator = creator;
            subscribers = new List<Chatter>();
            messages = new List<Message>();
        }

        public Channel(ICreator channelCreator, IEnumerable<Chatter> subscribers, IEnumerable<Message> messages, int channelId)
        {
            ChannelId = channelId;
            channelCreator = creator;
            subscribers = new List<Chatter>();
            messages = new List<Message>();
        }

        public IEnumerable<Message> GetLastMessages(int num = 10)
        {
            return messages.OrderByDescending(msg => msg.TimePost).Skip(messages.Count - num);
        }

        public OperationStatus AddMessage(ICreator creatorChannel, string textMessage)
        {
            if (!creator.Equals(creatorChannel))
            {
                return OperationStatus.NotHaveCredentials;
            }
            //TODO generate global msg id
            //from repo?
            const int globalMsgId = 42;
            var message = new Message(textMessage, globalMsgId, creatorChannel.UserId);
            messages.Add(message);
            Notify(message);
            return OperationStatus.Success;
        }

        public OperationStatus DeleteMessage(ICreator channelCreator, int messageId)
        {
            if (creator.Equals(channelCreator))
            {
                var messageForDelete = messages.FirstOrDefault(msg => msg.MessageId == messageId);
                if (messageForDelete != null)
                {
                    messages.Remove(messageForDelete);
                    return OperationStatus.Success;
                }
                else
                {
                    return OperationStatus.NoSuchMessage;
                }
            }
            else
            {
                return OperationStatus.NotHaveCredentials;
            }
        }

        public OperationStatus EditMessage(ICreator channelCreator, int messageId, string textForReplace)
        {
            if (creator.Equals(channelCreator))
            {
                var messageForEdit = messages.FirstOrDefault(msg => msg.MessageId == messageId);
                if (messageForEdit != null)
                {
                    messageForEdit.Text = textForReplace;
                    return OperationStatus.Success;
                }
                else
                {
                    return OperationStatus.NoSuchMessage;
                }
            }
            else
            {
                return OperationStatus.NotHaveCredentials;
            }
        }

        public void AddChatter(Chatter subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveChatter(Chatter subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void Notify(Message message)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(message);
            }
        }
    }
}