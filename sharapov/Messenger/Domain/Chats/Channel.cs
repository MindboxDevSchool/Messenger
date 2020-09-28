using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Messenger.Domain.Roles;

namespace Messenger.Domain.Chats
{
    public class Channel : ISubscription, IChannel
    {
        public ICreator Creator {get;} 
        public int ChannelId { get;} 

        public ReadOnlyCollection<IChatter> Subscribers =>
            new ReadOnlyCollection<IChatter>(_subscribers);

        private readonly IList<IChatter> _subscribers;
        private readonly IMessagesRepository _channelMessagesRepository;
        private readonly IMessageIdGenerator _messageIdGenerator;

        public Channel(ICreator channelCreator, int channelId, IMessageIdGenerator messageIdGenerator,
            IMessagesRepository repositoryChannelMessages)
        {
            Creator = channelCreator;
            ChannelId = channelId;
            _subscribers = new List<IChatter>();
            _messageIdGenerator = messageIdGenerator;
            _channelMessagesRepository = repositoryChannelMessages;
            _subscribers.Add(channelCreator);
        }

        public OperationStatus AddMessage(ICreator creatorChannel, string textMessage)
        {
            if (!Creator.Equals(creatorChannel))
            {
                return OperationStatus.NotHaveCredentials;
            }

            var globalMsgId = _messageIdGenerator.GetNextMessageId();
            var message = new Message(textMessage, globalMsgId, creatorChannel.UserId,
                _subscribers.Select(s => s.UserId).ToList());
            return _channelMessagesRepository.AddMessage(message, ChannelId);
        }

        public OperationStatus DeleteMessage(ICreator channelCreator, int messageId)
        {
            return Creator.Equals(channelCreator)
                ? _channelMessagesRepository.DeleteMessage(messageId, channelCreator.UserId, ChannelId)
                : OperationStatus.NotHaveCredentials;
        }

        public OperationStatus EditMessage(ICreator channelCreator, int messageId, string textForReplace)
        {
            return Creator.Equals(channelCreator)
                ? _channelMessagesRepository.EditMessage(messageId, textForReplace, channelCreator.UserId, ChannelId)
                : OperationStatus.NotHaveCredentials;
        }

        public void AddChatter(IChatter subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveChatter(IChatter subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}