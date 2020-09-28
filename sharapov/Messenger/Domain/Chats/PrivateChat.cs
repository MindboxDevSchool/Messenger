using System;
using System.Collections.Generic;

namespace Messenger.Domain.Chats
{
    //dont save messages on server side. Messages doesn't persist 
    public class PrivateChat : IPrivateChat
    {
        public IChatter FirstChatter { get; }
        public IChatter SecondChatter { get; }
        public int PrivateChatId { get; }

        private readonly IMessagesRepository _repositoryUserMessages;
        private readonly IMessageIdGenerator _messageIdGenerator;

        public PrivateChat(IChatter firstChatter, IChatter secondChatter, IMessagesRepository repositoryUserMessages,
            IMessageIdGenerator messageIdGenerator, int privateChatId)
        {
            FirstChatter = firstChatter;
            SecondChatter = secondChatter;
            _repositoryUserMessages = repositoryUserMessages;
            _messageIdGenerator = messageIdGenerator;
            PrivateChatId = privateChatId;
        }

        public OperationStatus AddMessage(IChatter fromChatter, string textMessage)
        {
            if (fromChatter == null) throw new ArgumentNullException(nameof(fromChatter));

            if (FirstChatter == fromChatter)
            {
                return SendToChatter(FirstChatter, SecondChatter, textMessage);
            }

            if (SecondChatter == fromChatter)
            {
                return SendToChatter(SecondChatter, FirstChatter, textMessage);
            }

            return OperationStatus.NoSuchChatter;
        }
        
        private OperationStatus SendToChatter(IChatter fromChatter, IChatter toChatter, string textMessage)
        {
            
            var globalMsgId = _messageIdGenerator.GetNextMessageId();
            var message = new Message(textMessage, globalMsgId, fromChatter.UserId, new List<int>{toChatter.UserId});
            return _repositoryUserMessages.AddMessage(message, PrivateChatId);
        }

        public OperationStatus DeleteMessage(IChatter chatter, int messageId)
        {
            return IsChatter(chatter) ? _repositoryUserMessages.DeleteMessage(messageId, chatter.UserId, PrivateChatId) : OperationStatus.NoSuchChatter;
        }
        
        private bool IsChatter(IChatter chatter)
        {
            return FirstChatter == chatter || SecondChatter == chatter;
        }

        public OperationStatus EditMessage(IChatter chatter, int messageId, string textMessage)
        {
            return IsChatter(chatter) ? _repositoryUserMessages.EditMessage(messageId, textMessage, chatter.UserId, PrivateChatId) : OperationStatus.NoSuchChatter;
        }
    }
}